using TicketTgBot.Bot;

BotInitializer bot = new BotInitializer();
bot.Start();
Console.WriteLine("БОТ ЗАПУЩЕН");

TaskCompletionSource tcs = new TaskCompletionSource();

AppDomain.CurrentDomain.ProcessExit += (_, _) =>
{
    bot.Stop();
    Console.WriteLine("БОТ ОСТАНОВЛЕН");
    tcs.SetResult();
};

Console.WriteLine("НАЖМИТЕ ctrl+c ДЛЯ ОСТАНОВКИ БОТА");

await tcs.Task;

Console.WriteLine("ПРОГРАММА ЗАВЕРШЕНА");