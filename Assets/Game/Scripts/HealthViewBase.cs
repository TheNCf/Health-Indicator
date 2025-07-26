using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class HealthViewBase : ValueSmoother
{
    [SerializeField] private BaseHealth _health;

    protected int MaxHealth => _health.MaxHealth;
    protected int CurrentHealth => _health.CurrentHealth;

    protected virtual void OnValidate()
    {
        _health.HealthChanged += OnHealthChanged;
    }

    protected virtual void Awake()
    {
        _health.HealthChanged -= OnHealthChanged;
    }

    protected virtual void OnEnable()
    {
        _health.HealthChanged += OnHealthChanged;
        SmoothNumberChanged += OnSmoothNumberChanged;
    }

    protected virtual void OnDisable()
    {
        _health.HealthChanged -= OnHealthChanged;
        SmoothNumberChanged -= OnSmoothNumberChanged;
    }

    protected abstract void OnHealthChanged(int health);
}
