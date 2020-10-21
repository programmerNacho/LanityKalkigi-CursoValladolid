using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ReplayGameScript : MonoBehaviour
{
    [SerializeField]
    private Button PlayAgain;
    public void ReplayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void PlayAgainButton()
    {
        PlayAgain.gameObject.SetActive(true);
    }
}
