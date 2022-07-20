using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetTextureFromPlane : MonoBehaviour
{
    public MeshRenderer rendererPlane;
    public MeshRenderer selfRenderer;
    // Start is called before the first frame update
    void Start()
    {
        selfRenderer = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

        selfRenderer.material = rendererPlane.material;
    }
}
