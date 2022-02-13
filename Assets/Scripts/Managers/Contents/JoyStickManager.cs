using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JoyStickManager : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField]
    private RectTransform lever;
    private RectTransform rectTransform;

    [SerializeField, Range(10, 150)]
    private float leverRange; // 레버를 일정 범위 이상으로 못 넘어가게 하기 위한 변수

    public bool _isInput;

    private Vector2 inputDirection;

    //public Define.JoystickType _joyStickType = Define.JoystickType.NotMove;

    PlayerController _player;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        _player = GameObject.FindObjectOfType<PlayerController>();
    }

    void Update()
    {
        if (_isInput)
            InputControlVector();
    }
    public void OnBeginDrag(PointerEventData eventData) // 드래그를 시작할 때
    {
        _isInput = true;
        ControlJoystickLever(eventData);
    }

    public void OnDrag(PointerEventData eventData) // 드래그 중일때 
    {
        ControlJoystickLever(eventData);
    }

    public void OnEndDrag(PointerEventData eventData) // 드래그가 끝날을 때
    {
        _isInput = false;
        inputDirection = Vector2.zero;
        lever.anchoredPosition = Vector2.zero; // 드래그가 끝나면 처음 위치로 돌아감
    }
    private void ControlJoystickLever(PointerEventData eventData)
    {
        var inputPos = eventData.position - rectTransform.anchoredPosition; // 터치 위치를 반환해줌
        var inputVector = inputPos.magnitude < leverRange ? inputPos : inputPos.normalized * leverRange;
        lever.anchoredPosition = inputVector;
        inputDirection = inputVector / leverRange;
    }

    public void InputControlVector() // 캐릭터에게 입력벡터를 전달하는 함수
    {
        _player.Move(inputDirection);
    }
}


