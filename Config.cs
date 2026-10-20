public static class Config
{
    // All secrets are read from environment variables; nothing sensitive is stored in source control.
    public static string TelegramBotToken =>
        Environment.GetEnvironmentVariable("TELEGRAM_BOT_TOKEN")
        ?? throw new InvalidOperationException("TELEGRAM_BOT_TOKEN environment variable is not set.");

    public static long ChatId =>
        long.TryParse(Environment.GetEnvironmentVariable("TELEGRAM_CHAT_ID"), out var id)
            ? id
            : throw new InvalidOperationException("TELEGRAM_CHAT_ID environment variable is not set or invalid.");

    public static string ConnectionString =>
        Environment.GetEnvironmentVariable("SIGNAL_BOT_CONNECTION_STRING")
        ?? @"Server=(localdb)\MSSQLLocalDB;Database=CryptoSignalBot;Trusted_Connection=True;";
}
