// See https://aka.ms/new-console-template for more information
using Demo.Camunda;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

Console.WriteLine("--- Init Decision ---");

string url = "http://localhost:8080/engine-rest/decision-definition/key/Test1/evaluate";

using (HttpClient client = new HttpClient())
{
    // Configura las cabeceras de la solicitud
    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");

    var variables = new Variables { fooNumber = new Foonumber { type = "integer", value = "3" } };
    var root = new Rootobject { variables = variables };

    var jsonData = JsonSerializer.Serialize(root);

    // Realiza la solicitud HTTP POST
    HttpResponseMessage response = await client.PostAsync(url, new StringContent(jsonData, Encoding.UTF8, "application/json"));

    // Verifica si la solicitud fue exitosa
    if (response.IsSuccessStatusCode)
    {
        string content = await response.Content.ReadAsStringAsync();
        var myResponse = JsonSerializer.Deserialize<IEnumerable<Class1>>(content);        
        Console.WriteLine($"\r\n\tcontent retrieve from ReadAsStringAsync: {content}");
        foreach (var item in myResponse)
        {
            Console.WriteLine($"\r\n\tvalue retrieve from camunda DMN decision: {item.bar.value} \r\n\t");
        }
    }
    else
    {
        Console.WriteLine("Error en la solicitud HTTP. Código de estado: " + response.StatusCode);
    }
}


Console.WriteLine("---  finish Decision ---");