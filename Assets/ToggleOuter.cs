using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleOuter : MonoBehaviour
{
    public Toggle[] toggles;
    // Start is called before the first frame update
    public void Toggle()
    {
        int count = 0;
        for (int i=0; i<6; i++)
        {
            if (toggles[i].isOn)
                count++;
        }

        if (count > 0)
        {
            for (int i = 0; i < 6; i++)
            {
                toggles[i].isOn = false;
            }
        }
        else
        {
            for (int i = 0; i < 6; i++)
            {
                toggles[i].isOn = true;
            }
        }
    }
}
