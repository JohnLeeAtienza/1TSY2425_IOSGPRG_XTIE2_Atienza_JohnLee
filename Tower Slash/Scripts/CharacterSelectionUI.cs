using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelectionUI : MonoBehaviour
{
    public CharacterManager characterManager;

    public void OnCharacterButtonPressed(int index)
    {
        characterManager.SelectCharacter(index);
    }
}
