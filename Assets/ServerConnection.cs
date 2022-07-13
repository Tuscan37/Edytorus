using Cysharp.Threading.Tasks;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public static class Server
{
    private static readonly string serverUrl = "https://localhost:6900/";
    public static async UniTask<byte[]> GetSkin(string username)
    {
        var base64 = (await UnityWebRequest.Get("https://localhost:6900/getSkinBase64/"+username).SendWebRequest()).downloadHandler.text;
        var bytes = Convert.FromBase64String(base64);
        return bytes;
    }

}
