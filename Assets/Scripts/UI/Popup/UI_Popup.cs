using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Popup : UI_Base
{
    public override void init()
    {
        // virtual �����Լ��� �����.
        Managers.UI.SetCanvas(gameObject, true);
        // �κ��丮 �ǽ� #2 ���� ���̶� ���� init �Լ��� ���̱� ������ override�� ������
    }

    public virtual void ClosePopupUI() // ���ο��� ����� �� �ֵ��� ����.
    {
        Managers.UI.ClosePopupUI(this); // UI_Popup�� ��ӹ��� �ֵ��� ClosePopupUI�� �ϸ� �ڵ����� Managers.UI.ClosePopupUI(this);�̰Ÿ� ���ش�.
    }

}
