using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawningPool : MonoBehaviour
{
    int _reserveCount = 0;

    [SerializeField]
    public int _arrowRegularCount = 0;
    [SerializeField]
    int _keepArrowRegularCount = 0;

    [SerializeField]
    Vector3 _spawnPos; // spawn할 중심점
    [SerializeField]
    float _spawnRadius = 15.0f; // _spawnPos 중심으로 어느정도 거리에서 랜덤으로 spawn 해 줄 값.
    [SerializeField]
    float _spawnTime = 5.0f;

    GameObject _spawnZone;

    // Rock
   
    // Rocket
    public void AddRocketCount(int value) { _arrowRegularCount += value; }
    public void SetKeepRocketCount(int count) { _keepArrowRegularCount = count; }

    void Start()
    {
        Managers.Game.OnSpawnEvent -= AddRocketCount;
        Managers.Game.OnSpawnEvent += AddRocketCount;
    }


    void Update()
    {
        while (_reserveCount + _arrowRegularCount < _keepArrowRegularCount)
        {
            StartCoroutine("ReserveArrowRegularSpawn");
        }
    }

    IEnumerator ReserveArrowRegularSpawn()
    {
        _reserveCount++;

        yield return new WaitForSeconds(Random.Range(0, _spawnTime));

        GameObject obj = Managers.Game.Spawn(Define.WorldObject.Arrow_Regular, "Weapons/Arrow_Regular");

        Vector3 randPos;

        Vector3 randDir = Random.insideUnitSphere * Random.Range(0, _spawnRadius);
        randDir.y = GameObject.FindGameObjectWithTag("Ground").transform.position.y + 50;
        randPos = _spawnPos + randDir;

        obj.transform.position = randPos;

        _reserveCount--;
    }

}
