using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class VRNoThanks : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(DeactivatorVR("none"));
    }

    public IEnumerator DeactivatorVR(string NOVR){
        XRSettings.LoadDeviceByName(NOVR);
    	yield return null;
    	XRSettings.enabled = false;
    }
}
