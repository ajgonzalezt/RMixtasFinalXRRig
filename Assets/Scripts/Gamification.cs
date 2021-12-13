using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Gamification : MonoBehaviour
{
    // Start is called before the first frame update

    public string nombreElemento;
    public XRGrabInteractable xrGrab;
    
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject jugador = GameObject.FindGameObjectWithTag("active");
        if(jugador.GetComponent<ColorGame>().color== nombreElemento)
        {
           xrGrab.enabled=true ; 
            Debug.Log("se come");
        }
        else{
             xrGrab.enabled=false ; 
            Debug.Log("No se come");
        }
        
    }
}
