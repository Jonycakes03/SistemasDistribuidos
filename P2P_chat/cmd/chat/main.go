<<<<<<< HEAD
// go run main.go (parametros fds fdsa)
// dotnet run ..
// py ei[]
package main

import (
	"os"

	"github.com/Jonycakes03/P2P_chat/internal/peer"
)

func main() {
	operation := os.Args[1]
	connection := os.Args[2]
	username := os.Args[3]
	if operation == "connect" {
		peer.ConnectToPeer(connection, username)
	} else {
		peer.StartListening(connection, username)
	}

}
=======
// go run main.go (parametros fds fdsa)
// dotnet run ..
// py ei[]
package main

import (
	"os"

	"github.com/Jonycakes03/P2P_chat/internal/peer"
)

func main() {
	operation := os.Args[1]
	connection := os.Args[2]
	username := os.Args[3]
	if operation == "connect" {
		peer.ConnectToPeer(connection, username)
	} else {
		peer.StartListening(connection, username)
	}

}
>>>>>>> 8591f7fb26069bbdf7dd669caffde3e351289653
