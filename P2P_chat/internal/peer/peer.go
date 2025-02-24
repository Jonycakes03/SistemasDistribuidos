package peer

import (
	"bufio"
	"fmt"
	"net"
	"os"
)

var username string

func StartListening(port string, user string) {
	username = user
	listener, err := net.Listen("tcp", ":"+port)
	if err != nil {
		fmt.Println("Error listening", err.Error())
		return
	}
	defer listener.Close()
	fmt.Printf("Peer is listening on port %v ...", port)
	for {
		conn, err := listener.Accept()
		if err != nil {
			fmt.Println("Error accepting connections:", err.Error())
			continue
		}

		go handleConnection(conn)
	}
}

func ConnectToPeer(address string, user string) {
	username = user
	conn, err := net.Dial("tcp", address)
	if err != nil {
		fmt.Println("Error connecting to peer: ", err.Error())
		return
	}
	defer conn.Close()

	handleConnection(conn)
}

func receiveMessage(conn net.Conn) {
	reader := bufio.NewReader(conn)
	for {
		message, err := reader.ReadString('\n')
		if err != nil {
			fmt.Println("Connection closed:", err)
			return
		}
		fmt.Print("Received: " + message)
	}

}

func sendMessage(conn net.Conn) {
	writer := bufio.NewWriter(conn)
	for {
		fmt.Print("Enter message: ")
		inputReader := bufio.NewReader(os.Stdin)
		message, _ := inputReader.ReadString('\n')
		_, err := writer.WriteString(username + ": " + message)
		if err != nil {
			fmt.Println("Error sending message:", err)
			return
		}
		writer.Flush()
	}

}

func handleConnection(conn net.Conn) {
	defer conn.Close()
	go receiveMessage(conn)
	sendMessage(conn)
}
