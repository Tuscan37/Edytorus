using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Server;
using System.Net;
using System.Net.Http.Headers;
using System.Drawing;
using System.Web.Helpers;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors();
var app = builder.Build();
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseCors( options => options.AllowAnyOrigin() );
app.MapGet("/", () => "Hello World!");

string apiUrl = "https://api.mojang.com/";
string sessionServerUrl = "https://sessionserver.mojang.com/";

app.MapGet("/getSkinBase64/{username}", async (string username) =>
{
    string? uid = null;
    using var client = new HttpClient();
    {
        var json = await client.GetStringAsync(apiUrl + "users/profiles/minecraft/" +username);
        dynamic jResponse = JsonConvert.DeserializeObject<dynamic>(json);
        uid = jResponse.id;
    }
    if(uid == null) { /* Do error handling */}

    string? skinUrl = null;
    {
        var json = await client.GetStringAsync(sessionServerUrl + "session/minecraft/profile/" + uid);
        dynamic jResponse = JsonConvert.DeserializeObject<dynamic>(json);
        string base64 = jResponse.properties[0].value;
        string valueJson = Utility.Base64Decode(base64);
        dynamic jValue = JsonConvert.DeserializeObject<dynamic>(valueJson);
        skinUrl = jValue.textures.SKIN.url;
    }
    if (skinUrl == null) { /* Do error handling */ }

    {
        var bytes = await client.GetByteArrayAsync(skinUrl);
        var base64 = Convert.ToBase64String(bytes);
        return base64;

    }
});
app.Run();
