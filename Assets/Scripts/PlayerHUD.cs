using System;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHUD : MonoBehaviour
{
    [SerializeField] private Slider healthBar;
    
    private void Start()
    {
        PlayerController player = FindAnyObjectByType<PlayerController>();
        player.OnPlayerTakeDamage.AddListener(UpdateHealthUI);
        
        UpdateHealthUI(player.GetHealthPercentage());
    }   

    private void UpdateHealthUI(float percentage)
    {
        healthBar.value = percentage;
    }
}
