using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

[RequireComponent(typeof(CinemachineFreeLook))]
public class LookLocker : MonoBehaviour
{
    private CinemachineFreeLook _freeLook;
    
    // Start is called before the first frame update
    void Start()
    {
        _freeLook = GetComponent<CinemachineFreeLook>();
        _freeLook.m_XAxis.m_InputAxisName = "";
        _freeLook.m_YAxis.m_InputAxisName = "";
    }

    // Update is called once per frame
    void Update()
    {
        if (!_freeLook) return;
        if (Input.GetMouseButton(0))
        {
            _freeLook.m_XAxis.m_InputAxisValue = Input.GetAxis("Mouse X");
            _freeLook.m_YAxis.m_InputAxisValue = Input.GetAxis("Mouse Y");
        }
        else
        {
            _freeLook.m_XAxis.m_InputAxisValue = 0;
            _freeLook.m_YAxis.m_InputAxisValue = 0;
        }
    }
}
