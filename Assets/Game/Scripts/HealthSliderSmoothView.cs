using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthSliderSmoothView : HealthSliderView
{
    [SerializeField] private float _smoothUpdateDuration;

    private IEnumerator _smoothCoroutine;

    protected override void UpdateHealthValue()
    {
        Slider.maxValue = MaxHealth;

        if (_smoothCoroutine != null)
            StopCoroutine(_smoothCoroutine);

        _smoothCoroutine = SmoothSliderChange(CurrentHealth);
        StartCoroutine(_smoothCoroutine);
    }

    private IEnumerator SmoothSliderChange(float target)
    {
        float elapsedTime = 0;
        float startValue = Slider.value;

        while (elapsedTime < _smoothUpdateDuration)
        {
            elapsedTime += Time.deltaTime;
            float normalizedPosition = elapsedTime / _smoothUpdateDuration;
            float easedNormalizedPosition = 1 - Mathf.Pow(1 - normalizedPosition, 4);
            int intermedaiteValue = Mathf.RoundToInt(Mathf.Lerp(startValue, target, easedNormalizedPosition));
            Slider.value = intermedaiteValue;
            
            yield return null;
        }
    }
}
