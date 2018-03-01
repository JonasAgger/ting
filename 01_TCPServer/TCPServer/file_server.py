import sys
import socket
from TCPLib import *

HOST = "100.82.135.170"
PORT = 9000
BUFSIZE = 1000


def main(argv):
    serversocket = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
    serversocket.bind((HOST, PORT))

    print("Setting up server on IP: {}, on port {}".format(HOST, PORT))

    serversocket.listen(5)


    while True:
        # Accepting Connection
        clientsocket, addr = serversocket.accept()

        print("got a connection from {}".format(addr))

        # Getting file request
        msg = readTextTCP(clientsocket)

        print("message received: {}".format(msg))

        # If close, close server, used for debugging and quick resetting the server
        if msg == "close":
            serversocket.close()
            sys.exit()

        msg = "Hello there ESP module\r\n"

        writeTextTCP(msg, clientsocket)

        clientsocket.close()

        


def sendFile(fileName,  fileSize,  conn):
    pass
    # TO DO Your Code
    
if __name__ == "__main__":
    main(sys.argv[1:])
