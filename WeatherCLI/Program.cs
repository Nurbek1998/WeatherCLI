using Spectre.Console;
using System.Text.Json;

while (true)
{
    var city = AnsiConsole.Prompt(
    new SelectionPrompt<string>()
        .Title("[green]Shaharni tanlang:[/]")
        .PageSize(10)
        .MoreChoicesText("[grey](Ko'proq shaharni ochish uchun yuqoriga va pastga harakatlaning)[/]")
        .AddChoices(new[] {
            "Tashkent", "Dubai", "London",
            "Karshi", "Samarkand",
            "Moscow", "Japan", "Paris", "Other","Exit"
        }));

    if (city == "Exit")
        Environment.Exit(0);

    else if (city == "Other")
    {
        AnsiConsole.Markup("[dodgerblue1]Shahar nomini kiriting:[/] ");
        city = Console.ReadLine().Trim();
    }

    string apiKey = GetApiKey();

    await DisplayWeatherAsync(city, apiKey);
}

static string GetApiKey()
{
    string configText = File.ReadAllText("appsettings.json");
    using var configDoc = JsonDocument.Parse(configText);
    return configDoc.RootElement.GetProperty("OpenWeather").GetProperty("ApiKey").GetString()!;
}

static async Task DisplayWeatherAsync(string city, string apiKey)
{
    using HttpClient client = new();
    string url = $"https://api.openweathermap.org/data/2.5/weather?q={city}&appid={apiKey}&units=metric";

    var response = await client.GetAsync(url); ;

    if (response.IsSuccessStatusCode)
    {
        var jsonString = await response.Content.ReadAsStringAsync();

        using var jsonDoc = JsonDocument.Parse(jsonString);
        var formattedJson = JsonSerializer.Serialize(jsonDoc, new JsonSerializerOptions { WriteIndented = true });
        var root = jsonDoc.RootElement;

        double temp = root.GetProperty("main").GetProperty("temp").GetDouble();
        string weather = root.GetProperty("weather")[0].GetProperty("main").GetString();
        double wind = root.GetProperty("wind").GetProperty("speed").GetDouble();

        Console.WriteLine($"Shahar: {city}");
        Console.WriteLine($"Temperatura: {temp}°C");
        Console.WriteLine($"Havo holati: {weather}");
        Console.WriteLine($"Shamol tezligi: {wind} m/s");
        Console.WriteLine();
    }

    else
    {
        Console.WriteLine($"Xatolik: Shahar topilmadi");
        await Console.Out.WriteLineAsync();
    }

}

