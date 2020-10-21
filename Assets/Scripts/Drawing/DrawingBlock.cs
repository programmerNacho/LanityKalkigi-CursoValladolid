using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawingBlock : MonoBehaviour
{
    [SerializeField]
    private List<Texture2D> smallDrawings;
    [SerializeField]
    private List<Texture2D> mediumDrawings;
    [SerializeField]
    private List<Texture2D> largeDrawings;

    public Texture2D GiveMeADrawing(PlayerPaint.TextureSizes size)
    {
        Texture2D texture = null;

        switch (size)
        {
            case PlayerPaint.TextureSizes.Small:
                texture = smallDrawings[Random.Range(0, smallDrawings.Count)];
                smallDrawings.Remove(texture);
                break;
            case PlayerPaint.TextureSizes.Medium:
                texture = mediumDrawings[Random.Range(0, smallDrawings.Count)];
                mediumDrawings.Remove(texture);
                break;
            case PlayerPaint.TextureSizes.Large:
                texture = largeDrawings[Random.Range(0, smallDrawings.Count)];
                mediumDrawings.Remove(texture);
                break;
        }

        return texture;
    }
}
