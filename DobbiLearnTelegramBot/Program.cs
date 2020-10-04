using DobbiLearnTelegramBot.Command;
using DobbiLearnTelegramBot.Command.Commands;
using System;
using System.Collections.Generic;
using Telegram.Bot;
using Telegram.Bot.Args;

namespace DobbiLearnTelegramBot
{
    class Program
    {
        private static TelegramBotClient client; //создаем глобальную переменную client
        private static List<Command.Command> commands; //создаем глобальную переменную список команд
        static void Main(string[] args)
        {
            client = new TelegramBotClient(BotSettings.Token) { Timeout = TimeSpan.FromSeconds(5) }; //инициализируем клиен телеграма
            commands = new List<Command.Command>(); //инициализируем список команд
            commands.Add(new GetMyIdCommand()); //добавляем в список команду
            commands.Add(new GetMyAccCommand()); //добавляем в список команду

            client.StartReceiving(); //начинаем прослушку
            Console.WriteLine("Hello World!");
            client.OnMessage += OnMessageReceived; //подписываемся на ивент сообщений
            Console.ReadLine();
            client.StopReceiving(); 
        }

        private static async void OnMessageReceived(object sender, MessageEventArgs e) //метод, который вызываетя при ивенте сообщений
        {
            if(e.Message.Text != null) //проверяем текст сообщения на null
            {
                var message = e.Message;
                foreach(var comm in commands) //проходимся по командам
                {
                    if (comm.Contains(message.Text)) //если совпадает
                    {
                        comm.Execute(message, client); //вызываем метод
                        break; //останавливаем цыкл
                    } 
                }
            }
        }
    }
}
