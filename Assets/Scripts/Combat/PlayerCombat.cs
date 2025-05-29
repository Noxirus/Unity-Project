using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    private InputController _inputController;
    
    [Header("Weapon Details")]
    [SerializeField] private Weapon equippedWeapon;

    private void Awake()
    {
        _inputController = GetComponent<InputController>();
        if (equippedWeapon == null)
        {
            equippedWeapon = GetComponentInChildren<Weapon>();
        }
    }

    private void Start()
    {
        _inputController.AttackEvent += UseWeapon;
        _inputController.AttackEventCancelled += StopUsingWeapon;
    }

    void UseWeapon()
    {
        equippedWeapon.Use();
    }
    void StopUsingWeapon()
    {
        equippedWeapon.StopUsing();
    }
}
