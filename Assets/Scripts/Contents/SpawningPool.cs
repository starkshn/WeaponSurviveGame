using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawningPool : MonoBehaviour
{
    [SerializeField]
    GameObject _respawnObject;
    [SerializeField]
    public int _objectCount = 0;
    [SerializeField]
    public int _keepObjectCount = 0;

    [SerializeField]
    public Vector3 _spawnPos;
    [SerializeField]
    public float _spawnRadius = 15.0f;
    [SerializeField]
    public float _spawnTime = 5.0f;

    GameObject _spawnZone;

    int _reserveCount = 0;

    public void AddObjectCount(int value) { _objectCount += value; }
    public void SetKeepObjectCount(int count) { _keepObjectCount = count; }

    void Start()
    {
        Managers.Game.OnSpawnEvent -= AddObjectCount;
        Managers.Game.OnSpawnEvent += AddObjectCount;
    }

    void Update()
    {
        while (_reserveCount + _objectCount < _keepObjectCount)
        {
            Debug.Log("内风凭 角青!");
            StartCoroutine(ReserveObjectSpawn(_respawnObject));
        }
    }

    public IEnumerator ReserveObjectSpawn(GameObject go)
    {
        _reserveCount++;
        
        yield return new WaitForSeconds(Random.Range(0, _spawnTime));
        Debug.Log("内风凭 角青 in 内风凭!");

        GameObject obj = Managers.Game.Spawn(Managers.Game.GetWorldObjectType(_respawnObject), $"RespawnObject/{go.name}");
        if (obj != null)
            Debug.Log($"Spawn {obj.name}");

        Vector3 randPos;

        Vector3 randDir = Random.insideUnitSphere * Random.Range(0, _spawnRadius);
        randDir.y = GameObject.FindGameObjectWithTag("Ground").transform.position.y + 50;
        randPos = _spawnPos + randDir;

        obj.transform.position = randPos;

        _reserveCount--;
    }

}
