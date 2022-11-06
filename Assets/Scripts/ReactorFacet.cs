using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ReactorFacet
{
    public Parameter Param;
    
    public float MinValue;
    public float MaxValue;
    
    public float RestingValue;
    
    public bool IsActive;
    public MusicReactor Owner;

    private const string _alphaString = "_alpha";
    private const string _metallicString = "_metallic";
    private const string _smoothnessString = "_smoothness";
    private const string _vertexDisplacementString = "_vert_displace_amount";
    private const string _vertexResolutionString = "_vert_res";
    private const string _glimmerString = "_sparkle_intensity";

    public enum Parameter
    {
        Opacity,
        Reflectivity,
        VertexDisplacement,
        VertexResolution,
        Glimmer
    }

    public void Tick()
    {
        if (!IsActive)
        {
            SetActive(false);
            return;
        }
        var audioVal = AudioSpectrum.audioBandBuffer[Owner.syncBand];
        Debug.Log(audioVal);
        var paramVal = Mathf.Lerp(MinValue, MaxValue, audioVal);
        switch (Param)
        {
            case Parameter.Opacity:
                UpdateValue(_alphaString, paramVal);
                break;
            case Parameter.Reflectivity:
                UpdateValue(_metallicString, paramVal);
                UpdateValue(_smoothnessString, paramVal);
                break;
            case Parameter.VertexDisplacement:
                UpdateValue(_vertexDisplacementString, paramVal);
                break;
            case Parameter.VertexResolution:
                UpdateValue(_vertexResolutionString, paramVal);
                break;
            case Parameter.Glimmer:
                UpdateValue(_glimmerString, paramVal);
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    private void UpdateValue(string valueName, float paramVal)
    {
        foreach (var mat in Owner.mats)
        {
            mat.SetFloat(valueName, paramVal);
        }
    }

    public void SetActive(bool active)
    {
        IsActive = active;
        if (IsActive) return;
        switch (Param)
        {
            case Parameter.Opacity:
                UpdateValue(_alphaString, RestingValue);
                break;
            case Parameter.Reflectivity:
                UpdateValue(_metallicString, RestingValue);
                UpdateValue(_smoothnessString, RestingValue);
                break;
            case Parameter.VertexDisplacement:
                UpdateValue(_vertexDisplacementString, RestingValue);
                break;
            case Parameter.VertexResolution:
                UpdateValue(_vertexResolutionString, RestingValue);
                break;
            case Parameter.Glimmer:
                UpdateValue(_glimmerString, RestingValue);
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
    
    
}
