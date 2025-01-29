using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deepseek.AspClient.Models.Request
{
    public class DeepseekRequest
    {
        public List<Message> Messages { get; set; } = new();
        public string Model { get; set; } = "deepseek-chat";
        public double Temperature { get; set; } = 0.7;
        public int MaxTokens { get; set; } = 500;
    }
    public class Message
    {
        public string Role { get; set; } = "user";
        public string Content { get; set; }
    }
}
