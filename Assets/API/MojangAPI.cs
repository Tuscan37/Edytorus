using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using UnityEngine;
using Newtonsoft.Json;
using System.Text;

public static class MojangAPI
{
    private static readonly string url = "https://api.mojang.com/";
    private static readonly string sessionServer = "https://sessionserver.mojang.com/";

    public static async Task<string> GetUidFromUsername(string username)
    {

        using var client = new HttpClient();
        client.BaseAddress = new Uri(url + "users/profiles/minecraft/");
        var json = await client.GetStringAsync(username);
        dynamic jResponse = JsonConvert.DeserializeObject<dynamic>(json);
        return jResponse.id;
    }
    public static async Task<string> GetSkinUrlFromUid(string uid)
    {
        using var client = new HttpClient();
        client.BaseAddress = new Uri(sessionServer + "session/minecraft/profile/");
        var json = await client.GetStringAsync(uid);
        dynamic jResponse = JsonConvert.DeserializeObject<dynamic>(json);
        string base64String = jResponse.properties[0].value;
        var json2 = Encoding.Default.GetString(Convert.FromBase64String(base64String));
        dynamic jResponse2 = JsonConvert.DeserializeObject<dynamic>(json2);
        return jResponse2.textures.SKIN.url;
    }
    public static async Task<byte[]> GetSkinBytesFromSkinUrl(string url)
    {
        using var client = new HttpClient();
        client.BaseAddress = new Uri(url);
        var bytes = await client.GetByteArrayAsync("");
        return bytes;
    }
}
