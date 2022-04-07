using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CleanStation : MonoBehaviour
{
    [SerializeField] private Behavior _characterCondition;
    [SerializeField] private Moving _characterMove;
    [SerializeField] private Station[] _stations;
    private bool _cleanProcess;

    [SerializeField] private Timer _timer;

    [SerializeField] private bool[] _stages;
    [SerializeField] private int _stageNumber;

    private void Start()
    {
        _timer = GameObject.FindGameObjectWithTag("GameManager").GetComponent<Timer>();

        _characterMove = GameObject.FindGameObjectWithTag("Character").GetComponent<Moving>();
        _characterCondition = GameObject.FindGameObjectWithTag("Character").GetComponent<Behavior>();

        Transform stationsParent = GameObject.FindGameObjectWithTag("station").transform;
        _stations = new Station[stationsParent.childCount];

        for (int i = 0; i < stationsParent.childCount; i++)
        {
            _stations[i] = stationsParent.GetChild(i).GetComponent<Station>();
        }
    }

    public void StartCleaning(string condition)
    {
        if (condition == "Cleaning" && !_cleanProcess)
        {
            bool checkStages = false;
            for (int i = 0; i < _stages.Length; i++)
                if (!_stages[i])
                    checkStages = true;

            if (!checkStages)
                for (int i = 0; i < _stages.Length; i++)
                    _stages[i] = false;

            CleanProcess();
        }
    }

    private void CleanProcess()
    {
        _stageNumber = 0;
        _cleanProcess = true;

        if (_stageNumber != 0)
            if (_stages[_stageNumber - 1] != true)
                Debug.Log("error, previous clening is not done");

        for (int i = 0; i < _stages.Length; i++)
            if (!_stages[i])
            {
                _stageNumber = i + 1;
                break;
            }

        if (_stageNumber == 0)
        {
            Debug.Log("Я ПОЧИСТИЛ НАХУЙ");

            _cleanProcess = false;
            _characterCondition.SetCondition("Idle");
            return;
        }

        StartCoroutine(Cleaning(_stageNumber));
    }

    private IEnumerator Cleaning(int stageNumber)
    {
        Station station = null;

        if (stageNumber != 0)
        {
            for (int i = 0; i < _stations.Length; i++)
                if (_stations[i].tag == "ST" + stageNumber)
                    station = _stations[i];

            if (station == null)
            {
                StopCoroutine("StartStage");
            }

            while (_characterMove.MoveTo(station.gameObject))
                yield return null;

            while (_timer.WorkTimer(10))
                yield return null;

            station.CleanStation();

            _stages[stageNumber - 1] = true;

            CleanProcess();
        }
    }
}
