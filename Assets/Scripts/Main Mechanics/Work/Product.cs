using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Product
{
    [SerializeField] private string _type;
    [SerializeField] private Sprite _sprite;
    [SerializeField] private float _purity;
    [SerializeField] private float _amount;

    public void IncreaseAmount(float amount)
    {
        _amount += amount;
    }

    public void DropAmount()
    {
        _amount = 0;
    }

    public float GetAmount()
    {
        return _amount;
    }

    public void UpdateRowUI(ref GameObject row)
    {
        row.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = _type;
        row.transform.GetChild(0).GetChild(1).GetComponent<Image>().sprite = _sprite;
        row.transform.GetChild(0).GetChild(2).GetComponent<Text>().text = "Amount: " + _amount;
    }

    public string GetName() 
    {
        return _type;
    }
}
