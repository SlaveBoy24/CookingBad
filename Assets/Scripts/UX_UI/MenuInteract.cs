using UnityEngine;

public class MenuInteract : MonoBehaviour
{
    [SerializeField] private GameObject _menu;

    private float _axisX;
    private float _axisY;

    private void OnMouseDown()
    {
        if (_menu.activeSelf)
            CloseMenu();
        else
            OpenMenu();
    }

    public void OpenMenu()
    {
        Time.timeScale = 0f;

        if (Screen.width != 1920)
            _axisX = Screen.width / 1920f;
        else
            _axisX = 1;

        if (Screen.height != 1080)
            _axisY = Screen.height / 1080f;
        else
            _axisY = 1;

        Vector2 menuPos;

        RectTransform menuRectTransform = _menu.GetComponent<RectTransform>();

        menuPos.x = (Input.mousePosition.x / _axisX + menuRectTransform.sizeDelta.x / 1.8f);
        menuPos.y = (Input.mousePosition.y / _axisY - menuRectTransform.sizeDelta.y / 1.8f);    

        if (menuPos.x * _axisX + menuRectTransform.sizeDelta.x / 2f > Screen.width)
            menuPos.x = (Input.mousePosition.x / _axisX - menuRectTransform.sizeDelta.x / 1.8f);

        if (Input.mousePosition.y * _axisY + menuRectTransform.sizeDelta.y / 2f > Screen.height)
            menuPos.y = (Input.mousePosition.y / _axisY - menuRectTransform.sizeDelta.y / 2);

        if (Input.mousePosition.x * _axisX - menuRectTransform.sizeDelta.x / 2f < 0)
            menuPos.x = (Input.mousePosition.x / _axisX + menuRectTransform.sizeDelta.x / 1.8f);

        if (menuPos.y * _axisY - menuRectTransform.sizeDelta.y / 2f < 0)
            menuPos.y = Input.mousePosition.y / _axisY;

        _menu.GetComponent<RectTransform>().anchoredPosition = menuPos;

        _menu.SetActive(true);
    }

    public void CloseMenu()
    {
        if (_menu.activeSelf)
            _menu.SetActive(false);

        Time.timeScale = 1f;
    }
}
