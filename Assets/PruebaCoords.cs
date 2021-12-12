using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;


public class PruebaCoords : MonoBehaviour
{
    //Us� la documentacion de https://docs.unity3d.com/Packages/com.unity.xr.interaction.toolkit@1.0/api/UnityEngine.XR.Interaction.Toolkit.XRBaseInteractor.html
    //Toca probar para poder integrar para poder obtener coordenadas de personajes

    public GameObject derecha;
     XRBaseInteractor seleccionador;
     Vector3 pos;
     Quaternion rot;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        seleccionador = derecha.GetComponent<XRBaseInteractor>();
        XRBaseInteractable seleccionado = seleccionador.selectTarget;
        if (seleccionado != null)
        {
            pos = seleccionado.transform.position;
            rot = seleccionado.transform.rotation;

            Debug.LogWarning("X pos" + pos.x + ", Y pos" + pos.y + ", Z pos" + pos.z);
            Debug.Log("X rot" + rot.x + ", Y rot" + rot.y + ", Z rot" + rot.z);
            Debug.Log(seleccionado.transform.tag);
            if(seleccionado.tag!="active")

                if (seleccionado.GetComponent<Transition1>().isActiveAndEnabled) {
                    seleccionado.GetComponent<Transition1>().start = true;
                }

                else if (seleccionado.GetComponent<Transition2>().isActiveAndEnabled) {
                    seleccionado.GetComponent<Transition2>().start = true;
                }


        }

    }


    public Vector3 getPosSeleccionado()
    {
        return pos;
    }

    public Quaternion getRotSeleccionado()
    {
        return rot;
    }
}
