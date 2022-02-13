using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    int _order = 10; // ������� �ֱٿ� ����� ORDER�� ����.
    UI_Scene _sceneUI = null; // showSceneUI �����Ұ�

    public GameObject Root // �̷��� property�� ���������
    {
        get
        {
            GameObject root = GameObject.Find("@UI_Root");

            if (root == null)
            {
                root = new GameObject { name = "@UI_Root" };
            }
            return root;
        }
    }

    public Action KeyAction = null;
    //public Action<Define.UIButtonAction> UIButtonClickAction = null;
    public Slider hpBar;


    // ���� �˾� ����� ��� �־���ϴµ� �̰��� � �ڷᱸ���� ��������� �����غ��� ���� �ڷᱸ���� ����ִ°��� ����.
    Stack<UI_Popup> _popupStack = new Stack<UI_Popup>();
    // �ٵ� <GameObject>�� ����ִ°��� ��¥ �ش����� �����غ��� -> �ƴϴ�.

    public void SetCanvas(GameObject go, bool sort = true)
    {
        Canvas canvas = Util.GetOrAddComponent<Canvas>(go);
        canvas.renderMode = RenderMode.ScreenSpaceOverlay;
        canvas.overrideSorting = true;

        if (sort)
        {
            canvas.sortingOrder = _order;
            _order++;
        }
        else // else �� ���� (sorting�� ��û ����) �˾��� ���þ��� �Ϲ� UI��� ����
        {
            canvas.sortingOrder = 0;
        }
    }

    public T Make3D_UI<T>(Transform parent = null, string name = null) where T : UI_Base
    {
        if (string.IsNullOrEmpty(name))
            name = typeof(T).Name;

        GameObject go = Managers.Resource.Instantiate($"UI/3D_UI/{name}");

        if (parent != null)
        {
            go.transform.SetParent(parent);
        }

        Canvas canvas = go.GetComponent<Canvas>();
        canvas.renderMode = RenderMode.WorldSpace;
        canvas.worldCamera = Camera.main;


        return go.GetOrAddComponent<T>();
    }

    public T MakeSubItem<T>(Transform parent = null, string name = null) where T : UI_Base
    {
        if (string.IsNullOrEmpty(name))
            name = typeof(T).Name;


        GameObject go = Managers.Resource.Instantiate($"UI/SubItem/{name}");

        if (parent != null)
        {
            go.transform.SetParent(parent);
        }
        return go.GetOrAddComponent<T>();
    }

    public T ShowSceneUI<T>(string name = null) where T : UI_Scene
    {
        if (string.IsNullOrEmpty(name))
            name = typeof(T).Name;

        GameObject go = Managers.Resource.Instantiate($"UI/Scene/{name}");

        T sceneUI = Util.GetOrAddComponent<T>(go);
        _sceneUI = sceneUI;


        go.transform.SetParent(Root.transform);

        return sceneUI;
    }

    public T ShowPopupUI<T>(string name = null) where T : UI_Popup
    {
        if (string.IsNullOrEmpty(name))
            name = typeof(T).Name;

        GameObject go = Managers.Resource.Instantiate($"UI/Popup/{name}");
        // �����տ� �ִ°� ������

        T popup = Util.GetOrAddComponent<T>(go);
        _popupStack.Push(popup);


        go.transform.SetParent(Root.transform);


        //_order++; ���⼭ �ϴ� �̷��� ���ϴ� ������ ShowPopupUI �������̽��� ���� �ƴ϶�,  ������ �巡�� ������� �����ٰ� ������ ������ ����� ���� ���,UI_BUTTON �����س����� ���� �� �ö󰡱� �����̴�.(������)
        return popup;
    }

    public void ClosePopupUI(UI_Popup popup)
    {
        if (_popupStack.Count == 0)
            return;

        if (_popupStack.Peek() != popup)
        {   // PeeK�� �����°��� �ƴ϶� �����⸸ �ϴ°�
            Debug.Log("Close Popup failed!");
            return;
        }

        ClosePopupUI();
    }

    public void ClosePopupUI()
    {
        if (_popupStack.Count == 0)
            return;
        // stack�� �������� �׻� count�� ����������.(�ȿ� �ƹ��͵� ���� ���� �����ϱ�)
        UI_Popup popup = _popupStack.Pop();
        Managers.Resource.Destroy(popup.gameObject);
        popup = null;

        _order--;
    }

    public void CloseAllPopupUI()
    {
        while (_popupStack.Count > 0)
            CloseAllPopupUI();
    }

    public void OnButtonClickQuit()
    {
        Application.Quit();
    }

    public void UpdateHPbar(float hp, float hpMax)
    {
        hpBar.value = (hp / hpMax);
    }

    public void ClickJumpButton()
    {

    }

    public void ClickSkillButton()
    {

    }

    public void Clear()
    {
        CloseAllPopupUI();
        _sceneUI = null;
    }
}
