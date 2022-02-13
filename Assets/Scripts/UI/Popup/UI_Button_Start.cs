using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Reflection;
using System;

public class UI_Button_Start : UI_Popup
{
    private bool _activeStartUI = true;
   
    enum Buttons
    {
        StartButton,
    }

    enum Texts
    {
        StartText,
    }

    enum GameObjects
    {
        StartScene_UI,
    }

    enum Images
    {
       
    }

    public override void init()
    {
        base.init();

        // �� �ؿ��� Bind���� �� ���־����.
        Bind<Button>(typeof(Buttons));
        Bind<Text>(typeof(Texts));
        Bind<GameObject>(typeof(GameObjects));
        //Bind<Image>(typeof(Images));

        GetText((int)Texts.StartText).text = "�����ϱ�";

        GameObject _startButton = GetButton((int)Buttons.StartButton).gameObject;
       
        BindEvent(_startButton, ClickedStartButton, Define.UIEvent.Click);
        
        GameObject _startSceneUI = GetObject((int)GameObjects.StartScene_UI).gameObject;
       
        // �ؿ� ������ Drag���¿����� ����� �Ѵ�
        //BindEvent(go, ((PointerEventData data) => { go.gameObject.transform.position = data.position; }), Define.UIEvent.Drag);
        //BindEvent(go2, ((PointerEventData data) => { go2.gameObject.transform.position = data.position; }), Define.UIEvent.Drag);

    }

    public void UpdateStartSceneUI()
    {
        //GameObject _startButton = GetObject((int)GameObjects.StartScene_UI).gameObject;
      
        //if (_activeGameUI)
        //{
        //    _activePausePanel = false;
        //    Time.timeScale = 1;
        //}
        //else
        //{
        //    _activePausePanel = true;
        //    Time.timeScale = 0;
        //}

    }

    public void ClickedStartButton(PointerEventData data)
    {
        GameObject StartSceneUI = GetObject((int)GameObjects.StartScene_UI).gameObject;
        Destroy(StartSceneUI);

        SceneManager.LoadScene("GameScene");

    }
}