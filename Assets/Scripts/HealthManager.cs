using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class HealthManager : MonoBehaviour
{
    [SerializeField] float _maxHealth = 100;

    private float _currentHealth;

    public Action<float> HealthChanged;

    public float CurrentHealth { get => _currentHealth; }
    public float MaxHealth { get => _maxHealth; set => _maxHealth = value; }

    private void Start()
    {
        _currentHealth = _maxHealth;
        HealthChanged?.Invoke(CurrentHealth);
    }

    public void TakeDamage(float damage)
    {
        _currentHealth -= damage;
        HealthChanged?.Invoke(CurrentHealth);
        if (CurrentHealth <= 0)
        {
            Time.timeScale = 0;
            Debug.Log("Вы проиграли...");
        }
    }

}
