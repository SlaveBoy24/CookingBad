using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SellProduct : MonoBehaviour
{
    [SerializeField] private GameObject _partnerUI;
    [SerializeField] private Text _btnGetMoney;
    [SerializeField] private GameObject _rowAssets;
    [SerializeField] private Image _image;
    [SerializeField] private Text _title;
    [SerializeField] private Text _amount;

    public void GetInfo(float amount, int purityIndex)
    {
        switch (purityIndex)
        {
            case 0: _image.color = Color.green; _title.text = "Good"; _amount.text = "Amount: " + amount; break;
            case 1: _image.color = Color.blue; _title.text = "Good"; _amount.text = "Amount: " + amount; break;
            case 2: _image.color = Color.magenta; _title.text = "Good"; _amount.text = "Amount: " + amount; break;
            case 3: _image.color = Color.red; _title.text = "Good"; _amount.text = "Amount: " + amount; break;
        }

        _rowAssets.SetActive(true);
    }

    private void OnMouseDown()
    {
        _partnerUI.SetActive(true);
    }
}
