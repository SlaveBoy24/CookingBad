using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    [SerializeField] private string _location;


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

    private void ToHome()
    {
        SceneManager.LoadScene("Home");
    }

    private void ToLab()
    {
        SceneManager.LoadScene("Work");
    }
}
