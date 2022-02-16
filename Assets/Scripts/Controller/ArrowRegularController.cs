using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowRegularController : WeaponBaseController
{
    private float _speed = 60.0f;


    public override void init()
    {
        WorldObjectType = Define.WorldObject.Arrow_Regular;

        player = GameObject.FindGameObjectWithTag("Player");

        //_scope = Managers.Resource.Instantiate("Scope/BlueScope");
        //_scope.transform.SetParent(transform);
        //_scope.SetActive(false);

    }

    private void Update()
    {
        float distance = (player.transform.position - transform.position).magnitude;

        if (distance <= _attackRange && inAttackRange == true)
        {

            _lockTarget = player;
            _destDir = _lockTarget.transform.position; // scope위치 && 미사일 떨어질 위치  
            _destDir.y = 0.6f;
            inAttackRange = false;
        }

        SetArrowDir();
    }

    public void SetArrowDir()
    {
        // 호출이 되면 해당 위치벡터로 스코프 위치 설정 && 미사일 떨어질 위치 설정 
        //_scope.SetActive(true);
        //_scope.transform.position = _destDir;

        // Rocket Dir설정
        transform.position = Vector3.MoveTowards(gameObject.transform.position, _destDir, Time.deltaTime * _speed);
        transform.LookAt(_destDir);

    }
}
