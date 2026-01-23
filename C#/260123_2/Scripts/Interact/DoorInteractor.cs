using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorInteractor : MonoBehaviour, IInteractable
{
    [SerializeField] bool _isOpen;
    public void Interact()
    {
        _isOpen = !_isOpen;

        Debug.Log(_isOpen ? "문 열림" : "문 닫힘");

        // 기능1: 애니메이션 동작
        // 기능2: 기능 동작
    }
}
