using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.XR;

using UnityEngine.XR.Interaction.Toolkit;


public class CreacionPersonaje : MonoBehaviour
{
    public GameObject camaraXR;
    public XRController controller = null;
    private bool done = false;
    public GameObject control;
    // Start is called before the first frame update
    void Start()
    {
     }

    

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = new Vector3(1, 1, 1);
        //if (controller.inputDevice.TryGetFeatureValue(CommonUsages.primaryButton, out bool menubutton))
        //  Debug.Log("MAGK");
        
        if (done != true)
        {
            StartCoroutine(moverCamara(pos));
            done =true;
        }
        
    }


    IEnumerator moverCamara(Vector3 pos)
    {
        yield return new WaitForSeconds(5);

        for (int i = 0; i <= 6; i++)
        {
            yield return new WaitForSeconds(0.3f);

            GameObject ball = GameObject.FindGameObjectWithTag("ball");
            pos = ball.GetComponent<Transform>().position;
            camaraXR.transform.position = pos;
            Debug.Log("LLEgo");
        }
        StartCoroutine(moverCamaraPos2(pos));

    }

    IEnumerator moverCamaraPos2(Vector3 pos)
    {
        yield return new WaitForSeconds(00.7f);
        camaraXR.transform.position = new Vector3(5, 5, 5);

    }

   }

