using System;
using System.Collections.Generic;
using System.Linq;

public class User
{
    public string UserName { get; set; }
    public List<Message> ReceivedMessages { get; set; }
}

public class Message
{
    public string Sender { get; set; }
    public string  Content { get; set; }
}

public class Messages
{
    static string sender = string.Empty;
    static string recipient = string.Empty;
    static string content = string.Empty;

    static List<User> usersHystory = new List<User>();
    static List<string> sendFromFirst = new List<string>();
    static List<string> sendFromSecond = new List<string>();

    public static void Main()
    {
        ReadNextMessageHistoryFrom(Console.ReadLine());
        TakeAllMessagesBetwin(Console.ReadLine());
        StartPrintignMessages();
    }

    static void StartPrintignMessages()
    {
        var iterations = Math.Max(sendFromFirst.Count, sendFromSecond.Count);
        if (iterations == 0)
        {
            Console.WriteLine("No messages");
            return;
        }
        for (int i = 0; i < iterations; i++)
        {
            if (i < sendFromFirst.Count)
            {
                Console.WriteLine($"{sender}: {sendFromFirst[i]}");
            }
            if (i < sendFromSecond.Count)
            {
                Console.WriteLine($"{sendFromSecond[i]} :{recipient}");
            }
        }
    }

    static void TakeAllMessagesBetwin(string users)
    {
        SplitAndParseCurrent(users);
        if (usersHystory.Any(x => x.UserName == sender && usersHystory.Any(y => y.UserName == recipient)))
        {
            sendFromFirst = AddAllMessages(sender, recipient);
            sendFromSecond = AddAllMessages(recipient, sender);
        }
    }

    static List<string> AddAllMessages(string first, string second)
    {
        var messages = new List<string>();
        foreach (var item in usersHystory.Where(x => x.UserName == second))
        {
            if (item.ReceivedMessages.Any(x => x.Sender == first))
            {
                var current = item.ReceivedMessages.Where(x => x.Sender == first).ToList();
                foreach (var message in current)
                {
                    messages.Add(message.Content);
                }
            }
        }
        return messages;
    }

    static void ReadNextMessageHistoryFrom(string input)
    {
        if (input != "exit")
        {
            SplitAndParseCurrent(input);
            ReadNextMessageHistoryFrom(Console.ReadLine());
        }
        else return;
    }

    static void SplitAndParseCurrent(string input)
    {
        var splited = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        if (splited.Length == 2)
        {
            if (splited[0] == "register")
            {
                recipient = splited[1];
                AddUser();
            }
            else
            {
                sender = splited[0];
                recipient = splited[1];
            }
        }
        else
        {
            sender = splited[0];
            recipient = splited[2];
            content = splited[3];
            if (usersHystory.Any(x => x.UserName == sender) &&
                usersHystory.Any(x => x.UserName == recipient))
                AddMessage();
            else return;
        }
    }

    static void AddUser()
    {
        var newUser = new User();
        newUser.UserName = recipient;
        newUser.ReceivedMessages = new List<Message>();
        usersHystory.Add(newUser);
    }

    private static void AddMessage()
    {
        var newMessage = new Message();
        newMessage.Sender = sender;
        newMessage.Content = content;
        var currentRecipient = usersHystory.Where(x => x.UserName == recipient).FirstOrDefault();
        currentRecipient.ReceivedMessages.Add(newMessage);
    }
}
