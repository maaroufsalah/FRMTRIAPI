using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Constants
{
    public class MessageUI
    {
        public string Text { get; set; }
        public string Icon { get; set; }
        public string Type { get; set; }
        public bool Success { get; set; }

        public MessageUI() { }
        public MessageUI(string text, string icon, string type) => (Text, Icon, Type) = (text, icon, type);
        public MessageUI(string text, string icon, string type, bool success) => (Text, Icon, Type, Success) = (text, icon, type, success);
    }

}
