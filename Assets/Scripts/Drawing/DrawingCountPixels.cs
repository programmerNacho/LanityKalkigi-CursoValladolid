using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawingCountPixels : MonoBehaviour
{
    public int HowPixelsInDraw(Texture2D original)
    {
        int pixelsNum = 0;

        int pixelWidths = original.width;
        int pixelHeights = original.height;

        for (int i = 0; i < pixelWidths; i++)
        {
            for (int j = 0; j < pixelHeights; j++)
            {
                if (original.GetPixel(i, j) != Color.clear)
                {
                pixelsNum++;                   
                }
            }
        }

        return pixelsNum;
    }

}
