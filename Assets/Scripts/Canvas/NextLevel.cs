using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NextLevel : MonoBehaviour
{
    [SerializeField]

    private GameObject nextGame;
    public void NextDraw()
    {
        nextGame.gameObject.SetActive(true);
    } 
    public void EndNextDraw()
    {
        nextGame.gameObject.SetActive(false);
    }
}
