using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StorageMenu : MonoBehaviour
{
    [SerializeField] private GameObject _rowPrefab;
    [SerializeField] private ProductStorage _storage;
    [SerializeField] private Transform _menuStorageUI; //parent to row child
    [SerializeField] private GameObject _storageUI;

    [SerializeField] private SellProduct _partner;

    private List<GameObject> _rows = new List<GameObject>();

    private void Start()
    {
        _storage = this.GetComponent<ProductStorage>();
        _partner = GameObject.FindGameObjectWithTag("Partner").GetComponent<SellProduct>();
    }

    public void UpdateInfo()
    {
        if (_rows.Count != 0)
            foreach (var row in _rows)
                Destroy(row);

        List<Product> products = _storage.GetProduct();
        Vector3 rowPosition = _menuStorageUI.transform.position;
        rowPosition.y = 160;
        for (int i = products.Count-1; i >= 0; i--)
            if (products[i].GetAmount() > 0)
            {
                products[i].UpdateRowUI(ref _rowPrefab);
                GameObject rowChild = Instantiate(_rowPrefab);
                rowChild.transform.SetParent(_menuStorageUI);
                rowChild.transform.localPosition = rowPosition;
                rowChild.transform.localScale = Vector3.one;
                rowPosition.y -= 140;

                Product product = products[i];

                rowChild.transform.GetChild(0).GetChild(3).GetComponent<Button>().onClick.AddListener(() => SendProduct(product));
            }
    }

    public void SendProduct(Product product)
    {
        _partner.GetProduct(product);
    }

    private void OnMouseDown()
    {
        OpenStorage();
    }

    public void OpenStorage()
    {
        Time.timeScale = 0f;

        UpdateInfo();

        _storageUI.SetActive(true);
    }

    public void CloseStorage()
    {
        Time.timeScale = 1f;

        _storageUI.SetActive(false);
    }
}