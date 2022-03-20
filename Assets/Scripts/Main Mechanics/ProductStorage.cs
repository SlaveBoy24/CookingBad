using System.Collections.Generic;
using UnityEngine;

public class ProductStorage : MonoBehaviour
{
    [SerializeField] private List<Product> _products;

    public void AddProduct(float purity, string type, float amount)
    {
        switch (type)
        {
            case "Meth": _products[(int)purity / 25].SetAmount(amount); break;
        }
    }

    public List<Product> GetProduct()
    {
        return _products;
    }
}
