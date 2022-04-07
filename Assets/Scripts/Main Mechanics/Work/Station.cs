using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Station : MonoBehaviour
{
    [SerializeField] private GameObject _uiPoint;
    [SerializeField] private GameObject _canvas;

    [SerializeField] private float _workTime; // таймер
    [SerializeField] private float _productPurity; // чистота продукта в процентах
    [SerializeField] private float _pollution; // загрязнение аппарата
    [SerializeField] private Text _pollutionText;

    public float GetWorkTime()
    {
        return _workTime;
    }

    public float GetProductPurity()
    {
        return _productPurity;
    }

    public float GetPollution()
    {
        return _pollution;
    }

    public void SetPollution()
    {
        RectTransform CanvasRect = _canvas.GetComponent<RectTransform>();
        Vector2 ViewportPosition = Camera.main.WorldToViewportPoint(_uiPoint.transform.position);
        Vector2 UiPoint_ScreenPosition = new Vector2(
        ((ViewportPosition.x * CanvasRect.sizeDelta.x) - (CanvasRect.sizeDelta.x * 0.5f)),
        ((ViewportPosition.y * CanvasRect.sizeDelta.y) - (CanvasRect.sizeDelta.y * 0.5f)));
        _pollutionText.GetComponent<RectTransform>().anchoredPosition = UiPoint_ScreenPosition;

        _pollution += Random.Range(15, 25);

        if (_pollution > 100)
            _pollution = 100;

        _pollutionText.text = _pollution + "%";
        _pollutionText.gameObject.SetActive(true);
    }

    public void CleanStation()
    {
        _pollution = 0;
        _pollutionText.gameObject.SetActive(false);
    }
}
