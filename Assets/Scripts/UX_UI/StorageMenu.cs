using System.Collections.Generic;
using UnityEngine;

public class StorageMenu : MonoBehaviour
{
    [SerializeField] private GameObject _storageUI;
    [SerializeField] private List<StorageRowManager> _rows;
    [SerializeField] private SellProduct _partner;

    private void Start()
    {
        _partner = GameObject.FindGameObjectWithTag("Partner").GetComponent<SellProduct>();
    }

    private void OnMouseDown()
    {
        OpenStorage();
    }

    public void OpenStorage()
    {
        Time.timeScale = 0f;

        List<float> products = this.GetComponent<ProductStorage>().GetProduct();

        for (int i = 0; i < products.Count; i++)
        {
            _rows[i].UpdateData(products[i]);
        }

        _storageUI.SetActive(true);
    }

    public void CloseStorage()
    {
        Time.timeScale = 1f;

        _storageUI.SetActive(false);
    }

    public void SendProduct(int index)
    {
        List<float> products = this.GetComponent<ProductStorage>().GetProduct();

        _partner.GetInfo(products[index], index);
    }
}