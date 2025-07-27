using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class HealthViewBase : MonoBehaviour
{
    [SerializeField] private BaseHealth _health;
    [SerializeField, Min(0.005f)] private float _smoothDuration; 

    protected ValueSmoother Smoother;

    protected int MaxHealth => _health.MaxHealth;
    protected float CurrentValue => (float)_health.CurrentHealth / _health.MaxHealth;

    protected virtual void Awake()
    {
        Smoother = new ValueSmoother(_smoothDuration);
    }

    protected virtual void OnEnable()
    {
        _health.HealthChanged += OnHealthChanged;
        Smoother.NumberChanged += OnSmoothValueChanged;
    }

    protected virtual void OnDisable()
    {
        _health.HealthChanged -= OnHealthChanged;
        Smoother.NumberChanged -= OnSmoothValueChanged;
    }

    protected abstract void OnHealthChanged(int health);

    protected abstract void OnSmoothValueChanged(float intermediateValue);
}
