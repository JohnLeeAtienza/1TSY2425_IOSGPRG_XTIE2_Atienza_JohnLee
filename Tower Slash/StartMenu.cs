using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartMenu : MonoBehaviour
{
    public Button startButton;

    void Start()
    {
        startButton.onClick.AddListener(StartGame);
    }

    void StartGame()
    {
        SceneManager.LoadScene("CharacterSelection");
    }
}
