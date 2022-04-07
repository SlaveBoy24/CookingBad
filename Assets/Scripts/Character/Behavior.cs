using UnityEngine;
using UnityEngine.SceneManagement;

public class Behavior : MonoBehaviour
{
    [SerializeField] private string _condition;
    [SerializeField] private Cooking _workProcess;
    [SerializeField] private CleanStation _cleanProcess;
    [SerializeField] private Idle _characterIdle;

    private void Start()
    {
        if (SceneManager.GetActiveScene().name == "Work")
        {
            _workProcess = GameObject.FindGameObjectWithTag("GameManager").GetComponent<Cooking>();
            _cleanProcess = GameObject.FindGameObjectWithTag("GameManager").GetComponent<CleanStation>();
            _characterIdle = GetComponent<Idle>();
            
            SetCondition("Idle");
        }
        else if (SceneManager.GetActiveScene().name == "Home")
        {
            Debug.Log("sosi durak");
        }
    }

    public void SetCondition(string condition)
    {
        if (_condition == "Idle")
            _characterIdle.StopIdle();

        if (condition == "Idle" && _condition != condition)
        {
            _condition = condition;
            _characterIdle.StartIdle(_condition);
        }
        else if (condition == "Working" && _condition == "Idle")
        {
            _condition = condition;
            _workProcess.WorkStatus(_condition);
        }
        else if (condition == "Cleaning" && _condition == "Idle")
        {
            _condition = condition;
            _cleanProcess.StartCleaning(_condition);
        }
        else if (condition == "At Home")
        {
            _condition = condition;
        }
    }

    public string GetCondition()
    {
        return _condition;
    }
}
