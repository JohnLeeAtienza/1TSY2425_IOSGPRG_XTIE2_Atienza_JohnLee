using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LifeManager : MonoBehaviour
{
    public int lives = 3;
    public string gameOverSceneName; // Original string field

    // If you want to drag and drop the scene, use the following instead
    public SceneAsset gameOverScene; // For dragging the scene

    public void LoseLife()
    {
        lives--;

        if (lives <= 0)
        {
            GameOver();
        }
    }

    void GameOver()
    {
        if (gameOverScene != null)
        {
            SceneManager.LoadScene(gameOverScene.name); // Use the name from the SceneAsset
        }
        else
        {
            Debug.LogError("GameOver scene not assigned!");
        }
    }
}
