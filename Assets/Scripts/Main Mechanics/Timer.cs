using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] private GameObject _uiPoint;
    [SerializeField] private GameObject _canvas;
    [SerializeField] private float _timerHeight;
    private bool _checkPos;

    private float _time;
    private float _timeLeft;

    [SerializeField] private Slider _slider;

    public bool WorkTimer(float time)
    {
        if (!_checkPos)
        {
            RectTransform CanvasRect = _canvas.GetComponent<RectTransform>();
            Vector2 ViewportPosition = Camera.main.WorldToViewportPoint(_uiPoint.transform.position);
            Vector2 UiPoint_ScreenPosition = new Vector2(
            ((ViewportPosition.x * CanvasRect.sizeDelta.x) - (CanvasRect.sizeDelta.x * 0.5f)),
            ((ViewportPosition.y * CanvasRect.sizeDelta.y) - (CanvasRect.sizeDelta.y * _timerHeight)));
            _slider.GetComponent<RectTransform>().anchoredPosition = UiPoint_ScreenPosition;

            _checkPos = true;
        }

        _slider.gameObject.SetActive(true);
        _time = time;
        _slider.maxValue = _time;

        if (_timeLeft < _time)
        {
            _timeLeft += Time.deltaTime;
            _slider.value = _timeLeft;
        }
        else
        {
            _slider.gameObject.SetActive(false);
            _slider.value = 0; // обнуление  таймера
            _timeLeft = 0; // обнуление таймера
            _checkPos = false; // обнуление флага расчета позиции
            return false;
        }

        return true;
    }
}
