using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawingDifficultySelector : MonoBehaviour
{
    [SerializeField]
    private DrawingBlock drawingBlock;

    private int roundsCompleted;

    public Texture2D SelectDrawing()
    {
        if(roundsCompleted < 3)
        {
            return drawingBlock.GiveMeADrawing(PlayerPaint.TextureSizes.Small);
        }
        else if(roundsCompleted < 6)
        {
            return drawingBlock.GiveMeADrawing(PlayerPaint.TextureSizes.Medium);
        }
        else
        {
            return drawingBlock.GiveMeADrawing(PlayerPaint.TextureSizes.Large);
        }
    }
}
