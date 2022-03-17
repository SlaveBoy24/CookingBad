using System.Collections;
using UnityEngine;

public class Cooking : MonoBehaviour
{
    [SerializeField] private bool _workProcess;

    [SerializeField] private Moving _characterMove;
    [SerializeField] private Behavior _characterCondition;
    [SerializeField] private ProductStorage _productStorage;
    [SerializeField] private Station[] _stations;

    [SerializeField] private Timer _timer;
    [SerializeField] private PurityCalculator _purityCalculator;

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

    public void WorkStatus(string characterCondition)
    {
        if (characterCondition == "Working" && !_workProcess)
        {
            _purityCalculator.SetPurityNull();

            bool checkStages = false;
            for (int i = 0; i < _stages.Length; i++)
                if (!_stages[i])
                    checkStages = true;

            if (!checkStages)
                for (int i = 0; i < _stages.Length; i++)
                    _stages[i] = false;

            CookProcess();
        }
    }

    private void CookProcess()
    {
        _stageNumber = 0;
        _workProcess = true;

        if (_stageNumber != 0)
            if (_stages[_stageNumber - 1] != true)
                Debug.Log("error, previous stage is not done");

        for (int i = 0; i < _stages.Length; i++)
            if (!_stages[i])
            {
                _stageNumber = i + 1;
                break;
            }

        if (_stageNumber == 0)
        {
            _purityCalculator.TotalPurity();

            for (int i = 0; i < _stations.Length; i++)
                _stations[i].SetPollution();

            StartCoroutine("EndCooking");

            return;
        }

        StartCoroutine(StartStage(_stageNumber));
    }

    private IEnumerator StartStage(int stageNumber)
    {
        Station station = null;

        if (stageNumber != 0)
        {
            for (int i = 0; i < _stations.Length; i++)
                if (_stations[i].tag == "ST" + stageNumber)
                    station = _stations[i];

            if (station == null)
            {
                CookProcess();
                StopCoroutine("StartStage");
            }

            while (_characterMove.MoveTo(station.gameObject))
                yield return null;

            while (_timer.WorkTimer(station.GetWorkTime()))
                yield return null;

            _purityCalculator.SetPurity(station);

            _stages[stageNumber - 1] = true;

            CookProcess();
        }
    }

    private IEnumerator EndCooking()
    {
        while (_characterMove.MoveTo(_productStorage.gameObject))
            yield return null;

        _productStorage.AddProduct(_purityCalculator.GetPurity(), "Meth", 50); // занос товара на склад
        Debug.Log("Я СВАРИЛ НАХУЙ");

        _workProcess = false;
        _characterCondition.SetCondition("Idle");
    }
}
