using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HandsControllerScript : MonoBehaviour
{

    [SerializeField] InputActionReference gripInputAction;
    [SerializeField] InputActionReference triggerInputAction;

    Animator handAnimator;


    private void Awake()
    {
        handAnimator = GetComponent<Animator>();
    }

    private void OnEnable()
    {

        try
        {
            gripInputAction.action.performed += GripPressed;
            triggerInputAction.action.performed += TriggerPressed;
        }

        catch { }
     
    }

    private void TriggerPressed(InputAction.CallbackContext obj)
    {
        Debug.Log(obj.ReadValue<float>());
        handAnimator.SetFloat("Trigger",obj.ReadValue<float>());
      
    }

    private void GripPressed(InputAction.CallbackContext obj)
    {
        handAnimator.SetFloat("Grip",obj.ReadValue<float>());
    }

    private void OnDisable()
    {
        try
        {
            gripInputAction.action.performed -= GripPressed;
            triggerInputAction.action.performed -= TriggerPressed;
        }
        catch { 
        
        }

    }




}
