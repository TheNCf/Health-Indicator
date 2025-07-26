using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(TextMeshProUGUI))]
public class TextHealthView : HealthViewBase
{
    private TextMeshProUGUI _healthText;

    private float _currentValue;

    protected override void OnValidate()
    {
        _currentValue = CurrentHealth;
        _healthText = GetComponent<TextMeshProUGUI>();
        base.OnValidate();
    }

    protected override void Awake()
    {
        _currentValue = CurrentHealth;
        _healthText = GetComponent<TextMeshProUGUI>();
        base.Awake();
    }

    protected override void OnHealthChanged(int health)
    {
        SmoothNumberChange(_currentValue, health);
    }

    protected override void OnSmoothNumberChanged(int intermediateValue)
    {
        UpdateText(intermediateValue);
    }

    private void UpdateText(float value)
    {
        _currentValue = value;
        _healthText.text = _currentValue + "/" + MaxHealth;
    }
}
