using UnityEngine;
using System;
public class Head : MonoBehaviour
{
    [SerializeField] private Transform rootObject, followObject, spine;
    [SerializeField] private Vector3 positionOffset, rotationOffset, headBodyOffset;
    public bool isActive;


    private void Start() {
        isActive = transform.root.tag == "active";

    }

    private void LateUpdate()
    {

        isActive = transform.root.tag == "active";

        
        if (isActive) {

      
                rootObject.position = transform.position + headBodyOffset;
                rootObject.forward = Vector3.ProjectOnPlane(followObject.up, Vector3.up).normalized;

                transform.position = followObject.TransformPoint(positionOffset);
                transform.rotation = followObject.rotation * Quaternion.Euler(rotationOffset);

        }
  
    }
    
    
    
    
}
