using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types.Enums;

namespace TicketTgBot.Bot;

public class BotInitializer
{
    private TelegramBotClient _botClient;
    private CancellationTokenSource _cancellationTokenSource;

    public BotInitializer()
    {
        _botClient = new TelegramBotClient("6761910512:AAGcbi2n5vLc9WCwrVYU2ZRV0bJyiHhswpg");
        _cancellationTokenSource = new CancellationTokenSource();
    }
    
    public void Start()
    {
        ReceiverOptions receiverOptions = new ReceiverOptions
        {
            AllowedUpdates = Array.Empty<UpdateType>()
        };

        BotRequestHandlers botRequestHandlers = new BotRequestHandlers();

        _botClient.StartReceiving(
            botRequestHandlers.HandleUpdateAsync,
            botRequestHandlers.HandlePollingErrorAsync,
            receiverOptions,
            _cancellationTokenSource.Token
        );
        
    }

    public void Stop()
    {
        _cancellationTokenSource.Cancel();
    }
}