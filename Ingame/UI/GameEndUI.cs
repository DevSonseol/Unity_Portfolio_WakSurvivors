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
        //WS_UI active = true;�ϰ�
        this.gameObject.SetActive(true);

        //���� �Ͻ����� 
        Time.timeScale = 0f;
  
        scoreText.text = string.Format("RECORD\n óġ�� ����:{0}\n ȹ���ѵ���{1}", 888, 888);



    }

    public void Close_UI()
    {
        //WS_UI active = false;�ϰ�
        this.gameObject.SetActive(false);

        //���� �ٽ� ���۽�Ű��
        Time.timeScale = 1f;

        SceneManager.LoadScene("LobbyScene");
    }

}
