using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmScene : BaseScene
{

    protected override void init()
    {
        base.init();

        SceneType = Define.Scene.Farm;

        GameObject player = Managers.Game.Spawn(Define.WorldObject.Player, "DuoPlayer/P02");
        //GameObject player = Managers.Game.Spawn(Define.WorldObject.Player, "DogKnight/DogPolyart");


        Camera.main.gameObject.GetOrAddComponent<CameraController>().SetPlayer(player);

        Managers.Resource.Instantiate("UI/GameScene_UI");

        // Respawn
        GameObject ReSpawnZone = GameObject.FindGameObjectWithTag("ReSpawnZone");
        SpawningPool pool = ReSpawnZone.AddComponent<SpawningPool>();

        pool.SetKeepRocketCount(30);

    }

    public override void Clear()
    {

    }
}
