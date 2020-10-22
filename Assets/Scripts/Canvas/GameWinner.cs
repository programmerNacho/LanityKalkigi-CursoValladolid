using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameWinner : MonoBehaviour
{
    [SerializeField]
    private Text GameWinnerText;
    public void WinnGame()
    {
        GameWinnerText.gameObject.SetActive(true);
    }

}
