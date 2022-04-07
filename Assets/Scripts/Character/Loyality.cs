using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loyality : MonoBehaviour
{
    [SerializeField] private int _loyality;

    public void SetLoyality(int value)
    {
        _loyality += value;
    }

    public int GetLoyality()
    {
        return _loyality;
    }
}
