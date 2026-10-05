using System.Net;
using System.Text.Json;
using NUnit.Framework;
using ApiTestFramework.Helpers;

namespace ApiTestFramework.Tests;

public class TodoApiTests {
    private HttpClient http = null!;
    private ApiClient api = null!;

    [SetUp]
    public void Setup(){
        http=new HttpClient{BaseAddress=new Uri("https://jsonplaceholder.typicode.com/")};
        api=new ApiClient(http);
    }

    [TearDown]
    public void TearDown()=>http.Dispose();

    [Test]
    public async Task GetTodo_ShouldReturnSuccessAndExpectedFields(){
        var result=await api.GetAsync("todos/1");
        Assert.That(result.Status,Is.EqualTo(HttpStatusCode.OK));
        using var doc=JsonDocument.Parse(result.Body);
        Assert.That(doc.RootElement.GetProperty("id").GetInt32(),Is.EqualTo(1));
        Assert.That(doc.RootElement.GetProperty("title").GetString(),Is.Not.Empty);
    }

    [Test]
    public async Task GetUnknownTodo_ShouldReturnNotFound(){
        var result=await api.GetAsync("todos/999999");
        Assert.That(result.Status,Is.EqualTo(HttpStatusCode.NotFound));
    }

    [Test]
    public async Task PostTodo_ShouldReturnCreated(){
        var payload=new {userId=1,title="Regression test item",completed=false};
        var result=await api.PostAsync("todos",payload);
        Assert.That(result.Status,Is.EqualTo(HttpStatusCode.Created));
        using var doc=JsonDocument.Parse(result.Body);
        Assert.That(doc.RootElement.GetProperty("title").GetString(),Is.EqualTo("Regression test item"));
    }
}
