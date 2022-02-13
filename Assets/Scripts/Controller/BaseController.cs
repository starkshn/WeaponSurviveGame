using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseController : MonoBehaviour
{
    [SerializeField]
    protected Vector2 _moveDir;

    [SerializeField]
    protected Vector3 _destDir;

    [SerializeField]
    protected Define.State _state;

    public virtual Define.State State
    {
        get { return _state; }

        set
        {
            _state = value;

            Animator anim = GetComponent<Animator>();

            switch (_state)
            {
                case Define.State.Die:
                    break;
                case Define.State.Idle:
                    anim.CrossFade("WAIT", 0.1f);
                    break;
                case Define.State.Move:
                    anim.CrossFade("RUN", 0.1f);
                    break;
                case Define.State.Jump:
                    anim.CrossFade("JUMP", 0.1f);
                    break;
                case Define.State.Skill:
                    break;
                case Define.State.Collision:
                    anim.CrossFade("GETHIT", 0.1f);
                    break;
            }
        }
    }

    private void Start()
    {
        init();
    }

    void Update()
    {
        switch (_state)
        {
            case Define.State.Die:
                UpdateDie();
                break;
            case Define.State.Idle:
                UpdateIdle();
                break;
            case Define.State.Move:
                UpdateMove();
                break;
            case Define.State.Jump:
                UpdateJump();
                break;
            case Define.State.Collision:
                UpdateCollision();
                break;
        }

    }


    public abstract void init();
    protected virtual void UpdateDie() { }
    protected virtual void UpdateMove() { }
    protected virtual void UpdateIdle() { }
    protected virtual void UpdateJump() { }
    protected virtual void UpdateSkill() { }
    protected virtual void UpdateCollision() { }

}
