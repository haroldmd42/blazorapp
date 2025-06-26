using System.Net.Http.Json;
using System.Text.Json;

namespace blazorapp;
public class CategoryService : ICategoryService
{
    private readonly HttpClient client;
    private readonly JsonSerializerOptions options;

    public CategoryService(HttpClient httpClient)
    {
        client = httpClient;
        options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };
    }

    public async Task<List<Category>> Get()
    {
        var response = await client.GetAsync("v1/categories");

        if (!response.IsSuccessStatusCode)
        {
            return new List<Category>();
        }

        var result = await JsonSerializer.DeserializeAsync<List<Category>>(
            await response.Content.ReadAsStreamAsync(),
            options
        );

        return result ?? new List<Category>(); // ← Evita retornar null
    }
}
public interface ICategoryService
{
    Task<List<Category>> Get();
}