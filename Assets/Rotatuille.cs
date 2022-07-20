using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rotatuille : MonoBehaviour
{
    public GameObject pivotus;
    public Slider sliderX;
    public Slider sliderY;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        pivotus.transform.rotation = Quaternion.Euler(sliderX.value, sliderY.value, 0);
    }
}
