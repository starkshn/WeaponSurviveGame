using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Util
{
    // UI_Base ���� Getcompnent�ϴ� �κа����� ���� ���̱� ������
    public static T GetOrAddComponent<T>(GameObject go) where T : UnityEngine.Component
    {
        T component = go.GetComponent<T>();
        if (component == null)
            component = go.AddComponent<T>();

        return component;
    }

    public static GameObject FindChild(GameObject go, string name = null, bool recursive = false) 
    {
        Transform transform = FindChild<Transform>(go, name, recursive);
        if (transform == null)
            return null;

        if (transform != null)
            Debug.Log($"Find {go}");

        return transform.gameObject;
    }

    
    public static T FindChild<T>(GameObject go, string name = null, bool recursive = false) where T : UnityEngine.Object 
    {
        if (go == null)
            return null;

        if (recursive == false) // ���� �ڽĸ� ã�� ���
        {
            for (int i = 0; i < go.transform.childCount; i++) 
            {
                Transform transform = go.transform.GetChild(i); 

                if (string.IsNullOrEmpty(name) || transform.name == name)
                {
                    T component = transform.GetComponent<T>();
                    if (component != null)
                        return component;
                }
            }
        }
        else // �ڽ��� �ڽı��� ã�� ���
        {
            foreach (T component in go.GetComponentsInChildren<T>())
            {
                if (string.IsNullOrEmpty(name) || component.name == name) 
                    return component;
            }
        }
        return null; 
    }

}

