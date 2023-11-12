using Telegram.Bot.Types.ReplyMarkups;

namespace TicketTgBot.Bot;

public class BotMessage
{
    public string Text { get; }
    public InlineKeyboardMarkup InlineKeyboardMarkup { get; }

    public BotMessage(string text)
    {
        Text = text;
        InlineKeyboardMarkup = null;
    }

    public BotMessage(string text, InlineKeyboardMarkup inlineKeyboardMarkup)
    {
        Text = text;
        InlineKeyboardMarkup = inlineKeyboardMarkup;
    }
}