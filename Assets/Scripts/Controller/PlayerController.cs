using UnityEngine;
using System.Collections;
using System;

public class PlayerController : BaseController
{
    public float _speed;
    public float _jumpSpeedF; // Player ���� ��.
    public float _gravity; // Player �ۿ��ϴ� �߷�
    public float _hp, _hpMax;
    public bool _isJump = false;
    public bool _rockCollision = false;

    public Rigidbody RD;

    JoyStickManager _joyStickManager;

    GameObject _jumpButton;

    // collision �����ϱ����� Layer
    int _mask = ( 1 << (int)Define.Layer.Arrow_Regular | 1 << (int)Define.Layer.Arrow_Piercing | 1 << (int)Define.Layer.Arrow_Explosive | 1 << (int)Define.Layer.Bomb );

    public Action<Collider> OnTriggerEvent = null;

    public override void init()
    {
        RD = GetComponent<Rigidbody>();

        _joyStickManager = GameObject.FindGameObjectWithTag("JoyStick").GetComponent<JoyStickManager>();

        _jumpButton = GameObject.FindGameObjectWithTag("JumpButton");
        
        _speed = 5.0f;
        _jumpSpeedF = 4.0f;
        _gravity = 20.0f;

        OnTriggerEvent -= OnCollisionPlayer;
        OnTriggerEvent += OnCollisionPlayer;

    }

    //private void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.X))
    //    {
    //        JumpButton();

    //        ComputeHP(-10);
    //    }
    //}

    public void Move(Vector2 inputDirection)
    {
        _moveDir = inputDirection;

        if (_moveDir.magnitude != 0)
        {
            Vector3 moveDir = Vector3.forward * _moveDir.y + Vector3.right * _moveDir.x; // ���̷������� ���ϴ��� �𸣰���

            transform.forward = moveDir;
            // �̵�
            transform.position += (moveDir * Time.deltaTime * _speed);
        }
    }

    public void Jump()
    {
        if (!_isJump)
        {
            RD.AddForce(new Vector3(0, 30, 0) * _jumpSpeedF);
            _isJump = true;
        }
    }

    //void ComputeHP(float num)
    //{
    //    _hp += num;
    //    if(_hp > _hpMax)
    //    {
    //        _hp = _hpMax;
    //    }
    //    if(_hp<=0)
    //    {
    //        _hp = 0;
    //        print("GameOver");
    //    }

    //    UIm.UpdateHPbar(_hp, _hpMax);
    //}

    protected override void UpdateIdle()
    {
        if (State == Define.State.Die)
            return;
        if (_joyStickManager._isInput == true)
        {
            State = Define.State.Move;
            return;
        }
        if (_isJump)
        {
            State = Define.State.Jump;
            return;
        }
    }

    protected override void UpdateMove()
    {
        if (State == Define.State.Die)
            return;
        if (_joyStickManager._isInput == false)
        {
            State = Define.State.Idle;
            return;
        }
        if (_isJump)
        {
            State = Define.State.Jump;
            return;
        }
    }
    protected override void UpdateJump()
    {
        if (State == Define.State.Die)
            return;

        if (_isJump)
            return;

        if (!_isJump)
        {
            if (_joyStickManager._isInput == true)
            {
                State = Define.State.Move;
                return;
            }
            if (_joyStickManager._isInput == false)
            {
                State = Define.State.Idle;
                return;
            }
        }
    }

    protected override void UpdateCollision()
    {
        if (State == Define.State.Die)
            return;

        if (_isJump)
        {
            State = Define.State.Jump;
            return;
        }

        if (_joyStickManager._isInput == false)
        {
            State = Define.State.Idle;
            return;
        }
        else
        {
            State = Define.State.Move;
            return;
        }
    }

    protected override void UpdateDie()
    {

    }
    private void OnCollisionEnter(Collision collision)
    {
        CollisionEvent(collision);
    }
    

    public void CollisionEvent(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            _isJump = false;
        }
    }

    // CollisonEvent�� ���� WorldType���� �޾ƿͼ� �����ص� ������ ������������ Layer�� ������ �ϰڽ��ϴ�.
    private void OnTriggerEnter(Collider other)
    {
        GameObject go = other.gameObject;
        int _mask = go.layer;

        switch(_mask)
        {
            case 6:
                {
                    Debug.Log("OnAttack!!");
                    if (OnTriggerEvent != null)
                        OnTriggerEvent.Invoke(other);
                }
                break;
            case 7:
                {

                }
                break;
            case 8:
                {

                }
                break;
        }
    }
    private void OnCollisionPlayer(Collider other)
    {
        Debug.Log("Action! Event");
        if (other != null)
            State = Define.State.Collision;
        else
            return;
    }
}
