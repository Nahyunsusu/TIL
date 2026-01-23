using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private PlayerStats _playerStats;

    private void Awake()
    {
        _playerStats = GetComponent<PlayerStats>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            _playerStats.Health--;
        }
    }
}
