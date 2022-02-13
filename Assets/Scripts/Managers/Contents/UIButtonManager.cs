using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIButtonManager : MonoBehaviour
{
    public GameObject pauseUI;

    PlayerController _player;

    public Action<Define.UIButton> UIAction = null;


    private void Start()
    {
        _player = GameObject.FindObjectOfType<PlayerController>();
        pauseUI.SetActive(false);
    }

    //public void OnClickJumpButtton()
    //{
    //    _player.Jump();
    //}

   
    public void OnClickButtonPause()
    {
        pauseUI.SetActive(true);
        Time.timeScale = 0;
    }

    public void OnClickButtonResume()
    {
        pauseUI.SetActive(false);
        Time.timeScale = 1;
    }

    public void OnClickButtonRestart()
    {
        Managers.Scene.LoadScene(Define.Scene.Game);
    }

    public void OnClickQuit()
    {
        Application.Quit();
    }
}
