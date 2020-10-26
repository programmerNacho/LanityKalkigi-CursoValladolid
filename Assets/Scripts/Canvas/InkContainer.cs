using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InkContainer : MonoBehaviour
{
    // Cada vez que el jugador pinte un pixel en pantalla bajar 1 unidad la barra;
    // ¿Coger el Input del usuario para saber si pinta o no?;
    // Cuando se complete un nivel cambiar el texto de Level;
    // Cuando llegue a 0 el valor de la tinta se termina la partida;
    // Cuando se termina la partida aparece "Game Over";
    // Botton para vover a jugar;

    [SerializeField]
    private int maxInk = 100;
    [SerializeField]
    private UsedInk usedInk;
    [SerializeField]
    private GameOverScript GameOverText;
    [SerializeField]
    private ReplayGameScript PlayAgain;
    [SerializeField]
    private DrawingCountPixels drawingCountPixels;
    [SerializeField]
    private PlayerPaint playerPaint;

    private int currentInk;

    public audio defeat;

    private void Start()
    {
        currentInk = maxInk;
        
    }

    public void SumInk()
    {
        currentInk = currentInk + drawingCountPixels.HowPixelsInDraw(playerPaint.selectedTexture) + (int)(drawingCountPixels.HowPixelsInDraw(playerPaint.selectedTexture) * 0.1f);
        if(currentInk >= maxInk)
        {
            maxInk = currentInk;
        }
        usedInk.InkUse(currentInk, maxInk);
    }
    public bool HasInk()
    {
        return currentInk > 0;
    }

    public void UseInk()
    {
        if(HasInk())
        {
            currentInk--;
            usedInk.InkUse(currentInk, maxInk);
            if(!HasInk())
            {
                GameOverText.EndGame();
                PlayAgain.PlayAgainButton();
                defeat.DefeatSound();
            }
        }
    }
    public int GetCurrentInk()
    {
        return currentInk;
    }
}
