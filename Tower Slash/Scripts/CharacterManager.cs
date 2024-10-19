using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterManager : MonoBehaviour
{
    public GameObject[] playerPrefabs;
    public Transform spawnPoint;
    private int selectedCharacterIndex = 0;

    public void SelectCharacter(int index)
    {
        selectedCharacterIndex = index;
        PlayerPrefs.SetInt("SelectedCharacterIndex", selectedCharacterIndex);
        LoadNextScene();
    }

    private void LoadNextScene()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
