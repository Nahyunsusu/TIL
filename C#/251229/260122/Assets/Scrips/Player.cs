using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    List<IObserver> observers = new List<IObserver>();

    private int _health;
    public int Health 
    { 
        get => _health; 
        set 
        { 
            _health = value; Notify();
        } 
    }

    private void Notify()
    {
        foreach(IObserver observer in observers)
        {
            observer.OnNotify();
        }
    }
}
