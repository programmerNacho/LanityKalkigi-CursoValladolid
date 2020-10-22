using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverScript : MonoBehaviour
{
    // Cuando la tinta se acabe que aparezca en pantalla;
    [SerializeField]
    private Text GameOverText;
    [SerializeField]
    private Button FinishedLevel;

    public void EndGame()
    {
        GameOverText.gameObject.SetActive(true);

    }
}
