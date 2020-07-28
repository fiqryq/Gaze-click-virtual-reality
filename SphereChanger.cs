using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereChanger : MonoBehaviour {

    GameObject m_Fader;

    bool changing = false;


    void Awake()
    {

        m_Fader = GameObject.Find("Fader");

        if (m_Fader == null)
            Debug.LogWarning("No Fader object found on camera.");

    }


    public void ChangeSphere(Transform nextSphere)
    {

        StartCoroutine(FadeCamera(nextSphere));

    }


    IEnumerator FadeCamera(Transform nextSphere)
    {

        if (m_Fader != null)
        {
            StartCoroutine(FadeIn(0.75f, m_Fader.GetComponent<Renderer>().material));
            yield return new WaitForSeconds(0.75f);

            Camera.main.transform.parent.position = nextSphere.position;

            StartCoroutine(FadeOut(0.75f, m_Fader.GetComponent<Renderer>().material));
            yield return new WaitForSeconds(0.75f);
        }
        else
        {
            Camera.main.transform.parent.position = nextSphere.position;
        }


    }


    IEnumerator FadeOut(float time, Material mat)
    {
        while (mat.color.a > 0.0f)
        {
            mat.color = new Color(mat.color.r, mat.color.g, mat.color.b, mat.color.a - (Time.deltaTime / time));
            yield return null;
        }
    }


    IEnumerator FadeIn(float time, Material mat)
    {
        while (mat.color.a < 1.0f)
        {
            mat.color = new Color(mat.color.r, mat.color.g, mat.color.b, mat.color.a + (Time.deltaTime / time));
            yield return null;
        }
    }


}
