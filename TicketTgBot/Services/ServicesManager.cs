namespace TicketTgBot.Bot;

public class ServicesManager
{
    private Dictionary<string, Func<string, TransmittedData, BotMessage>>
        _methods;

    public ServicesManager()
    {
        MainService mainService = new MainService();

        _methods =
            new Dictionary<string, Func<string, TransmittedData, BotMessage>>();

        _methods[States.WaitingCommandStart] = mainService.ProcessCommandStart;
        _methods[States.WaitingUserName] = mainService.ProcessUserName;
        _methods[States.WaitingUserAge] = mainService.ProcessUserAge;
        _methods[States.WaitingUserPlace] = mainService.ProcessUserPlace;
        _methods[States.WaitingAccept] = mainService.ProcessAccept;
    }

    public BotMessage ProcessBotUpdate(string textData, TransmittedData transmittedData)
    {
        Func<string, TransmittedData, BotMessage> serviceMethod = _methods[transmittedData.State];
        return serviceMethod.Invoke(textData, transmittedData);
    }
}