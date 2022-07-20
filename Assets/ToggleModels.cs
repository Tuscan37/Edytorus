using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleModels : MonoBehaviour
{
    public GameObject steve;
    public GameObject alex;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    bool isSlim;
    void Update()
    {
        if (isSlim)
        { alex.SetActive(true); steve.SetActive(false); }
        else
        { alex.SetActive(false); steve.SetActive(true); }
    }

    public void Toggle()
    {
            isSlim = !isSlim;

    }
}
