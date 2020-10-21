using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelScript : MonoBehaviour
{
    // Acceder al componente texto para que cada vez que se termine un nivel salte al siguiente número;
    // Si se resetea la escena que el número vuelva 1 otra vez; 

    public Text levelText;

    [SerializeField]
    private Button FinishedLevel;
    [SerializeField]
    private PlayerPaint playerPaint;


    public void NewScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }

    public void ChangeDrawing()
    {
        playerPaint.SelectNewTexture();

    }

    public void FinishedButton()
    {
        FinishedLevel.gameObject.SetActive(true);
    }


}
