using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class UsernameTextScript : MonoBehaviour
{
    private static UsernameTextScript instance;
    public static UsernameTextScript GetInstance()
    {
        return instance;
    }

    private Text text;
    void Start()
    {
        UsernameTextScript.instance = this;
        text = GetComponent<Text>();
        
    }
    public Text GetText()
    {
        return text;
    }


}
