using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace DobbiLearnTelegramBot.Command.Commands
{
    public class GetMyAccCommand : Command
    {
        public override string[] Names { get; set; } = new string[] { "getmyacc", "get_my_acc", "мой аккаунт" };

        private Models.User[] users = new Models.User[] {

            new Models.User{TelegramId = 716720991, Age = 14, FirstName = "Roman", LastName = "Dobbikov"},
            new Models.User{TelegramId = 123456434, Age = 29, FirstName = "Mikhail", LastName = "Kuhtin"},
            new Models.User{TelegramId = 546743645, Age = 18, FirstName = "Oleg", LastName = "Serebriakov"},
            new Models.User{TelegramId = 768989768, Age = 86, FirstName = "Tatiana", LastName = "Gorin"}

        };

        public override async void Execute(Message message, TelegramBotClient client)
        {
            foreach(var user in users)
            {
                if(user.TelegramId == message.From.Id)
                {
                    await client.SendTextMessageAsync(message.Chat.Id, $"Информация о вашем аккаунте:");
                    await client.SendTextMessageAsync(message.Chat.Id, $"Имя: {user.FirstName}, Фамилия: {user.LastName}, Возраст: {user.Age}");
                    return;
                }
            }
            await client.SendTextMessageAsync(message.Chat.Id, $"Мы не нашли ваш аккаунт.");
        }
    }
}
