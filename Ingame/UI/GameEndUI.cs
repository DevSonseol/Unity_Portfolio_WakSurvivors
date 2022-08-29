using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameEndUI : MonoBehaviour
{
    [SerializeField]
    private GameObject UIObject;
    public bool isOpened = false;
    public Text scoreText;

    void Start()
    {

    }

  
    void Update()
    {
        
    }

    public void Open_UI()
    {
        isOpened = true;
        //WS_UI active = true;하고
        this.gameObject.SetActive(true);

        //게임 일시정지 
        Time.timeScale = 0f;
  
        scoreText.text = string.Format("RECORD\n 처치한 몬스터:{0}\n 획득한도네{1}", 888, 888);



    }

    public void Close_UI()
    {
        //WS_UI active = false;하고
        this.gameObject.SetActive(false);

        //게임 다시 동작시키기
        Time.timeScale = 1f;

        SceneManager.LoadScene("LobbyScene");
    }

}
