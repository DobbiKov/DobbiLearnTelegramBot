using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace DobbiLearnTelegramBot.Command
{
    public abstract class Command
    {
        public abstract string[] Names { get; set; } //массив строк, по котрым можно вызвать команду
        public abstract void Execute(Message message, TelegramBotClient client);

        public bool Contains(string command) //функция, котрая проверяет, соотвествует ли сообщение команде нашей
        {
            foreach (var comm in Names) //проходится по массиву этой команды
            {
                if (command.Contains(comm)) return true; //если соответсвует
            }
            return false; //если не соотвествует
        } 
    }
}
