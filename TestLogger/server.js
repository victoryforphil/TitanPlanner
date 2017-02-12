var net = require('net')

var port = 7777;
var server = net.createServer();
server.listen(port, function(err,err2){
  console.log(err2);
});
server.on('connection', function(socket) { //This is a standard net.Socket
  console.log("Conneted!");
    socket.on('data', function(message) {
        console.log(message.length);
        console.log(message.toString());
    });
});
