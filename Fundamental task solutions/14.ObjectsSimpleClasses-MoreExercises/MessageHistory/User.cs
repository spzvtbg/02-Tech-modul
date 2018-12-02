using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageHistory
{
    class User
    {
        public string UserName { get; set; }

        public List<Message> ReceivedMessages { get; set; }
    }
}
