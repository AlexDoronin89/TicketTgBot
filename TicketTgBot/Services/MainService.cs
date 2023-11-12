namespace TicketTgBot.Bot;

public class MainService
{
    public BotMessage ProcessCommandStart(string textData, TransmittedData transmittedData)
    {
        if (textData == "/start")
        {
            transmittedData.State = States.WaitingUserName;

            return new BotMessage(
                "Введите имя"
            );
        }
        else
        {
            return new BotMessage(
               "Неопознанная команда! Введите '/start'"
            );
        }

        throw new Exception("Неизвестная ошибка в ProcessCommandStart");
    }
    public BotMessage ProcessUserName(string textData, TransmittedData transmittedData)
    {
        if (textData.Length >= 2)
        {
            transmittedData.State = States.WaitingUserAge;
            transmittedData.DataStorage.AddOrUpdate("UserName", textData);

            return new BotMessage(
                "Введите возраст"
            );
        }
        else
        {
            return new BotMessage(
               "Некорректное имя! Длина имени должна быть не менее 2 символов"
            );
        }

        throw new Exception("Неизвестная ошибка в ProcessUserName");
    }

    public BotMessage ProcessUserAge(string textData, TransmittedData transmittedData)
    {
        if (int.Parse(textData) >= 18)
        {
            transmittedData.State = States.WaitingUserPlace;
            transmittedData.DataStorage.AddOrUpdate("UserAge", int.Parse(textData));

            return new BotMessage(
                "Введите место"
            );
        }
        else
        {
            return new BotMessage(
               "Ты еще мелкий, тебе должно быть не менее 18 лет!"
            );
        }

        throw new Exception("Неизвестная ошибка в ProcessUserAge");
    }
    public BotMessage ProcessUserPlace(string textData, TransmittedData transmittedData)
    {
        if (textData.Length >= 2)
        {
            transmittedData.State = States.WaitingAccept;
            transmittedData.DataStorage.AddOrUpdate("UserPlace", textData);

            return new BotMessage(
                $"Проверьте корректность введенных данных: " +
                $"\n {transmittedData.DataStorage.Get<string>("UserName")}" +
                $"\n {transmittedData.DataStorage.Get<int>("UserAge")}" +
                $"\n {transmittedData.DataStorage.Get<string>("UserPlace")}" +
                $"\n\n Если данные верны, введите /ok, если нет - /error"
            );
        }
        else
        {
            return new BotMessage(
               "Неверно указано место! Минимум 2 символа, например: '1А'"
            );
        }

        throw new Exception("Неизвестная ошибка в ProcessUserPlace");
    }

    public BotMessage ProcessAccept(string textData, TransmittedData transmittedData)
    {
        if (textData == "/ok")
        {
            transmittedData.State = States.WaitingCommandStart;
            transmittedData.DataStorage.Clear();

            return new BotMessage(
                "Вы успешно зарегистрированы, введите /start"
            );
        }
        else if (textData == "/error")
        {
            transmittedData.State = States.WaitingUserName;
            transmittedData.DataStorage.Clear();

            return new BotMessage(
                "Начнём регитсрацию заново\nВведите имя:"
            );
        }
        else
        {
            return new BotMessage(
               "Неопознанная команда!"
            );
        }

        throw new Exception("Неизвестная ошибка в ProcessAccept");
    }
}