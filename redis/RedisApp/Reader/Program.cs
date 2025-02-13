using StackExchange.Redis;

Console.WriteLine("Reader!");

var cancellation = new CancellationTokenSource();

Console.CancelKeyPress += (sender, e) =>
{
    e.Cancel = true;
    cancellation.Cancel();
    Console.WriteLine("Ctrl+C pressed. Exiting gracefully...");
};

var connectionString = "localhost:6379";
ConnectionMultiplexer redis = ConnectionMultiplexer.Connect(connectionString);
IDatabase db = redis.GetDatabase();

string stream = "card";

string? lastId = "0";
try
{
    while (!cancellation.Token.IsCancellationRequested)
    {
        var entries = db.StreamRead(stream, lastId, 10);

        Console.WriteLine("Shopping cart contents:");
        foreach (var entry in entries)
        {
            lastId = entry.Id;
            foreach (var field in entry.Values)
            {
                Console.WriteLine($"{field.Name}: {field.Value}");
            }
        }

        await Task.Delay(5000);
    }
}
catch (OperationCanceledException)
{
    Console.WriteLine("Reader operation canceled.");
}
finally
{
    cancellation.Dispose();
    Console.WriteLine("Reader application terminated.");
}