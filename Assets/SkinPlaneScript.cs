using UnityEngine;
[RequireComponent(typeof(MeshRenderer))]
public class SkinPlaneScript : MonoBehaviour
{
    private static SkinPlaneScript instance;
    public static SkinPlaneScript GetInstance()
    {
        return instance;
    }
    private MeshRenderer meshRenderer;
    // Start is called before the first frame update
    void Start()
    {
        SkinPlaneScript.instance = this;
        meshRenderer = GetComponent<MeshRenderer>();
        ApplyTexture(DefaultSkins.GetInstance().Steve);
    }

    public void ApplyTexture(Texture2D tx)
    {
        var mat = meshRenderer.material;
        mat.mainTexture = tx;
        tx.filterMode = FilterMode.Point;
    }
}
