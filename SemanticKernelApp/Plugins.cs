using System;
using System.ComponentModel;
using Microsoft.SemanticKernel;

namespace SemanticKernelApp;

public sealed class TimePlugin
{
    [KernelFunction]
    [Description("Retrieves the current time in UTC")]
    public string GetCurrentUtcTime() => DateTime.UtcNow.ToString("R");
}

public sealed class WeatherPlugin
{
    [KernelFunction]
    [Description("Gets the current weather for the specified city")]
    public string GetWeatherForCity(string cityName) =>
        cityName switch
        {
            "Boston" => "61 and rainy",
            "London" => "55 and cloudy",
            "Miami" => "80 and sunny",
            "Paris" => "60 and rainy",
            "Tokyo" => "50 and sunny",
            "Sydney" => "75 and sunny",
            "Tel Aviv" => "80 and sunny",
            _ => "31 and snowing",
        };
}