using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Play : MonoBehaviour
{


    public GameObject path;
    public Transform point1;
    public Transform point2;


    public bool start = false;


    // Start is called before the first frame update
    void Start()
    {



    }

    // Update is called once per frame
    void Update()
    {



        if (GameManager.Instance != null && GameManager.Instance.currentCharacter != null && start) {


            GameManager.Instance.point1 = point1;
            GameManager.Instance.point2 = point2;

            GameManager.Instance.XRRig.position = point1.position;
            GameManager.Instance.XRRig.rotation = point1.rotation;
            GameManager.Instance.currentCharacter = transform;


            StartCoroutine(passiveMe(2));

            IEnumerator passiveMe(int secs)
            {
                yield return new WaitForSeconds(secs);

                GameManager.Instance.changePath = true;
                GameManager.Instance.isInSwap = true;

            }


        }
        start = false;



    }


}
