using UnityEngine;
using UnityEngine.UI;

public class PurityCalculator : MonoBehaviour
{
    [SerializeField] private Text _productPurity;
    [SerializeField] private Skills _characherSkills;

    private float _purity;

    private void Start()
    {
        _characherSkills = GameObject.FindGameObjectWithTag("Character").GetComponent<Skills>();
    }

    public float GetPurity()
    {
        return _purity;
    }

    public void UpdatePurityText()
    { 
        _productPurity.text = "Чистота продукта: " + _purity;
    }

    public void SetPurityNull()
    {
        _purity = 0;

        UpdatePurityText();
    }

    public void TotalPurity()
    {
        _purity -= _characherSkills.GetSkill();
        UpdatePurityText();

        _characherSkills.SetSkill(2);
    }

    public void SetPurity(Station station)
    {
        float purity;
        purity = station.GetProductPurity() / (1 + station.GetPollution() / 100);

        _purity += purity;

        if (_purity > 100)
            _purity = 100;
        else if (_purity < 0)
            _purity = 10;

        UpdatePurityText();
    }
}
