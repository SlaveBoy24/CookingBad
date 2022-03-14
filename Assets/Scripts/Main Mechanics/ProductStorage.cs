using System.Collections.Generic;
using UnityEngine;

public class ProductStorage : MonoBehaviour
{
    [SerializeField] private List<float> _product;

    public void AddProduct(float purity, float amount)
    {
        if (purity >= 75 && purity <= 100)
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
        }
    }

    public List<float> GetProduct()
    {
        return _product;
    }
}
