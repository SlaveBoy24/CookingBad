using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Idle : MonoBehaviour
{
    [SerializeField] private GameObject[] _stations;
    [SerializeField] private GameObject _currentStation;
    [SerializeField] private Moving _characterMove;

    private void Start()
    {
        if (SceneManager.GetActiveScene().name == "Work")
        {
            _characterMove = this.GetComponent<Moving>();

            Transform stationsParent = GameObject.FindGameObjectWithTag("station").transform;
            _stations = new GameObject[stationsParent.childCount];

            for (int i = 0; i < stationsParent.childCount; i++)
            {
                _stations[i] = stationsParent.GetChild(i).gameObject;
            }
        }
    }

    public void StartIdle(string condition)
    {
        if (condition == "Idle" || condition == "idle")
            StartCoroutine("IdleProcess");
    }

    public void StopIdle()
    {
        StopAllCoroutines();
    }

    private IEnumerator IdleProcess()
    {
        yield return new WaitForSeconds(4);

        if (_currentStation == null)
            _currentStation = _stations[0];
        else
        {
            while (true)
            {
                int rand = Random.Range(0, _stations.Length);
                if (_stations[rand] != _currentStation)
                {
                    _currentStation = _stations[rand];
                    break;
                }

                yield return null;
            }
        }

        while (_characterMove.MoveTo(_currentStation))
            yield return null;

        StartCoroutine("IdleProcess");
    }
}
