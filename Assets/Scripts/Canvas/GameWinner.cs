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
        StartCoroutine(Example());
    }   
    public void EndWinnGame()
    {
        GameWinnerText.gameObject.SetActive(false);
    }
    IEnumerator Example()
    {
        yield return new WaitForSecondsRealtime(5);
        GameWinnerText.gameObject.SetActive(false);
    }


}
