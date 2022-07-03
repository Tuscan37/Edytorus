using Microsoft.AspNetCore.ResponseCompression;
using Newtonsoft.Json;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddHttpClient();
builder.Services.AddScoped<HttpClient>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();

app.MapGet("/uuid", async (string username) =>
{
    using var client = new HttpClient();
    //global::System.Console.WriteLine("username");
    client.BaseAddress = new Uri("https://api.mojang.com/users/profiles/minecraft/");
    var task = client.GetStringAsync(username);
    var resp = task.Result;
    var obj = JsonConvert.DeserializeObject<MCSkinEditor.Shared.UsernameId>(resp);
    if (obj == null || obj.Id == null) return "Account not found";
    return obj.Id;


});

app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
