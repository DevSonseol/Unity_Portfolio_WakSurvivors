using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectButton : MonoBehaviour
{
    public CharacterButton characterButton;

    public void OnClickSelectButton()
    {
        SceneManager.LoadScene("IngameScene");
    }

    void Start()
    {
        characterButton.UpdateDetailPanel();
    }
}
