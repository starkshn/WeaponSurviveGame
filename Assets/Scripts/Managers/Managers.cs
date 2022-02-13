using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Managers : MonoBehaviour
{
    static Managers s_instance; // 유일성 보장된다
    static Managers Instance { get { init(); return s_instance; } } // 유일한 매니저를 갖고온다 


    #region Core
    DataManager _data = new DataManager();
    ResourceManager _resource = new ResourceManager();
    JoyStickManager _joystick = new JoyStickManager();
    GameManagerEx _game = new GameManagerEx();
    PoolManager _pool = new PoolManager();
    SoundManager _sound = new SoundManager();
    SceneManagerEx _scene = new SceneManagerEx();
    UIManager _ui = new UIManager();
    UIButtonManager _uibutton = new UIButtonManager();


    public static ResourceManager Resource { get { return Instance._resource; } }
    public static JoyStickManager Joystick { get { return Instance._joystick; } }
    public static GameManagerEx Game { get { return Instance._game; } }
    public static DataManager Data { get { return Instance._data; } }
    public static PoolManager Pool { get { return Instance._pool; } }
    public static SceneManagerEx Scene { get { return Instance._scene; } } // SceneManager는 UI위에 위치하니까 여기다가 넣어주자
    public static SoundManager Sound { get { return Instance._sound; } }
    public static UIManager UI { get { return Instance._ui; } }
    public static UIButtonManager UIButton { get { return Instance._uibutton; } }
    #endregion

    void Start()
    {
        init();
    }

    static void init()
    {
        if (s_instance == null)
        {
            GameObject go = GameObject.Find("@Managers");
            if (go == null)
            {
                go = new GameObject { name = "@Managers" };
                go.AddComponent<Managers>();
            }

            DontDestroyOnLoad(go);
            s_instance = go.GetComponent<Managers>();
        }

        //s_instance._data.init();
        s_instance._sound.init();
        s_instance._pool.init();
    }

    public static void Clear()
    {
        Sound.Clear();
        Scene.Clear();
        UI.Clear();
        Sound.Clear();
        Pool.Clear();
    }
}
