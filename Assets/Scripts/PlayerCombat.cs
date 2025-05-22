using System;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    private InputController _inputController;

    private void Awake()
    {
        _inputController = GetComponent<InputController>();
    }

    private void Start()
    {
        _inputController.AttackEvent += FireWeapon;
        _inputController.AttackEventCancelled += StopFiring;
    }

    void FireWeapon()
    {
        Debug.Log("Firing the weapon!");
    }
    void StopFiring()
    {
        Debug.Log("Stopped Firing!");
        
    }
}
