using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class HealthSliderView : MonoBehaviour
{
    [SerializeField] private BaseHealth _health;

    protected Slider Slider;

    protected int MaxHealth => _health.MaxHealth;
    protected int CurrentHealth => _health.CurrentHealth;

    private void Awake()
    {
        Slider = GetComponent<Slider>();
    }

    private void OnEnable()
    {
        _health.HealthChanged += UpdateHealthValue;
    }

    private void OnDisable()
    {
        _health.HealthChanged -= UpdateHealthValue;
    }

    protected virtual void UpdateHealthValue()
    {
        Slider.maxValue = MaxHealth;
        Slider.value = CurrentHealth;
    }
}
