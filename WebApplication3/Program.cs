using WebApplication3;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

ChatHistory chatHistory = new ChatHistory();
chatHistory.AddMessage(new ChatMessage("User", "Siema!"));
chatHistory.AddMessage(new ChatMessage("Bot", "co tam"));
chatHistory.AddMessage(new ChatMessage("User", "dobrze"));


app.MapGet("/", () => "Hello World!");


app.MapGet("/chat", (DateTime? timestamp) =>
{
    if (timestamp == null)
        return chatHistory.GetLast(10);
    //tutaj zwracamy histori� czatu
    return chatHistory.GetMessagesAfter(timestamp ?? DateTime.Now);
});

app.Run();
