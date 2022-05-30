using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] HealthManager HealthManager;
    [SerializeField] Text HealthText;
    [SerializeField] Image HealthImage;

    void Start()
    {
        HealthManager.HealthChanged += OnHealthChanged;
        HealthText.text = HealthManager.CurrentHealth.ToString();
    }

    void Update()
    {
        
    }

    private void OnHealthChanged(float health)
    {
        HealthText.text = health.ToString();
        HealthImage.fillAmount = health / HealthManager.MaxHealth;
    }
}
