using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPaint : MonoBehaviour
{
    public enum TextureSizes { Small = 16, Medium = 32, Large = 64 }

    [SerializeField]
    private Transform rayOrigin;
    [SerializeField]
    private LayerMask raycastLayerMask;
    [SerializeField]
    private Renderer paintRenderer;
    [SerializeField]
    private TextureSizes textureSize;
    [SerializeField]
    private Color paintColor;
    [SerializeField]
    private InkContainer inkContainer;
    [SerializeField]
    private DrawingDifficultySelector drawingDifficultySelector;
    [SerializeField]
    private DrawingComparer drawingComparer;
    [SerializeField]
    private NextLevel nextLevel;
    [SerializeField]
    private GameWinner gameWinner;

    private PlayerInput playerInput;

    public Texture2D selectedTexture; // original
    private Texture2D paintTexture; // pintada

    private bool painting = true;

    public audio startnewlevel;

    private void Start()
    {
        playerInput = GetComponent<PlayerInput>();

        SelectNewTexture();
    }
    public void SelectNewTexture()
    {
        selectedTexture = drawingDifficultySelector.SelectDrawing();

        paintTexture = new Texture2D(selectedTexture.width, selectedTexture.height);
        paintTexture.filterMode = FilterMode.Point;

        Graphics.CopyTexture(selectedTexture, paintTexture);

        paintRenderer.material.mainTexture = paintTexture;


        painting = true;
    }
    private void Update()
    {


        PlayerInput.ActionState primaryActionState = playerInput.GetPrimaryActionState();
        if (painting)
        {
            if (primaryActionState.holded)
            {
                Ray ray = new Ray(rayOrigin.position, Vector3.down);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit, Mathf.Infinity, raycastLayerMask))
                {
                    Renderer renderer = hit.transform.GetComponent<Renderer>();
                    if (renderer == paintRenderer)
                    {
                        if (inkContainer.HasInk())
                        {
                            Vector2 pixelUV = hit.textureCoord;
                            pixelUV.x *= paintTexture.width;
                            pixelUV.y *= paintTexture.height;

                            Color colorPixel = paintTexture.GetPixel((int)pixelUV.x, (int)pixelUV.y);



                            if (colorPixel != paintColor)
                            {
                                paintTexture.SetPixel((int)pixelUV.x, (int)pixelUV.y, paintColor);
                                paintTexture.Apply();

                                inkContainer.UseInk();

                                if (drawingComparer.IsDrawingComplete(selectedTexture, paintTexture, paintColor))
                                {
                                    nextLevel.NextDraw();
                                    gameWinner.WinnGame();
                                    FindObjectOfType<audio>().PlayVictorySound();
                                    painting = false;
                                }
                            }
                        }
                    }
                }
            }
        }
    }

    public void WaitForCanPaint()
    {
        StopCoroutine(WaitPaint());
        StartCoroutine(WaitPaint());
    }

    private IEnumerator WaitPaint()
    {
        painting = false;
        yield return new WaitForSeconds(1f);
        painting = true;
    }
}
