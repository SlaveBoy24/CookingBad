using UnityEngine;
using UnityEngine.UI;

public class SellProduct : MonoBehaviour
{
    [SerializeField] private GameObject _partnerUI;
    [SerializeField] private Text _btnGetMoney;
    [SerializeField] private GameObject _rowAssets;

    [SerializeField] private bool _sellingProcess;

    public void GetProduct(Product product)
    {
        if (_sellingProcess)
        {
            Debug.Log("selling epta");

            product.UpdateRowUI(ref _rowAssets);
            _rowAssets.transform.GetChild(0).gameObject.SetActive(true);
            _sellingProcess = true;
        }
    }

    private void OnMouseDown()
    {
        _partnerUI.SetActive(true);
    }

    public void CloseUI()
    {
        _partnerUI.SetActive(false);
    }
}
