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
        private static TelegramBotClient client;
        private static List<Command.Command> commands;
        static void Main(string[] args)
        {
            client = new TelegramBotClient(BotSettings.Token) { Timeout = TimeSpan.FromSeconds(5) };
            commands = new List<Command.Command>();
            commands.Add(new GetMyIdCommand());
            commands.Add(new GetMyAccCommand());

            client.StartReceiving();
            Console.WriteLine("Hello World!");
            client.OnMessage += OnMessageReceived;
            Console.ReadLine();
            client.StopReceiving();
        }

        private static async void OnMessageReceived(object sender, MessageEventArgs e)
        {
            if(e.Message.Text != null)
            {
                var message = e.Message;
                foreach(var comm in commands)
                {
                    if (comm.Contains(message.Text))
                    {
                        comm.Execute(message, client);
                        break;
                    }
                }
            }
        }
    }
}
