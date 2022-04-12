
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stageController : MonoBehaviour
{
    public int stageNum;

    private void OnTriggerEnter(Collider other)
    {
       if(other.gameObject.CompareTag("Player"))
        {
            print("����");
            switch(stageNum)
            {
                case 1:
                    InvokeRepeating("TrapStage1", 0.1f, 1);
                    break;
                case 2:
                    InvokeRepeating("TrapStage2", 0.1f, 1);
                    break;

            }
        }
            
    }

    /*
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
            print("����");
    }
    */

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            print("��Ż");
            switch (stageNum)
            {
                case 1:
                    CancelInvoke("TrapStage1");
                    break;
                case 2:
                    CancelInvoke("TrapStage2");
                    break;

            }
        }
        
    }
    void TrapStage1()
    {
        print("������1�� ��ֹ� ����");
    }

    void TrapStage2()
    {
        print("������2�� ��ֹ� ����");
    }
}
