using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(TextMeshProUGUI))]
public class SliderTextView : MonoBehaviour
{
    [SerializeField] private Slider _slider;

    private TextMeshProUGUI _sliderText;

    private void OnValidate()
    {
        if (_slider == null)
            return;

        _sliderText = GetComponent<TextMeshProUGUI>();
        _slider.onValueChanged.AddListener(UpdateText);
    }

    private void Awake()
    {
        _sliderText = GetComponent<TextMeshProUGUI>();
    }

    private void OnEnable()
    {
        _slider.onValueChanged.AddListener(UpdateText);
    }

    private void OnDisable()
    {
        _slider.onValueChanged.RemoveListener(UpdateText);
    }

    private void UpdateText(float value)
    {
        _sliderText.text = value + "/" + _slider.maxValue;
    }
}
