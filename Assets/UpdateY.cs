using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateY : MonoBehaviour
{
    // Start is called before the first frame update

    public Transform XRRig;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, XRRig.position.y-0.5f, transform.position.z);
    }
}
