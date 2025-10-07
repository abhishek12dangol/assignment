using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using Features;

// Make sure to include your Request, Response, and RequestValidator classes in the same project
// or import them from the namespace where you defined them.


int port = 5000;
TcpListener listener = new TcpListener(IPAddress.Any, port);
listener.Start();
Console.WriteLine($"[SERVER] Listening on port {port}...");

while (true)
{
    TcpClient client = listener.AcceptTcpClient();
    Console.WriteLine("[SERVER] Client connected.");

    NetworkStream stream = client.GetStream();

    // Step 1: Read data from client
    byte[] buffer = new byte[4096];
    int bytesRead = stream.Read(buffer, 0, buffer.Length);
    string jsonRequest = Encoding.UTF8.GetString(buffer, 0, bytesRead);

    Console.WriteLine("[SERVER] Received:");
    Console.WriteLine(jsonRequest);

    // Step 2: Deserialize into Request object
    Request req = JsonSerializer.Deserialize<Request>(jsonRequest,
        new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

    // Step 3: Validate request
    var validator = new RequestValidator();
    Response res = validator.ValidateRequest(req);

    // Step 4: Serialize and send back response
    string jsonResponse = JsonSerializer.Serialize(res);
    byte[] responseBytes = Encoding.UTF8.GetBytes(jsonResponse);
    stream.Write(responseBytes, 0, responseBytes.Length);

    Console.WriteLine("[SERVER] Sent response:");
    Console.WriteLine(jsonResponse);

    // Step 5: Close connection
    client.Close();
}