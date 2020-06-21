using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public Button restartBtn;
    public Button closeBtn;
    public void ReloadScene()
    {
        SceneManager.LoadScene(1);
    }
    public void CloseGame()
    {
        Application.Quit();
    }
}
