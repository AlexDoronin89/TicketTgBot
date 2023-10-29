namespace TicketTgBot.Bot;

public class TransmittedData
{
    public string State { get; set; }
    public DataStorage DataStorage { get; set; }
    public long ChatId { get; }

    public TransmittedData(long chatId)
    {
        ChatId = chatId;
        State = States.WaitingCommandStart;
        DataStorage = new DataStorage();
    }
}