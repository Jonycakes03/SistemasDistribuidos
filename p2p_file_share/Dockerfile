FROM golang:1.23.5 AS build

WORKDIR /app
COPY go.mod ./
RUN go mod download

COPY . ./
RUN CGO_ENABLED=0 GOOD=linux go build -o /file_share ./cmd/file_share

ENTRYPOINT [ "/file_share" ]