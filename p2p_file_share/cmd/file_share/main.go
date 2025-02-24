package main

import (
	"fmt"
	"os"

	"github.com/Jonycakes03/p2p_file_share/internal/peer"
)

func main() {
	done := make(chan struct{})
	go func() {
		defer close(done)
		peer.StartListening(os.Args[2])

	}()
	if os.Args[1] == "download" {
		peer.DownloadFile(os.Args[3], os.Args[4], os.Args[5])
	} else {
		fmt.Println("Waiting for connections ...")
	}
	<-done
}
