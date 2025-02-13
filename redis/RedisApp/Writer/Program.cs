using StackExchange.Redis;

Console.WriteLine("Writer!");

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

string user = "user123";
int counter = 1;

try
{
    while (!cancellation.Token.IsCancellationRequested)
    {
        string item = $"item {counter}";

        await db.StreamAddAsync(stream, [new("user", user), new("item", item)]);

        Console.WriteLine($"Writing {item} to card.");

        counter += 1;

        await Task.Delay(2000);
    }
}
catch (OperationCanceledException)
{
    Console.WriteLine("Writer operation canceled.");
}
finally
{
    cancellation.Dispose();
    Console.WriteLine("Writer application terminated.");
}