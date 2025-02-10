<<<<<<< HEAD
FROM golang:1.23.4 as build
WORKDIR /app

COPY go.mod ./
RUN go mod download 

COPY . ./

RUN CGO_ENABLED=0 GOOS=linux go build -o /chat ./cmd/chat
=======
FROM golang:1.23.4 as build
WORKDIR /app

COPY go.mod ./
RUN go mod download 

COPY . ./

RUN CGO_ENABLED=0 GOOS=linux go build -o /chat ./cmd/chat
>>>>>>> 8591f7fb26069bbdf7dd669caffde3e351289653
ENTRYPOINT [ "/chat" ]