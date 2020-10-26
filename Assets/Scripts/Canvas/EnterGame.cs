using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
[SelectionBase]
public class EnterGame : MonoBehaviour
{
    public EnterGame()
    {
        SceneManager.LoadScene("GameScene");
    }
}
