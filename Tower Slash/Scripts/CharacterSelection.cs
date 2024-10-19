using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelection : MonoBehaviour
{
    public void SelectCharacter(string characterType)
    {
        PlayerPrefs.SetString("SelectedCharacter", characterType);
        SceneManager.LoadScene("GameScene"); // Replace with your game scene name
    }
}
