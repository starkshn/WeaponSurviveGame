using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Define
{
    public enum State
    {
        Die,
        Idle,
        Move,
        Jump,
        Skill,
        Collision,
    }

    public enum UIEvent
    {
        Click,
        Drag,

    }
    public enum Scene
    {
        Unknown,
        Start,
        Lobby,
        Game,
        Farm,

    }
    public enum Sound
    {
        Bgm,
        Effect,
        Jump,
        Collision,
        Move,
        MaxCount,

    }
    public enum CameraMode
    {
        QuarterView
    }

    public enum JoystickType
    {
        None,
        Move,
        NotMove,
    }

    public enum UIButton
    {
        None,
        Skill,
        Jump,
    }

    public enum WorldObject
    {
        Unknown,
        Player,
        Arrow_Regular,
        Arrow_Explosive,
        Arrow_Piercing,
        Bomb,
    }
    // WorldObject�� collison�浹�ϴµ� ����ص������� ������������ Layer�� ������ �ϰڽ��ϴ�.
    public enum Layer
    {
        Unknown,
        Player = 3,
        Arrow_Regular = 6,
        Arrow_Explosive = 7,
        Arrow_Piercing = 8,
        Bomb = 9,

    }

}
