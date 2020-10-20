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

    private PlayerInput playerInput;

    private Texture2D paintTexture;

    private void Start()
    {
        playerInput = GetComponent<PlayerInput>();

        paintTexture = new Texture2D((int)textureSize, (int)textureSize);
        paintTexture.filterMode = FilterMode.Point;

        paintRenderer.material.mainTexture = paintTexture;
    }

    private void Update()
    {
        PlayerInput.ActionState primaryActionState = playerInput.GetPrimaryActionState();

        if(primaryActionState.holded)
        {
            Ray ray = new Ray(rayOrigin.position, Vector3.down);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, raycastLayerMask))
            {
                Renderer renderer = hit.transform.GetComponent<Renderer>();
                if (renderer == paintRenderer)
                {
                    Vector2 pixelUV = hit.textureCoord;
                    pixelUV.x *= paintTexture.width;
                    pixelUV.y *= paintTexture.height;

                    paintTexture.SetPixel((int)pixelUV.x, (int)pixelUV.y, paintColor);
                    paintTexture.Apply();
                }
            }
        }
    }
}
