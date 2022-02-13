using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScene : BaseScene
{
   
    protected override void init()
    {
        base.init();

        SceneType = Define.Scene.Game;

        GameObject player = Managers.Game.Spawn(Define.WorldObject.Player, "DuoPlayer/P02");
        //GameObject player = Managers.Game.Spawn(Define.WorldObject.Player, "DogKnight/DogPolyart");


        Camera.main.gameObject.GetOrAddComponent<CameraController>().SetPlayer(player);

        Managers.Resource.Instantiate("UI/GameScene_UI");
        GameObject _respawnzone = Managers.Resource.Instantiate("Respawn/ReSpawnZone");
        _respawnzone.transform.position = new Vector3(0, 50, 0);

        // Respawn
        GameObject ReSpawnZone = GameObject.FindGameObjectWithTag("ReSpawnZone");
        SpawningPool pool = ReSpawnZone.AddComponent<SpawningPool>();

        pool.SetKeepRocketCount(70);

    }

    public override void Clear()
    {

    }
}
