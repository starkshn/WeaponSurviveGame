using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    Define.CameraMode _mode = Define.CameraMode.QuarterView;

    [SerializeField]
    Vector3 _delta = new Vector3(0.0f, 4.0f, -10.0f); // _delta 라는 것은 player 기준으로 얼마만큼 떨어져있는지를 나타내는것임

    [SerializeField]
    GameObject _player = null;

    public void SetPlayer(GameObject player) { _player = player; }

    void Start()
    {

    }

    void LateUpdate()
    {
        if (_mode == Define.CameraMode.QuarterView)
        {

            if (_player.IsValid() == false)
            {
                return;
            }

            transform.position = _player.transform.position + _delta;

        }
    }

    public void SetQuarterView(Vector3 delta)
    {
        _mode = Define.CameraMode.QuarterView;
        _delta = delta;
    }
}
