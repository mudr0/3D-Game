using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    [SerializeField] float MaxHealth = 100;

    private float _currentHealth;

    private void Start()
    {
        _currentHealth = MaxHealth;
    }

    public void TakeDamage(float damage)
    {
        _currentHealth -= damage;
        Debug.Log($"HP: {_currentHealth}");
        if (_currentHealth <= 0)
        {
            Time.timeScale = 0;
            Debug.Log("Вы проиграли...");
        }
    }

}
