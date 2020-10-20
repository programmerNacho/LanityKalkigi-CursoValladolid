using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverScript : MonoBehaviour
{
    // Cuando la tinta se acabe que aparezca en pantalla;

    public Text GameOverText;

    private void EndGame()
    {
        GameOverText.gameObject.SetActive(true);
    }
}
