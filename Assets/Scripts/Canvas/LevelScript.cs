using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelScript : MonoBehaviour
{
    // Acceder al componente texto para que cada vez que se termine un nivel salte al siguiente número;
    // Si se resetea la escena que el número vuelva 1 otra vez; 

    [SerializeField]
    public Text levelText;
    [SerializeField]
    public int levelNumber;

    [SerializeField]
    private Button FinishedLevel;
    [SerializeField]
    private PlayerPaint playerPaint;

    private int currentLevel = 1;

    private int levelValue = 1;

    public void NewScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ChangeLevelText()
    {
        // Si termino el dibujo sumo;
        // Si acabo la tinta y tengo Game Over reseteo a 1;

        currentLevel = ++levelValue;

        levelNumber = currentLevel;
        levelText.text = "Level " + levelNumber;

    }

    public void ChangeDrawing()
    {
        FindObjectOfType<DrawingDifficultySelector>().NextRound();
        playerPaint.SelectNewTexture();
        ChangeLevelText();

    }

    public void FinishedButton()
    {
            FinishedLevel.gameObject.SetActive(true);
        // Si sale Game Over que de deje de ver el botón para que no se pulse;
    }
}
