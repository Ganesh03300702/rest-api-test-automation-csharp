using System.Net;
using System.Text.Json;

namespace ApiTestFramework.Helpers;

public class ApiClient {
    private readonly HttpClient client;
    public ApiClient(HttpClient client){this.client=client;}
    public async Task<(HttpStatusCode Status, string Body)> GetAsync(string path){
        var response=await client.GetAsync(path);
        return (response.StatusCode,await response.Content.ReadAsStringAsync());
    }
    public async Task<(HttpStatusCode Status, string Body)> PostAsync(string path, object payload){
        var json=JsonSerializer.Serialize(payload);
        var response=await client.PostAsync(path,new StringContent(json,System.Text.Encoding.UTF8,"application/json"));
        return (response.StatusCode,await response.Content.ReadAsStringAsync());
    }
}
