""" This module generates notes for a midi file using the
    trained neural network """
import pickle
import os
import numpy
from music21 import instrument, note, stream, chord, converter
from keras.models import Sequential
from keras.layers import Dense
from keras.layers import Dropout
from keras.layers import LSTM
from keras.layers import BatchNormalization as BatchNorm
from keras.layers import Activation
import time
import struct

os.environ["CUDA_VISIBLE_DEVICES"]="1"

delay = 0

def get_notes(file):
    notes = []
    global delay
    offset = 0
    previous = None
    i = 0
    midi = converter.parse(file)

    print("Parsing %s" % file)

    notes_to_parse = None

    try: # file has instrument parts
        #s2 = instrument.partitionByInstrument(midi)
        s2 = instrument.Piano
        notes_to_parse = s2.parts[0].recurse()
    except: # file has notes in a flat structure
        notes_to_parse = midi.flat.notes

    for element in notes_to_parse:
        if(previous is not None):
            i+=1
            offset += float(element.offset) - float(previous.offset)
        previous = element
        if isinstance(element, note.Note):
            notes.append(str(element.pitch))
        elif isinstance(element, chord.Chord):
            notes.append('.'.join(str(n) for n in element.normalOrder))
    offset = offset/i
    delay = offset

    return notes

def song_to_int (note_to_int,file_path):
    notes = get_notes(file_path)
    int_notes = []
    #print(note_to_int.keys())
    i =0
    offset=0
    count=0
    for note in notes:
        #print(note)
        if(note in note_to_int.keys()):
            int_notes.append(note_to_int[note])
            i+=1
        #if(i>999):
        #    break
    print(f'Udalo sie {i}')
    return int_notes


def generate(my_pipe):
    """ Generate a piano midi file """
    #load the notes used to train the model
    with open('data/notes', 'rb') as filepath:
        notes = pickle.load(filepath)
    # Get all pitch names
    pitchnames = sorted(set(item for item in notes))
    note_to_int = dict((note, number) for number, note in enumerate(pitchnames))

    name = getData(my_pipe)
    if(name == "From library"):
        print("From library")
        ownSeed = False
    else:
        #name = os.path.abspath(name)
        name = name.replace("\\","\\\\")
        print(name)
        ownSeed = True


    #seed = song_to_int(note_to_int,"test/mz.mid")
    if(ownSeed):
        seed = song_to_int(note_to_int,name)
        sendData(my_pipe,str(len(seed)))
    else:
        seed = []
        #sendData(my_pipe,'1000')
    #gain data from c# client
    parameters = getData(my_pipe)
    parameters = parameters.split()
    
    if(ownSeed):
        seed = seed[:int(parameters[0])]
        print("seed length: " + str(len(seed)))
    #sendData(my_pipe,str(len(seed)))
    # Get all pitch names
    n_vocab = len(set(notes))

    network_input, normalized_input = prepare_sequences(notes, pitchnames, n_vocab,seed,note_to_int,int(parameters[0]))
    model = create_network(normalized_input, n_vocab)
    prediction_output = generate_notes(model, network_input, pitchnames, n_vocab,seed,int(parameters[1]),ownSeed)
    create_midi(prediction_output,parameters[-4:])

def prepare_sequences(notes, pitchnames, n_vocab,seed,note_to_int,count):
    """ Prepare the sequences used by the Neural Network """

    sequence_length = count
    network_input = []
    output = []
    for i in range(0, len(notes) - sequence_length, 1):
        sequence_in = notes[i:i + sequence_length]
        sequence_out = notes[i + sequence_length]
        network_input.append([note_to_int[char] for char in sequence_in])
        output.append(note_to_int[sequence_out])

    n_patterns = len(network_input)

    # reshape the input into a format compatible with LSTM layers
    normalized_input = numpy.reshape(network_input, (n_patterns, sequence_length, 1))
    # normalize input
    normalized_input = normalized_input / float(n_vocab)


    return (network_input, normalized_input)

