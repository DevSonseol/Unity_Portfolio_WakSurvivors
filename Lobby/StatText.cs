using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatText : MonoBehaviour
{
    public CharacterButton characterButton;

    void Start()
    {
        characterButton.UpdateStatPanelText();
    }
}
