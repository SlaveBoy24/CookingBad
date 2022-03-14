using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    [SerializeField] private string _location;

    [SerializeField] private GameObject _cookFacilities;
    [SerializeField] private GameObject _cookingMap;
    [SerializeField] private GameObject _homeFacilities;
    [SerializeField] private GameObject _homeMap;
    [SerializeField] private Behavior _character;
    [SerializeField] private Transform _spawnPoint;

    public void ChangeScene(string map)
    {
        if (map == "lab")
            ToLab();
        else if (map == "home")
            ToHome();
    }

    public string GetLocation()
    {
        return _location;
    }

    //private void ToHome()
    //{
    //    _cookFacilities.SetActive(false);
    //    _cookingMap.SetActive(false);
    //    _homeMap.SetActive(true);
    //    _homeFacilities.SetActive(true);
    //    _character.gameObject.transform.position = _spawnPoint.position;
    //    _character.SetCondition("At Home");

    //    _location = "home";
    //}

    //private void ToLab()
    //{
    //    _cookFacilities.SetActive(true);
    //    _cookingMap.SetActive(true);
    //    _homeMap.SetActive(false);
    //    _homeFacilities.SetActive(false);
    //    _character.gameObject.transform.position = _spawnPoint.position;
    //    _character.SetCondition("Idle");

    //    _location = "lab";
    //}

    private void ToHome()
    {

    }

    private void ToLab()
    {

    }
}
