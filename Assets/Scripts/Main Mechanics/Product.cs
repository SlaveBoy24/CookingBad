using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Product", menuName = "Products", order = 51)]
public class Product : ScriptableObject
{
    [SerializeField] private string _type;
    [SerializeField] private Sprite _sprite;
    [SerializeField] private float _purity;
    [SerializeField] private float _amount;

    public void SetAmount(float amount)
    {
        _amount += amount;
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
