using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WeaponCollision : MonoBehaviour
{
    public ParticleSystem _effect;
    void Start()
    {
        _effect = Managers.Resource.InstantiateParticle("RocketEffect/Effects_M/Explosions/NormalRocketExplosion");
       
    }

    public Action<int> OnScoreEvent;

    private void OnTriggerEnter(Collider other)
    {
        GameObject go = other.gameObject;
        int _mask = go.layer;

        switch(_mask)
        {
            case 6:
                {
                    ArrowRegularCollision(go);
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

    public void OnCollisionEnter(Collision collision)
    {
       GameObject go = collision.gameObject;
       Define.WorldObject type = Managers.Game.GetWorldObjectType(go);
       Debug.Log(type);

       switch (type)
       {
            
            case Define.WorldObject.Bomb:
                {
                    
                }
                break;
        }

    }

   public void ArrowRegularCollision(GameObject go)
    {
        Managers.Game.Despawn(go);
        //_effect.transform.position = new Vector3(go.transform.position.x, 0, go.transform.position.z);
        //_effect.Play();
        
    }

    public void BigRocketCollision(GameObject go)
    {
        Managers.Game.Despawn(go);
        _effect.transform.position = new Vector3(go.transform.position.x, 0, go.transform.position.z);
        _effect.Play();
    }
}
