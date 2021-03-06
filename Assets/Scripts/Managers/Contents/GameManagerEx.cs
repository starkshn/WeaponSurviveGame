using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerEx
{
    // int <-> GameObject
    GameObject _player;
    HashSet<GameObject> _arrowRegular = new HashSet<GameObject>();
    HashSet<GameObject> _arrowPiercing = new HashSet<GameObject>();
    HashSet<GameObject> _arrowExplosive = new HashSet<GameObject>();
    HashSet<GameObject> _bomb = new HashSet<GameObject>();
    HashSet<GameObject> _water = new HashSet<GameObject>();

    //HashSet<GameObject> _tres = new HashSet<GameObject>();

    public Action<int> OnSpawnEvent;
    public Action<int> OnScoreEvent;

    public GameObject GetPlayer() { return _player; }

    public Define.WorldObject GetWorldObjectType(GameObject go) 
    {
        RespawnObject roc = go.GetComponent<RespawnObject>();

        if (roc == null)
        {
            Debug.Log("GetWorldObjectType Failed!");
            return Define.WorldObject.Unknown;
        }
            
        // bc is PlayerController; 이렇게 체크를 할 수는 있기는 하다.
        return roc.WorldObjectType;
    }

    public GameObject Spawn(Define.WorldObject type, string path, Transform parent = null)
    {
        GameObject go = Managers.Resource.Instantiate(path, parent);

        switch (type)
        {
            case Define.WorldObject.Player:
                {
                    _player = go;
                }
                break;
            case Define.WorldObject.Arrow_Regular:
                {
                    _arrowRegular.Add(go);
                    if (OnSpawnEvent != null)
                        OnSpawnEvent.Invoke(1);
                }
                break;
            case Define.WorldObject.Arrow_Piercing:
                {
                    _arrowPiercing.Add(go);
                    if (OnSpawnEvent != null)
                        OnSpawnEvent.Invoke(1);
                }
                break;
            case Define.WorldObject.Arrow_Explosive:
                {
                    _arrowExplosive.Add(go);
                    if (OnSpawnEvent != null)
                        OnSpawnEvent.Invoke(1);
                }
                break;
            case Define.WorldObject.Bomb:
                {
                    _bomb.Add(go);
                    if (OnSpawnEvent != null)
                        OnSpawnEvent.Invoke(1);
                }
                break;
            case Define.WorldObject.WaterBottle:
                {
                    _water.Add(go);
                    if (OnSpawnEvent != null)
                    {
                        OnSpawnEvent.Invoke(1);
                        Debug.Log("Spawn WaterBottle!");
                    }
                }
                break;
            
        }
        return go;
    }

    public void Despawn(GameObject go)
    {
        Define.WorldObject type = GetWorldObjectType(go);

        switch (type)
        {
            case Define.WorldObject.Arrow_Regular:
                {
                    if (_arrowRegular.Contains(go))
                    {
                        _arrowRegular.Remove(go);
                        if (OnSpawnEvent != null)
                        {
                            OnSpawnEvent.Invoke(-1);
                            OnScoreEvent.Invoke(10);
                        }
                    }
                    Managers.Resource.Destroy(go, 1.0f);
                }
                break;
            case Define.WorldObject.Arrow_Piercing:
                {
                    if (_arrowPiercing.Contains(go))
                    {
                        _arrowPiercing.Remove(go);
                        if (OnSpawnEvent != null)
                        {
                            OnSpawnEvent.Invoke(-1);
                            OnScoreEvent.Invoke(10);
                        }
                    }
                    Managers.Resource.Destroy(go, 0.5f);
                }
                break;
            case Define.WorldObject.Arrow_Explosive:
                {
                    if (_arrowExplosive.Contains(go))
                    {
                        _arrowExplosive.Remove(go);
                        if (OnSpawnEvent != null)
                        {
                            OnSpawnEvent.Invoke(-1);
                            OnScoreEvent.Invoke(20);
                        }
                    }
                    Managers.Resource.Destroy(go, 0);
                }
                break;
            case Define.WorldObject.Bomb:
                {
                    if (_bomb.Contains(go))
                    {
                        _bomb.Remove(go);
                        if (OnSpawnEvent != null)
                        {
                            OnSpawnEvent.Invoke(-1);
                            OnScoreEvent.Invoke(30);
                        }
                    }
                    Managers.Resource.Destroy(go, 2.0f);
                }
                break;
            case Define.WorldObject.WaterBottle:
                {
                    if (_water.Contains(go))
                    {
                        _water.Remove(go);
                        if (OnSpawnEvent != null)
                        {
                            OnSpawnEvent.Invoke(-1);
                        }
                    }
                    Managers.Resource.Destroy(go, 0);
                }
                break;
            default:
                break;
        }

    }

}

