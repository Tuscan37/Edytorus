using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultSkins : MonoBehaviour 
{
    private static DefaultSkins instance;
    public static DefaultSkins GetInstance()
    {
        return instance;
    }
    private Texture2D Clone(Texture2D original)
    {
        Texture2D copyTexture = new Texture2D(original.width, original.height);
        copyTexture.SetPixels(original.GetPixels());
        copyTexture.Apply();
        copyTexture.filterMode = FilterMode.Point;
        return copyTexture;
    }

    private Texture2D steve;
    private Texture2D alex;

    public Texture2D Steve { get { return Clone(steve); } }
    public Texture2D Alex { get { return Clone(alex); } }
    public void Start()
    {
        instance = this;
        steve = Resources.Load("Skins/Steve") as Texture2D;
        alex = Resources.Load("Skins/Alex") as Texture2D;
    }
    

}
