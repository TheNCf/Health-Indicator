using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ValueSmoother : MonoBehaviour
{
    [SerializeField, Min(0.005f)] private float _smoothUpdateDuration;

    private IEnumerator _smoothCoroutine;

    protected event Action<int> SmoothNumberChanged;

    protected abstract void OnSmoothNumberChanged(int intermediateValue);

    protected void SmoothNumberChange(float start, float target)
    {
        if (_smoothCoroutine != null)
            StopCoroutine(_smoothCoroutine);

        _smoothCoroutine = SmoothNumberChangeCoroutine(start, target);
        StartCoroutine(_smoothCoroutine);
    }

    private IEnumerator SmoothNumberChangeCoroutine(float start, float target)
    {
        float elapsedTime = 0;
        float startValue = start;

        while (elapsedTime < _smoothUpdateDuration)
        {
            elapsedTime += Time.deltaTime;
            float normalizedPosition = elapsedTime / _smoothUpdateDuration;
            float easedNormalizedPosition = 1 - Mathf.Pow(1 - normalizedPosition, 4);
            int intermedaiteValue = Mathf.RoundToInt(Mathf.Lerp(startValue, target, easedNormalizedPosition));
            SmoothNumberChanged?.Invoke(intermedaiteValue);

            yield return null;
        }
    }
}
