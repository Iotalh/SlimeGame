using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public Button restartBtn;
    public void ReloadScene()
    {
        SceneManager.LoadScene(1);
    }
}
