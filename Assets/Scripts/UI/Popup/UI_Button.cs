using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Reflection;
using System;

public class UI_Button : UI_Popup
{
    private  bool _activeStartUI = true;
    private bool _activeGameUI = true;
    private bool _activePausePanel = false;
    private bool _clickedPauseButton;

    PlayerController _player;

    int _score = 0;

    enum Buttons
    {
        PauseButton,
        ResumeButton,
        RestartButton,
        QuitButton,
        JumpButton,
    }

    enum Texts
    {
       ResumeText,
       RestartText,
       QuitText,
       ScoreText,
    }

    enum GameObjects
    {
        GameScene_UI,
        PausePanel,
    }

    enum Images
    {
        ItemIcon,
    }

    public override void init()
    {
        base.init();

        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        
        if (_player != null)
            Debug.Log($"find player! {_player}");
        else
            Debug.Log($"Cannot find! {_player}");

        // 요 밑에서 Bind먼저 꼭 해주어야함.
        Bind<Button>(typeof(Buttons));
        Bind<Text>(typeof(Texts));
        Bind<GameObject>(typeof(GameObjects));
        //Bind<Image>(typeof(Images));

        GetText((int)Texts.ResumeText).text = "계속하기";
        GetText((int)Texts.RestartText).text = "재시작하기";
        Get<Text>((int)Texts.QuitText).text = "종료하기";
        String _scoreText = GetText((int)Texts.ScoreText).text = $"Score : {_score}";

        GameObject _pauseButton = GetButton((int)Buttons.PauseButton).gameObject;
        GameObject _resumeButton = GetButton((int)Buttons.ResumeButton).gameObject;
        GameObject _restartButton = GetButton((int)Buttons.RestartButton).gameObject;
        GameObject _jumpButton = GetButton((int)Buttons.JumpButton).gameObject;


        BindEvent(_pauseButton, ClickedPauseButton, Define.UIEvent.Click);
        BindEvent(_resumeButton, ClickedResumebutton, Define.UIEvent.Click);
        BindEvent(_restartButton, ClickedRestartButton, Define.UIEvent.Click);
        BindEvent(_jumpButton, ClickedJumpButton, Define.UIEvent.Click);

        // Score BindEvent
        //BindEventScore(_scoreText, UpdateScore);
        

        GameObject _gameSceneUI = GetObject((int)GameObjects.GameScene_UI).gameObject;
        GameObject _pausePanel = GetObject((int)GameObjects.PausePanel).gameObject;

        // 밑에 두줄은 Drag상태에서만 사용을 한다.
        //BindEvent(go, ((PointerEventData data) => { go.gameObject.transform.position = data.position; }), Define.UIEvent.Drag);
        //BindEvent(go2, ((PointerEventData data) => { go2.gameObject.transform.position = data.position; }), Define.UIEvent.Drag);
       
        UpdateGameSceneUI();

        Managers.Game.OnScoreEvent -= GetScore;
        Managers.Game.OnScoreEvent += GetScore;
    }

    public void GetScore(int value) { _score += value; }

    public void UpdateScore()
    {
        GetText((int)Texts.ScoreText).text = $"Score : {_score}";
    }

    private void Update()
    {
        UpdateScore();
    }

    public void UpdateGameSceneUI()
    {
        GameObject _gameSceneUI = GetObject((int)GameObjects.GameScene_UI).gameObject;
        GameObject _pausePanel = GetObject((int)GameObjects.PausePanel).gameObject;

        if(_activeGameUI)
        {
            _pausePanel.SetActive(false);
            Time.timeScale = 1;
        }
        else
        {
            _pausePanel.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void ClickedPauseButton(PointerEventData data) // public 으로 꼭 해줘야한다.
    {
        _activeGameUI = false;
        UpdateGameSceneUI();      
    }
     
    public void ClickedResumebutton(PointerEventData data)
    {
        _activeGameUI = true;
        UpdateGameSceneUI();
    }

    public void ClickedRestartButton(PointerEventData data)
    {
        _activeGameUI = true;
        SceneManager.LoadScene("StartScene");
    }


    public void ClickedJumpButton(PointerEventData data)
    {
        _player.Jump();
    }

    
}
