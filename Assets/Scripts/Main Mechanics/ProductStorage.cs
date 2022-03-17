using System.Collections.Generic;
using UnityEngine;

public class ProductStorage : MonoBehaviour
{
    [SerializeField] private List<Product> _products;

    private void Start()
    {
        /*_products = new List<Product>();*/
    }

    public void AddProduct(float purity, string type, float amount)
    {
        /*if (purity >= 75 && purity <= 100)
        {
            _product[0] += amount;
        }
        else if (purity >= 50 && purity <= 74)
        {
            _product[1] += amount;
        }
        else if (purity >= 25 && purity <= 49)
        {
            _product[2] += amount;
        }
        else if (purity >= 0 && purity <= 24)
        {
            _product[3] += amount;
        }*/

        switch (type)
        {
            case "Meth": _products[(int)purity / 25].SetAmount(amount); break;
            /*case "Ger": _products[(int)purity / 25 + 4].SetAmount(amount); break;
            case "Weed": _products[(int)purity / 25 + 8].SetAmount(amount); break;
            case "LSD": _products[(int)purity / 25 + 12].SetAmount(amount); break;*/
        }
    }

    public List<Product> GetProduct()
    {
        return _products;
    }
}
