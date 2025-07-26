using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class SliderHealthView : HealthViewBase
{
    protected Slider Slider;

    protected override void OnValidate()
    {
        if (Slider == null)
            return;

        base.OnValidate();
    }

    protected override void Awake()
    {
        Slider = GetComponent<Slider>();
        OnHealthChanged(CurrentHealth);
        base.Awake();
    }

    protected override void OnHealthChanged(int health)
    {
        Slider.maxValue = MaxHealth;
        SmoothNumberChange(Slider.value, health);
    }

    protected override void OnSmoothNumberChanged(int intermediateValue)
    {
        Slider.value = intermediateValue;
    }
}
