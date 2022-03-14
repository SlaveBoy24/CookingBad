using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeSystem : MonoBehaviour
{
    private int _day;
    private int _hour;
    private int _minute;

    [SerializeField] private Text _clock;
    [SerializeField] private Text _calendar;

    private float _timeLeft;

    private void Start()
    {
        _day = 1;
        _hour = 8;
        _timeLeft = 0;

        StartCoroutine("Ticker");
    }

    private IEnumerator Ticker()
    {
        while (true)
        {
            if (_timeLeft < 1)
            {
                _timeLeft += Time.deltaTime;
            }
            else
            {
                _timeLeft = 0;

                if (_minute < 56)
                {
                    _minute += 4;
                }
                else
                {
                    _minute = 0;
                    if (_hour < 23)
                    {
                        _hour++;
                    }
                    else
                    {
                        _hour = 0;
                        _day++;
                    }
                }
            }

            if (_hour < 10)
                _clock.text = "Time - 0" + _hour;
            else
                _clock.text = "Time - " + _hour;

            if (_minute < 10)
                _clock.text += ":0" + _minute;
            else
                _clock.text += ":" + _minute;

            _calendar.text = "Day - " + _day;
            yield return null;
        }
    }
}
