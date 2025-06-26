using System.Text.Json;
using System.Net.Http.Json;
namespace blazorapp;
public class UserService : IUserService
{
    private readonly HttpClient client;
    private readonly JsonSerializerOptions options;

    public UserService(HttpClient httpClient)
    {
        client = httpClient;
        options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };
    }

    public async Task<List<User>> Get()
    {
        var response = await client.GetAsync("v1/users");

        if (!response.IsSuccessStatusCode)
        {
            return new List<User>();
        }

        var result = await JsonSerializer.DeserializeAsync<List<User>>(
            await response.Content.ReadAsStreamAsync(),
            options
        );

        return result ?? new List<User>(); // Evita retornar null
    }
}

public interface IUserService
{
    Task<List<User>> Get();
}