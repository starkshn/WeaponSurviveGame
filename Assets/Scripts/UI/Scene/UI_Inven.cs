using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Inven : UI_Scene
{

    enum GameObjects
    {
        GridPanel,
    }
    public override void init()
    {
        base.init();

        Bind<GameObject>(typeof(GameObjects));

        GameObject gridPanel = Get<GameObject>((int)GameObjects.GridPanel);

        foreach (Transform child in gridPanel.transform)
            Managers.Resource.Destroy(child.gameObject, 0); // gridPanel ���鼭 child����


        // ���� �κ��丮 ������ �����ؼ� ������ ä���ִ� �κ� 
        for (int i = 0; i < 8; i++)
        {
            //Managers.UI.MakeSubItem<UI_Inven_Item>();

            GameObject item = Managers.UI.MakeSubItem<UI_Inven_Item>(gridPanel.transform).gameObject;
            // go�� �θ�� gridPanel�ε� �׳༮�� .gameObject == GridPanel 
            // gameObject�� ���

            UI_Inven_Item invenItem = item.GetOrAddComponent<UI_Inven_Item>();
            // GridPanel�� GetOrCOmpoenent�ؼ� UI_Inven_Item�� �����´�.
            invenItem.SetInfo($"{i}��");

        }
    }


}
