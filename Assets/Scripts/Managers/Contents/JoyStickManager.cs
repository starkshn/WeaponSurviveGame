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
    private float leverRange; // ������ ���� ���� �̻����� �� �Ѿ�� �ϱ� ���� ����

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
    public void OnBeginDrag(PointerEventData eventData) // �巡�׸� ������ ��
    {
        _isInput = true;
        ControlJoystickLever(eventData);
    }

    public void OnDrag(PointerEventData eventData) // �巡�� ���϶� 
    {
        ControlJoystickLever(eventData);
    }

    public void OnEndDrag(PointerEventData eventData) // �巡�װ� ������ ��
    {
        _isInput = false;
        inputDirection = Vector2.zero;
        lever.anchoredPosition = Vector2.zero; // �巡�װ� ������ ó�� ��ġ�� ���ư�
    }
    private void ControlJoystickLever(PointerEventData eventData)
    {
        var inputPos = eventData.position - rectTransform.anchoredPosition; // ��ġ ��ġ�� ��ȯ����
        var inputVector = inputPos.magnitude < leverRange ? inputPos : inputPos.normalized * leverRange;
        lever.anchoredPosition = inputVector;
        inputDirection = inputVector / leverRange;
    }

    public void InputControlVector() // ĳ���Ϳ��� �Էº��͸� �����ϴ� �Լ�
    {
        _player.Move(inputDirection);
    }
}


