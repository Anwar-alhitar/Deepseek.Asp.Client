using Deepseek.AspClient.Models.Request;
using Deepseek.AspClient.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deepseek.AspClient.Client
{
    internal interface IDeepseekClient
    {
        Task<DeepseekResponse> GenerateResponseAsync(DeepseekRequest request);
        Task<DeepseekResponse> GenerateResponseAsync(string prompt);
    }
}
