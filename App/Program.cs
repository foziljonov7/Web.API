Console.WriteLine("Loaded...");
Console.WriteLine("-------------------------------------");
using (var httpClient = new HttpClient())
{
    var response = await httpClient.GetAsync("https://localhost:7178/");

    if (response.IsSuccessStatusCode)
    {
        var content = await response.Content.ReadAsStringAsync();
        Console.WriteLine(content);

        Console.WriteLine("Successfully\n ----------------------------------------------------");
    }
    else
    {
        Console.WriteLine("Failed\n -------------------------------------------------");
    }
}


