using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{
    public string restartSceneName = "SampleScene";

    public void RestartGame()
    {
        SceneManager.LoadScene(restartSceneName);
    }
}
