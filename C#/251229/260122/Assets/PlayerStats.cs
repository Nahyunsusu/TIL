using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerStats : MonoBehaviour
{
    public UnityEvent<int> OnHealthChanged;
    public UnityEvent   OnManaChanged;
    public UnityEvent    OnExpChanged;

    private int _health;
    private int   _mana;
    private int    _exp;

    public int Health { get => _health; set { _health = value; OnHealthChanged?.Invoke(_health); } }
    public int   Mana { get =>   _mana; set {   _mana = value;   OnManaChanged?.Invoke(); } }
    public int    Exp { get =>    _exp; set {    _exp = value;    OnExpChanged?.Invoke(); } }


}
