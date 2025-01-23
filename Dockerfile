FROM golang:1.23.4 as Build
WORKDIR /app
COPY go.mod ./
RUN go mod download
RUN mkdir test

COPY . .

RUN CGO_ENABLE=0 GOOD=linux go build -o /api ./cmd/api

EXPOSE 80

CMD ["/api"]