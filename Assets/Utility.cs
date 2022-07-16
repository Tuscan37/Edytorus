using UnityEngine;

public static class Utility
{
    public static Texture2D ConvertSkinToTexture(byte[] bytes)
    {
        Texture2D tx = new Texture2D(1, 1);
        ImageConversion.LoadImage(tx, bytes);
        // Bardzo wa¿ne!
        tx.filterMode = FilterMode.Point;
        return tx;
    }
}
