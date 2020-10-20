﻿using System.Collections;
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
    private int initialInk = 100;

    private int currentInk;

    private void Start()
    {
        currentInk = initialInk;
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
        }
    }

    public int GetCurrentInk()
    {
        return currentInk;
    }
}