using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicReactorLight : MonoBehaviour
{
    [Range(0, 7)] public int syncBand;

    public float minValue;
    public float maxValue;

    private Light _light;

    void Start()
    {
        _light = GetComponent<Light>();
    }

    void Update()
    {
        var audioVal = AudioSpectrum.audioBandBuffer[syncBand];
        var paramVal = Mathf.Lerp(minValue, maxValue, audioVal);
        _light.intensity = paramVal;
    }
}
