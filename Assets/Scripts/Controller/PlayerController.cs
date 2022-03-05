using UnityEngine;
using System.Collections;
using System;

public class PlayerController : BaseController
{
    public float _speed;
    public float _jumpSpeedF; // Player 점프 힘.
    public float _gravity; // Player 작용하는 중력
    public float _hp, _hpMax;
    public bool _isJump = false;
    public bool _rockCollision = false;

    public Rigidbody RD;

    JoyStickManager _joyStickManager;

    GameObject _jumpButton;

    // collision 구별하기위한 Layer
    int _mask = ( 1 << (int)Define.Layer.Arrow_Regular | 1 << (int)Define.Layer.Arrow_Piercing | 1 << (int)Define.Layer.Arrow_Explosive | 1 << (int)Define.Layer.Bomb );

    public override void init()
    {
        RD = GetComponent<Rigidbody>();

        _joyStickManager = GameObject.FindGameObjectWithTag("JoyStick").GetComponent<JoyStickManager>();

        _jumpButton = GameObject.FindGameObjectWithTag("JumpButton");
        
        _speed = 5.0f;
        _jumpSpeedF = 4.0f;
        _gravity = 20.0f;

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
            Vector3 moveDir = Vector3.forward * _moveDir.y + Vector3.right * _moveDir.x; // 왜이런식으로 곱하는지 모르겠음

            transform.forward = moveDir;
            // 이동
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

        if (_joyStickManager._isInput == true)
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

    // CollisonEvent를 지금 WorldType으로 받아와서 구분해도 되지만 공부차원에서 Layer를 쓰도록 하겠습니다.
    private void OnTriggerEnter(Collider other)
    {
        GameObject go = other.gameObject;
        int _mask = go.layer;
        CapsuleCollider capCollider = go.GetComponent<CapsuleCollider>();

        switch (_mask)
        {
            case 6:
                {
                    //capCollider.enabled = false;
                    Debug.Log("RegularArrow Attack Player!!");
                    //go.transform.SetParent(this.transform);
                    State = Define.State.Collision;
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
    
    public void SetColliderAnimation()
    {

    }
    
    
}
