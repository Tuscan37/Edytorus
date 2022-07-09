using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class ExampleScript : MonoBehaviour
{
    [SerializeField]
    private GameObject plane;
    [SerializeField]
    private Text text;
    [SerializeField]
    private GameObject panel;

    private async Task<byte[]> GetSkinBytesFromUsername(string username)
    {
        var uid = await MojangAPI.GetUidFromUsername(username);
        var skinUrl = await MojangAPI.GetSkinUrlFromUid(uid);
        var bytes = await MojangAPI.GetSkinBytesFromSkinUrl(skinUrl);
        return bytes;
    }
    private Texture2D ConvertSkinToTexture(byte[] bytes)
    {
        Texture2D tx = new Texture2D(1, 1);
        ImageConversion.LoadImage(tx, bytes);
        // Bardzo wa¿ne!
        tx.filterMode = FilterMode.Point;
        return tx;
    }
    private void ApplyTexture(Texture2D tx)
    {
        var mat = plane.GetComponent<MeshRenderer>().material;
        mat.mainTexture = tx;
    }
    private async void Run()
    {
        var bytes = await GetSkinBytesFromUsername("Kubelson");
        var tx = ConvertSkinToTexture(bytes); 
        ApplyTexture(tx);
    }
    void Start()
    {
        //Run();
    }

    public async void ButtonAction()
    {
        if(text == null || text.text == null || text.text == "")
        {
            Debug.Log("problem z input text");
            return;
        }
        panel.SetActive(true);
        byte[] bytes = null;
        try
        {
            bytes = await GetSkinBytesFromUsername(text.text);
        }
        catch(Exception e)
        {
            Debug.Log("Nie znaleziono u¿ytkownika");
            panel.SetActive(false);
            return ;
        }
        
        var tx = ConvertSkinToTexture(bytes);
        ApplyTexture(tx);
        panel.SetActive(false);
    }


}
