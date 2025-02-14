# Deepseek.ASP.Client
![reerOIP](https://github.com/user-attachments/assets/5e16beb0-993e-47bf-807e-7c8804b313a2)

**Deepseek.ASPClient** is a lightweight ASP.NET wrapper for the Deepseek AI API, designed to simplify AI-driven text processing in .NET applications.

## Features
- ✅ Simple and fluent API
- ✅ Supports Dependency Injection
- ✅ Built-in error handling
- ✅ Uses HttpClient best practices
- ✅ Asynchronous and thread-safe

## Installation
You can install the package via NuGet: 
```sh
dotnet add package Deepseek.ASPClient
```


## Usage Example

```csharp
using Deepseek.ASPClient;

var client = new DeepseekClient("your-api-key");
var response = await client.GenerateResponseAsync("Hello Deepseek!");
Console.WriteLine(response.Choices[0].Message.Content);
```

### Dependency Injection Example (ASP.NET Core)

```csharp
// In Program.cs or Startup.cs
services.AddSingleton<IDeepseekClient>(provider =>
    new DeepseekClient(Configuration["Deepseek:ApiKey"]));

// In a Controller
public class AiController : Controller
{
    private readonly IDeepseekClient _client;

    public AiController(IDeepseekClient client)
    {
        _client = client;
    }

    public async Task<IActionResult> Generate(string prompt)
    {
        try
        {
            var response = await _client.GenerateResponseAsync(prompt);
            return Ok(response.Choices.First().Message.Content);
        }
        catch (DeepseekException ex)
        {
            return StatusCode((int)ex.StatusCode, ex.Message);
        }
    }
}
```

## API Methods
| Method | Description |
|--------|-------------|
| `Task<DeepseekResponse> GenerateResponseAsync(DeepseekRequest request)` | Generates a response based on a structured request. |
| `Task<DeepseekResponse> GenerateResponseAsync(string prompt)` | Generates a response from a simple text prompt. |

## Exception Handling
All API errors are wrapped inside `DeepseekException`. Handle exceptions as follows:

```csharp
try
{
    var response = await client.GenerateResponseAsync("Hello Deepseek!");
    Console.WriteLine(response.Choices[0].Message.Content);
}
catch (DeepseekException ex)
{
    Console.WriteLine($"Error: {ex.Message}");
}
```

## Contributing
We welcome contributions! To contribute:
1. Fork the repository.
2. Create a feature branch (`git checkout -b feature-name`).
3. Commit your changes (`git commit -m "Added new feature"`).
4. Push to the branch (`git push origin feature-name`).
5. Open a Pull Request.

## Reporting Issues
If you encounter any issues, please create an issue on GitHub:
[Report an Issue](https://github.com/Anwar-alhitar/Deepseek.ASP.Client/issues)

## License
This project is licensed under the MIT License. See [LICENSE](LICENSE) for details.

## Author
Created by [Anwar Al-Hitar](https://github.com/Anwar-alhitar).

