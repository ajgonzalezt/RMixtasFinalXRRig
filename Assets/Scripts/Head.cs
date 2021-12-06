using UnityEngine;
using System;
public class Head : MonoBehaviour
{
    [SerializeField] private Transform rootObject, followObject;
    [SerializeField] private Vector3 positionOffset, rotationOffset, headBodyOffset;
    public bool isActive;
    public float maxRotation;


    private void Start() {
        isActive = transform.root.tag == "active";

    }

    private void LateUpdate()
    {

        isActive = transform.root.tag == "active";

        
        if (isActive) {

            if (maxRotation < 0)
            {
                rootObject.position = transform.position + headBodyOffset;
                rootObject.forward = Vector3.ProjectOnPlane(followObject.up, Vector3.up).normalized;

                transform.position = followObject.TransformPoint(positionOffset);
                transform.rotation = followObject.rotation * Quaternion.Euler(rotationOffset);
            }

            else {

                if (Math.Abs(Quaternion.Angle(transform.rotation, followObject.rotation)) > maxRotation) {

                    Quaternion rot = (followObject.rotation * Quaternion.Euler(rotationOffset));


                    bool isNegative = rot.y < 0;

                    float rotY = 0;

                    if (isNegative) {

                        rotY = (-1) * Math.Abs(maxRotation - rot.y);

                    }
                    else {

                           rotY = Math.Abs(maxRotation - rot.y);
                    }

                    transform.rotation = Quaternion.Euler(0, rotY, 0);

                 
                }


            }
     

        }
  
    }
    
    
    
    
}
