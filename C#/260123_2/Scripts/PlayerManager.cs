using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    IMove     move;
    IRotate rotate;

    float moveValue;

    void Start()
    {
          move = GetComponent<  IMove>();
        rotate = GetComponent<IRotate>();
    }

    private void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw  ("Vertical");

        Vector2 input = new Vector2(h, v);

        moveValue = move?.Invoke(input) ?? 0;
        rotate?.Invoke(h);
    }

    public float GetMoveValue() => moveValue;
}
