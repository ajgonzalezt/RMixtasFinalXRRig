using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transition1 : MonoBehaviour
{


    public GameObject path;
    public Transform point1;
    public Transform point2;


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



        if (GameManager.Instance != null && GameManager.Instance.currentCharacter != null && start) {


            GameManager.Instance.point1_T1 = point1;
            GameManager.Instance.point2_T1 = point2;

            if (fadeEnabled)
            {

                if (lightColor) {
                    camera.GetComponent<CameraFade>().fadeColor = Color.white;
                }
              
                camera.GetComponent<CameraFade>().startFadedOut = true;

                StartCoroutine(passiveMovement(1));

                IEnumerator passiveMovement(int secs)
                {
                    yield return new WaitForSeconds(secs);
                    GameManager.Instance.XRRig.position = point1.position;
                    GameManager.Instance.XRRig.rotation = point1.rotation;

                }
            }
            else {
                GameManager.Instance.XRRig.position = point1.position;
                GameManager.Instance.XRRig.rotation = point1.rotation;
            }


            GameManager.Instance.currentCharacter = transform;
           


            StartCoroutine(passiveMe(3));

            IEnumerator passiveMe(int secs)
            {
                yield return new WaitForSeconds(secs);

                GameManager.Instance.changePathTransition1 = true;
                GameManager.Instance.isInSwapTransition1 = true;

            }


        }
        start = false;



    }



}
