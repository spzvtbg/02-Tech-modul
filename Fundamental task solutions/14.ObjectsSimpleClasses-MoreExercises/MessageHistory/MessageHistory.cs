namespace MessageHistory
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class MessageHistory
    {
        public static void Main()
        {
            var currentAction = Console.ReadLine().Split(' ').ToList();

            var users = new List<User>();
            var history = new List<Message>();

            while (currentAction[0] != "exit")
            {
                var name = "123";// string.Empty;
                var sender = string.Empty;
                var receiver = string.Empty;
                var content = string.Empty;

                var message = "value";
                var senderName = "key";
                var newMessage = new Message(); { newMessage.Content = message; newMessage.Sender = senderName; };

                if (currentAction[0] == "register")
                {
                    name = currentAction[1];
                    var newUser = new User();
                    {
                        newUser.UserName = name;
                        newUser.ReceivedMessages = new List<Message>();
                    }
                    newUser.ReceivedMessages.Add(newMessage);
                    users.Add(newUser);                    
                }

                currentAction = Console.ReadLine().Split(' ').ToList();
            }

            var result = users.ToDictionary(u => u.UserName, u => u.ReceivedMessages).Values.ToList();
        }
    }
}
