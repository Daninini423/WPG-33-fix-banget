using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class DayAndNightCycle : MonoBehaviour
{

    [System.Serializable]
    public struct DayAndNightMark
    {
        public float timeRatio;
        public Color color;
        public float intensity;

    }

    [SerializeField] private DayAndNightMark[] _marks;
    [SerializeField] private float _cyclelength = 24; //in second
    [SerializeField] private Light2D _light;

    private const float _TIME_CHECK_EPSILON = 0.1f;

    private float _currentCycleTime;
    private int _currentMarkIndex, _nextMarkIndex;
    private float _currentMarkTime, _nextMarkTime;



    void Start()
    {
        _currentCycleTime = 0f;
        _currentMarkIndex = -1;
        _CycleMarks();
    }


    void Update()
    {
        _currentCycleTime = (_currentCycleTime + Time.deltaTime) % _cyclelength;

        // passed a mark?
        if (Mathf.Abs(_currentCycleTime - _nextMarkTime) < _TIME_CHECK_EPSILON)
        {
            DayAndNightMark next = _marks[_nextMarkIndex];
            _light.color = next.color;
            _light.intensity = next.intensity;

            _CycleMarks();
        }
    }

    private void _CycleMarks()
    {
        _currentMarkIndex = (_currentMarkIndex + 1) % _marks.Length;
        _nextMarkIndex = (_currentMarkIndex + 1) % _marks.Length;
        _currentMarkTime = _marks[_currentMarkIndex].timeRatio * _cyclelength;
        _nextMarkTime = _marks[_nextMarkIndex].timeRatio * _cyclelength;
    }
}
