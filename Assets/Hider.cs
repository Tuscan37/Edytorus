using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hider : MonoBehaviour
{
    public Toggle[] bools;
    public GameObject[] parts;
    // Start is called before the first frame update
    void Update()
    {
        for (int i = 0; i < 12; i++)
        {
            parts[2 * i].SetActive(bools[i].isOn);
            parts[2 * i + 1].SetActive(bools[i].isOn);
        }
    }
}
