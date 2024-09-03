// Import packages
using System.ComponentModel;
using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.Connectors.OpenAI;
using SemanticKernelApp;

#pragma warning disable SKEXP0010 

// Create Main function
public class Program
{
    public static void Main(string[] args)
    {
        KernelCreation.InvokePrompt("Check current UTC time and return current weather in Boston city.").Wait();
        KernelCreation.InvokePrompt("Who invented C# ?").Wait();

        // Output:
        // Auto Function Calling execution result: The current UTC time is Sat, 06 Jul 2024 02:11:16 GMT. The weather right now in Boston is 61 degrees and rainy.
    }
}

// // Create a kernel with Ollama3.1 chat completion
// var kernel = Kernel.CreateBuilder().AddOpenAIChatCompletion(modelId: "llama3.1", apiKey: null, endpoint: new Uri("http://localhost:11434")).Build();

// // Initiate a back-and-forth chat
// Console.Write("llama 3.1: Hello how can I help you today ?" + Environment.NewLine);

// string userInput = string.Empty;
// do
// {
//     // Collect user input
//     Console.Write("You: ");
//     userInput = Console.ReadLine() ?? string.Empty;

//     try
//     {
//         // Generate a response
//         var response = await kernel.InvokePromptAsync(userInput ?? string.Empty);
//         Console.WriteLine("llama 3.1: " + response);
//     }
//     catch (Exception ex)
//     {
//         Console.WriteLine("llama 3.1: " + ex.Message);
//     }
// } while (true);

