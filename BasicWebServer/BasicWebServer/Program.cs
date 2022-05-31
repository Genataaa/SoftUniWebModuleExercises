using System.Net;
using System.Net.Sockets;
using System.Text;




var connect = "Hello from the server!";
var connectLength = Encoding.UTF8.GetBytes(connect);

var response = $@"HTTP/1.1 200 OK
Content-Type: text/plan; charset=UTF-8
Content-Length: {connectLength}

{connect}";

var responseBytes = Encoding.UTF8.GetBytes(response);
networkStream.Write(responseBytes);
connection.Close();