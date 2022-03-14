using System.Collections.Generic;
using UnityEngine;

public class StorageMenu : MonoBehaviour
{
    [SerializeField] private GameObject _storageUI;
    [SerializeField] private List<StorageRowManager> _rows;

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
}