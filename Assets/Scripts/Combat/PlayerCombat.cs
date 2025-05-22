using System;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    private InputController _inputController;
    [SerializeField] private Weapon equippedWeapon;

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
        equippedWeapon.Fire();
    }
    void StopFiring()
    {
        equippedWeapon.StopFiring();
    }
}
