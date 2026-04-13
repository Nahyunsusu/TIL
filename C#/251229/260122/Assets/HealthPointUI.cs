using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HealthPointUI : MonoBehaviour
{
    [SerializeField] private PlayerStats _playerStats;

    private TextMeshProUGUI _uiText;

    private void Awake()
    {
        _uiText = gameObject.AddComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        RefreshUI(_playerStats.Health);
    }

    private void OnEnable()
    {
        _playerStats.OnHealthChanged.AddListener(RefreshUI);
    }

    private void RefreshUI(int health)
    {
        _uiText.text = $"HP : {_playerStats.Health}";
    }
}
