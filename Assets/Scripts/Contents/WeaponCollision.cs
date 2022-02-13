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

    public void OnCollisionEnter(Collision collision)
    {
       GameObject go = collision.gameObject;
       Define.WorldObject type = Managers.Game.GetWorldObjectType(go);
       Debug.Log(type);

       switch (type)
       {
            case Define.WorldObject.Arrow_Regular:
                {
                    Debug.Log("Rocket Collision!");

                    ArrowRegularCollision(go);
                }
                break;
            case Define.WorldObject.Arrow_Piercing:
                {
                   
                }
                break;
            case Define.WorldObject.Arrow_Explosive:
                {
                   
                }
                break;
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
