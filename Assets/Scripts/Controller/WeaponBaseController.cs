using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponBaseController : MonoBehaviour
{
    [SerializeField]
    protected Vector3 _destDir;

    [SerializeField]
    protected GameObject _lockTarget;

    protected GameObject player;
    

    public Define.WorldObject WorldObjectType { get; protected set; } = Define.WorldObject.Unknown;


    [SerializeField]
    protected float _attackRange = 40.0f;

    [SerializeField]
    protected GameObject _scope;

    protected bool inAttackRange = true;

    private void Start()
    {
        init();
    }

    public abstract void init();

}
