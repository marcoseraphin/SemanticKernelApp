using System;
using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.Connectors.OpenAI;

namespace SemanticKernelApp;

#pragma warning disable SKEXP0010 

public class KernelCreation
{

    public static Kernel? GetKernel()
    {
        // Kernel kernel = Kernel
        //     .CreateBuilder()
        //     .AddOpenAIChatCompletion(modelId: "llama3.1", apiKey: null, endpoint: new Uri("http://localhost:11434"))
        //     .Build();


        string apiKey = Environment.GetEnvironmentVariable("OPENAI_API_KEY") ?? string.Empty;

        if (string.IsNullOrEmpty(apiKey))
            return null;

        Kernel kernel = Kernel
            .CreateBuilder()
            .AddOpenAIChatCompletion(modelId: "gpt-4", apiKey: apiKey, httpClient: new System.Net.Http.HttpClient())
            .Build();

        // Import sample plugins.
        kernel.ImportPluginFromType<TimePlugin>();
        kernel.ImportPluginFromType<WeatherPlugin>();

        return kernel;
    }

    public static async Task<bool> InvokePrompt(string prompt)
    {
        // Get kernel
        Kernel? kernel = GetKernel();
        if (kernel == null)
            return false;

        // Enable Automatic Function Calling
        OpenAIPromptExecutionSettings executionSettings = new() { ToolCallBehavior = ToolCallBehavior.AutoInvokeKernelFunctions };

        // Generate and execute a plan
        FunctionResult result = await kernel.InvokePromptAsync(prompt, new(executionSettings));

        Console.WriteLine($"Auto Function Calling execution result: {result}");

        // Output:
        // Auto Function Calling execution result: The current UTC time is Sat, 06 Jul 2024 02:11:16 GMT. The weather right now in Boston is 61 degrees and rainy.

        return true;
    }

}
