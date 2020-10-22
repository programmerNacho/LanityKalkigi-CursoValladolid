using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawingComparer : MonoBehaviour
{
    public bool IsDrawingComplete(Texture2D original, Texture2D painted, Color paintedColor)
    {
        if(painted.width == original.width && painted.height == original.height)
        {
            int pixelWidths = painted.width;
            int pixelHeights = painted.height;

            for (int i = 0; i < pixelWidths; i++)
            {
                for (int j = 0; j < pixelHeights; j++)
                {
                    if(original.GetPixel(i, j) != Color.black)
                    {
                        if(painted.GetPixel(i, j) != paintedColor)
                        {
                            return false;
                        }
                    }
                }
            }
        }

        return true;
    }
}
