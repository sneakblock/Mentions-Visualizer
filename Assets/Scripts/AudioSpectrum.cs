using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSpectrum : MonoBehaviour
{
    public AudioSource audioSource;
    public int samples = 512;

    public float[] spectrumData;
    
    // Start is called before the first frame update
    void Start()
    {
        spectrumData = new float[samples];
    }

    // Update is called once per frame
    void Update()
    {
        if (audioSource) GetSpectrumData(audioSource);
    }

    private void GetSpectrumData(AudioSource a)
    {
        a.GetSpectrumData(spectrumData, 0, FFTWindow.Blackman);
        
    }
}
