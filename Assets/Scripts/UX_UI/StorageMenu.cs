using System.Collections.Generic;
using UnityEngine;

public class StorageMenu : MonoBehaviour
{
    [SerializeField] private GameObject _rowPrefab;
    [SerializeField] private ProductStorage _storage;
    [SerializeField] private Transform _menuStorageUI; //parent to row child
    private List<GameObject> _rows = new List<GameObject>();

    private void Start()
    {
        _storage = this.GetComponent<ProductStorage>();
    }

    public void UpdateInfo()
    {
        if (_rows.Count != 0)
            foreach (var row in _rows)
                Destroy(row);

        List<Product> products = _storage.GetProduct();
        Vector3 rowPosition = _menuStorageUI.transform.position;
        rowPosition.y = 160;
        for (int i = 0; i < products.Count; i++)
            if (products[i].GetAmount() > 0)
            {
                GameObject row = _rowPrefab;
                products[i].UpdateRowUI(ref row);
                GameObject rowChild = Instantiate(row);
                rowChild.transform.SetParent(_menuStorageUI);
                rowChild.transform.localPosition = rowPosition;
                rowChild.transform.localScale = Vector3.one;
                rowPosition.y -= 140;

                _rows.Add(rowChild);
            }
    }

    [SerializeField] private GameObject _storageUI;
    /*s[SerializeField] private List<StorageRowManager> _rows;
    [SerializeField] private SellProduct _partner;

    private void Start()
    {
        _partner = GameObject.FindGameObjectWithTag("Partner").GetComponent<SellProduct>();
    }*/

    private void OnMouseDown()
    {
        UpdateInfo();
        OpenStorage();
    }

    public void OpenStorage()
    {
        Time.timeScale = 0f;

        /*List<float> products = this.GetComponent<ProductStorage>().GetProduct();

        for (int i = 0; i < products.Count; i++)
        {
            _rows[i].UpdateData(products[i]);
        }*/

        _storageUI.SetActive(true);
    }

    public void CloseStorage()
    {
        Time.timeScale = 1f;

        _storageUI.SetActive(false);
    }
/*
    public void SendProduct(int index)
    {
        List<float> products = this.GetComponent<ProductStorage>().GetProduct();

        _partner.GetInfo(products[index], index);
    }*/
}