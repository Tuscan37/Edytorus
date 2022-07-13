using System;
using UnityEngine;
using UnityEngine.UI;
using Cysharp.Threading.Tasks;
using UnityEngine.Networking;

public class ExampleScript : MonoBehaviour
{
    [SerializeField]
    private GameObject plane;
    [SerializeField]
    private Text text;
    [SerializeField]
    private GameObject panel;

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
        //var bytes = await GetSkinBytesFromUsername("Kubelson");
        //var base64 = await MojangAPI.GetSkin64FromSkinUrl("http://textures.minecraft.net/texture/c4b177f5b37d6e275dcf1d596b8795771e7424662a8b90c3096b8d238f90e155");
        //var bytes = (await UnityWebRequest.Get("http://textures.minecraft.net/texture/c4b177f5b37d6e275dcf1d596b8795771e7424662a8b90c3096b8d238f90e155").SendWebRequest()).downloadHandler.data;
        var base64 = (await UnityWebRequest.Get("https://localhost:6900/getSkin/Kubelson").SendWebRequest()).downloadHandler.text;
        var bytes = Convert.FromBase64String(base64);
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
            bytes = await Server.GetSkin(text.text);
        }
        catch(Exception e)
        {
            Debug.Log(e.Message);
            panel.SetActive(false);
            return ;
        }
        
        var tx = ConvertSkinToTexture(bytes);
        ApplyTexture(tx);
        panel.SetActive(false);
    }


}
