using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.XR;

using UnityEngine.XR.Interaction.Toolkit;


public class CreacionPersonaje : MonoBehaviour
{
    public GameObject camaraXR;
    [SerializeField] private InputActionReference actionReferenceCamara;


    [SerializeField] private InputActionReference actionReferenceCamaraB;
    [SerializeField] private InputActionReference actionReferenceCamaraC;
    [SerializeField] private InputActionReference actionReferenceCamaraD;

    public GameObject capsula;
    // Start is called before the first frame update
    void Start()
    {
        actionReferenceCamara.action.performed += OnCambioCamara;

        actionReferenceCamaraB.action.performed += OnCambioCamaraB;

        actionReferenceCamaraC.action.performed += OnCambioCamaraC;

        actionReferenceCamaraD.action.performed += OnCambioCamaraD;
        moverCamaraD();
    }



    // Update is called once per frame
    void Update()
    { 
    }


    IEnumerator moverCamaraA()
    {

        for (int i = 0; i < 10; i++)
        {
            yield return new WaitForSeconds(0.01f);

            camaraXR.transform.position += new Vector3(0,0.2f,0.3f);

        }
        StartCoroutine(moverCamaraPos2A());

    }

    IEnumerator moverCamaraPos2A()
    {
        yield return new WaitForSeconds(2);
        Vector3 position = capsula.transform.position + new Vector3(0, 2, 3);
        camaraXR.transform.position =position;
        yield return new WaitForSeconds(2);
        for (int i = 0; i < 10; i++)
        {
            yield return new WaitForSeconds(0.01f);

            camaraXR.transform.position -= new Vector3(0, 0.2f, 0.3f);

        }


    }
    private void OnCambioCamara(InputAction.CallbackContext obj)
    {
        StartCoroutine(moverCamaraA());
    }



    IEnumerator moverCamaraB()
    {

      
      camaraXR.transform.position += new Vector3(0, 2f, 3f);

      yield return new WaitForSeconds(2);

      StartCoroutine(moverCamaraPos2B());

    }

    IEnumerator moverCamaraPos2B()
    {
        Vector3 position = capsula.transform.position + new Vector3(0, 2, 3);
        camaraXR.transform.position = position;
       
        yield return new WaitForSeconds(2);
        
        camaraXR.transform.position -= new Vector3(0, 2f, 3f);

    }

    private void OnCambioCamaraB(InputAction.CallbackContext obj)
    {
        StartCoroutine(moverCamaraB ());
    }



    private void moverCamaraC()
    {
Vector3 position = capsula.transform.position;
        camaraXR.transform.position = position;

    }

  

    private void OnCambioCamaraC(InputAction.CallbackContext obj)
    {
        moverCamaraC();
    }

    private void moverCamaraD()
    {
        Vector3 position = new Vector3(-2.13f, -3.76f, -3.54f);
        camaraXR.transform.position = position;

    }



    private void OnCambioCamaraD(InputAction.CallbackContext obj)
    {
        moverCamaraD();
    }

}

