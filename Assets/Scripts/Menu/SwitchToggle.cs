using UnityEngine;
using UnityEngine.UI;

public class SwitchToggle : MonoBehaviour
{
    [SerializeField] private RectTransform _uiHandleRectTransform;
    private Toggle _toggle;
    private Vector2 _handlePosition;

    private void Awake() {
        _toggle = GetComponent<Toggle>();

        _handlePosition = _uiHandleRectTransform.anchoredPosition;

        _toggle.onValueChanged.AddListener(OnSwitch);

        if(_toggle.isOn){
            OnSwitch(true);
        }
    }

    void OnSwitch(bool on){
        _uiHandleRectTransform.anchoredPosition = on ? _handlePosition * -1 : _handlePosition;
    }
}
