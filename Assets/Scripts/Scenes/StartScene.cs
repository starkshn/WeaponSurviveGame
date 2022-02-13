using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScene : BaseScene
{
    protected override void init()
    {
        base.init();

        SceneType = Define.Scene.Start;

        GameObject UI_Button  =Managers.Resource.Instantiate("UI/StartScene_UI");
    }

    public override void Clear()
    {
        Debug.Log("Start Scene Clear!");
    }
}
