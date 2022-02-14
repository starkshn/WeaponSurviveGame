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
        SettingButton,
        QuitButton,

    }

    enum Texts
    {
        StartText,
        SettingText,
        QuitText,
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

        // 요 밑에서 Bind먼저 꼭 해주어야함.
        Bind<Button>(typeof(Buttons));
        Bind<Text>(typeof(Texts));
        Bind<GameObject>(typeof(GameObjects));
        //Bind<Image>(typeof(Images));

        GetText((int)Texts.StartText).text = "Start";
        GetText((int)Texts.SettingText).text = "Settings";
        GetText((int)Texts.QuitText).text = "Quit";

        GameObject _startButton = GetButton((int)Buttons.StartButton).gameObject;
        GameObject _settingButton = GetButton((int)Buttons.SettingButton).gameObject;
        GameObject _quitButton = GetButton((int)Buttons.QuitButton).gameObject;

        BindEvent(_startButton, ClickedStartButton, Define.UIEvent.Click);
        BindEvent(_settingButton, ClickedSettingButton, Define.UIEvent.Click);
        BindEvent(_quitButton, ClickedQuitButton, Define.UIEvent.Click);

        GameObject _startSceneUI = GetObject((int)GameObjects.StartScene_UI).gameObject;
       
        // 밑에 두줄은 Drag상태에서만 사용을 한다
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
    public void ClickedSettingButton(PointerEventData data)
    {
       // ToDo
    }
    public void ClickedQuitButton(PointerEventData data)
    {
        // ToDo
    }
}