def create_network(network_input, n_vocab):
    """ create the structure of the neural network """
    model = Sequential()
    model.add(LSTM(
        512,
        input_shape=(network_input.shape[1], network_input.shape[2]),
        recurrent_dropout=0.3,
        return_sequences=True
    ))
    model.add(LSTM(512, return_sequences=True, recurrent_dropout=0.3,))
    model.add(LSTM(512))
    model.add(BatchNorm())
    model.add(Dropout(0.3))
    model.add(Dense(256))
    model.add(Activation('relu'))
    model.add(BatchNorm())
    model.add(Dropout(0.3))
    model.add(Dense(n_vocab))
    model.add(Activation('softmax'))
    model.compile(loss='categorical_crossentropy', optimizer='rmsprop')

    # Load the weights to each node
    model.load_weights('weights-improvement-38-0.6817-bigger.hdf5')

    return model

def generate_notes(model, network_input, pitchnames, n_vocab,seed,notes_count,ownSeed):
    """ Generate notes from the neural network based on a sequence of notes """
    # pick a random sequence from the input as a starting point for the prediction
    start = numpy.random.randint(0, len(network_input)-1)

    int_to_note = dict((number, note) for number, note in enumerate(pitchnames))

    if(ownSeed):
        pattern = seed
    else:
        pattern = network_input[start]
    prediction_output = []

    # generate 500 notes
    print('notes count: '+str(notes_count))
    for note_index in range(notes_count):
        print(note_index)
        prediction_input = numpy.reshape(pattern, (1, len(pattern), 1))
        #print(note_index)
        prediction_input = prediction_input / float(n_vocab)

        prediction = model.predict(prediction_input, verbose=0)

        index = numpy.argmax(prediction)
        result = int_to_note[index]
        prediction_output.append(result)

        pattern.append(index)
        pattern = pattern[1:len(pattern)]
        sendData(my_pipe,str(note_index))

    return prediction_output

def create_midi(prediction_output,fileParams):
    """ convert the output from the prediction to notes and create a midi file
        from the notes """
    offset = 0
    output_notes = []

    # create note and chord objects based on the values generated by the model
    for pattern in prediction_output:
        # pattern is a chord
        if ('.' in pattern) or pattern.isdigit():
            notes_in_chord = pattern.split('.')
            notes = []
            for current_note in notes_in_chord:
                new_note = note.Note(int(current_note))
                new_note.storedInstrument = instrument.Piano()
                notes.append(new_note)
            new_chord = chord.Chord(notes)
            new_chord.offset = offset
            output_notes.append(new_chord)
        # pattern is a note
        else:
            new_note = note.Note(pattern)
            new_note.offset = offset
            new_note.storedInstrument = instrument.Piano()
            output_notes.append(new_note)

        # increase offset each iteration so that notes do not stack
        global delay
        #print('Wykorzystano taki delay: '+ str(delay))
        if(fileParams[0]=="0"):
            print('Avg')
            offset += delay
            print('Offset: '+str(offset))
        elif(fileParams[0]=="1"):
            print("Given offset")
            offset += float(fileParams[1])
            print('Offset: '+str(float(fileParams[1])))
        elif(fileParams[0]=="2"):
            print("Random")
            offset += numpy.random.uniform(float(fileParams[1]),float(fileParams[2]))
        else:
            print("Default")
            offset += 0.5

    midi_stream = stream.Stream(output_notes)

    outputFileName = fileParams[3].replace("\\","\\\\")

    midi_stream.write('midi', fp=outputFileName)

def sendData(my_pipe,message):
    message = message.encode('ascii')
    my_pipe.write(struct.pack('I', len(message)) + message)
    my_pipe.seek(0)
def getData(my_pipe):
    while True:
        try:
            n = struct.unpack('I', my_pipe.read(4))[0]   
            s = my_pipe.read(n).decode('ascii')          
            my_pipe.seek(0)
            return s
        except:
            time.sleep(1)

if __name__ == '__main__':
    #time.sleep(5)
    while True:
        try:
            print('I tried')
            my_pipe = open(r'\\.\pipe\AIMusic', 'r+b', 0)
            break
        except:            
            time.sleep(1)

    while True:
        generate(my_pipe)


