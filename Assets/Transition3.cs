using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transition3 : MonoBehaviour
{


    public Transform point1;
    public bool start = false;
    public bool fadeEnabled = false;
    public bool lightColor = false;

    public Transform camera;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


        if (GameManager.Instance != null && GameManager.Instance.currentCharacter != null && start)
        {

            if (fadeEnabled)
            {

                if (lightColor)
                {
                    camera.GetComponent<CameraFade>().fadeColor = Color.white;
                }

               else
                {
                    camera.GetComponent<CameraFade>().fadeColor = Color.black;
                }

                camera.GetComponent<CameraFade>().startFadedOut = true;

                StartCoroutine(passiveMovement(1));

                IEnumerator passiveMovement(int secs)
                {
                    yield return new WaitForSeconds(secs);
                    GameManager.Instance.XRRig.position = new Vector3(point1.position.x, 0.8f, point1.position.z);
                    GameManager.Instance.XRRig.rotation = point1.rotation;
                   
                }
            }
            else
            {
                GameManager.Instance.XRRig.position = new Vector3(point1.position.x, 0.8f, point1.position.z);
                GameManager.Instance.XRRig.rotation = point1.rotation;
            }


            GameManager.Instance.currentCharacter.transform.tag = "unactive";
            transform.tag = "active";
            GameManager.Instance.currentCharacter = transform;
            



        }
        start = false;


    }


        
}
