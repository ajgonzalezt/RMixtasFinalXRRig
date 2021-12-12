using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transition2 : MonoBehaviour



{

    public GameObject path;
    public Transform point1;
    public Transform point2;
    public Transform point3;


    public bool start = false;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


        if (GameManager.Instance != null && GameManager.Instance.currentCharacter != null && start)
        {


           transform.position = GameManager.Instance.point1_T2.position;
           GameManager.Instance.currentCharacter = transform;
            


            StartCoroutine(passiveMe(2));

            IEnumerator passiveMe(int secs)
            {
                yield return new WaitForSeconds(secs);

                GameManager.Instance.changePathTransition2 = true;
                GameManager.Instance.isInSwapTransition2 = true;

            }


        }
        start = false;



    }
}
