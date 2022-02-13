using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_Start : MonoBehaviour
{
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            SceneMove("GameScene");
        }
    }

    public void SceneMove(string name)
    {
        SceneManager.LoadScene(name);
    }
}
