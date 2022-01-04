using Discord;
using Discord.WebSocket;

Console.WriteLine("DiscordBotV1 starting...");

var client = new DiscordSocketClient();

client.Log += LogAsync;
client.Ready += ReadyAsync;
client.MessageReceived += MessageReceivedAsync;

var token = Environment.GetEnvironmentVariable("discord-bot-v1-token");
Console.WriteLine($"Token: {token}");


await client.LoginAsync(TokenType.Bot, token);
await client.StartAsync();

await Task.Delay(Timeout.Infinite);



async Task MessageReceivedAsync(SocketMessage message) 
{
    //The bot should never respond to itself.
    if (message.Author.Id == client.CurrentUser.Id)
        return;

     if (message.Content == "!ping")
    await message.Channel.SendMessageAsync("pong!");
}


Task LogAsync(LogMessage log)
{
    Console.WriteLine(log.ToString());
    Console.WriteLine("nu loggar jag");
    return Task.CompletedTask;
}

Task ReadyAsync()
{
    Console.WriteLine($"{client.CurrentUser} is connected!");

    return Task.CompletedTask;
}