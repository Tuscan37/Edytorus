using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class SkinFromMojangScript : MonoBehaviour
{
    [SerializeField]
    private GameObject panel;
    private Button button;
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(ButtonAction);

    }

    public async void ButtonAction()
    {
        var inst = UsernameTextScript.GetInstance();
        Text text = inst.GetText();
        if (text == null || text.text == null || text.text == "")
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
        catch (Exception e)
        {
            Debug.Log(e.Message);
            panel.SetActive(false);
            return;
        }

        var tx = Utility.ConvertSkinToTexture(bytes);
        SkinPlaneScript.GetInstance().ApplyTexture(tx);
        panel.SetActive(false);
    }
}
