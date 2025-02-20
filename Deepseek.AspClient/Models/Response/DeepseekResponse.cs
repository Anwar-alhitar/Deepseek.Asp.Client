using Deepseek.AspClient.Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deepseek.AspClient.Models.Response
{
    public class DeepseekResponse
    {
        public string? Id { get; set; }
        public  List<Choice>? Choices { get; set; }
        public Usage? Usage { get; set; }
    }
    public class Choice
    {
        public Message? Message { get; set; }
        public string? FinishReason { get; set; }
    }

    public class Usage
    {
        public int PromptTokens { get; set; }
        public int CompletionTokens { get; set; }
        public int TotalTokens { get; set; }
    }

    
}
