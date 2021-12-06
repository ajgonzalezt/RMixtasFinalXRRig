using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public Transform[] views;
    public float transitionSpeed;
    Transform currentView;

    public Transform point1;
    public Transform point2;
    Vector3 newVector = new Vector3(0, 0, 0);
    // Start is called before the first frame update
    void Start()
    {
        newVector = point1.position - point2.position;
    }

    void Update()
    {
        /*
                if (Input.GetKeyDown(KeyCode.Alpha1))
                {
                    currentView = views[0];
                }

                if (Input.GetKeyDown(KeyCode.Alpha2))
                {
                    currentView = views[1];
                }

                if (Input.GetKeyDown(KeyCode.Alpha3))
                {
                    currentView = views[2];
                }

                if (Input.GetKeyDown(KeyCode.Alpha4))
                {
                    currentView = views[3];
                }

                if (Input.GetKeyDown(KeyCode.Alpha5))
                {
                    currentView = views[4];
                }
        */

          currentView = views[0];

    }


    void LateUpdate()
    {

        //Lerp position
        transform.position = Vector3.Lerp(transform.position, currentView.position, Time.deltaTime * transitionSpeed);

        Vector3 currentAngle = new Vector3(
         Mathf.LerpAngle(transform.rotation.eulerAngles.x, currentView.transform.rotation.eulerAngles.x, Time.deltaTime * transitionSpeed),
         Mathf.LerpAngle(transform.rotation.eulerAngles.y, currentView.transform.rotation.eulerAngles.y, Time.deltaTime * transitionSpeed),
         Mathf.LerpAngle(transform.rotation.eulerAngles.z, currentView.transform.rotation.eulerAngles.z, Time.deltaTime * transitionSpeed));

        transform.eulerAngles = currentAngle;

    }
}

