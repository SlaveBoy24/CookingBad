using UnityEngine;
using UnityEngine.UI;

public class StorageRowManager : MonoBehaviour
{
    [SerializeField] private GameObject _rowAssets;
    [SerializeField] private Text _amount;   

    public void UpdateData(float amount)
    {
        if (amount > 0)
        {
            _rowAssets.SetActive(true);
            _amount.text = "Amount: " + amount + "g";
        }
        else
        {
            _rowAssets.SetActive(false);
        }
    }
}
