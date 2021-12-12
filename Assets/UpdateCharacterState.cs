using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateCharacterState : MonoBehaviour

{


    public Transform point1;
    public Transform point2;
    public Transform point3;
  
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.tag != "active")
        {
            Vector3 pos = transform.position;
            transform.position = new Vector3(pos.x, 0.022f, pos.z);
        }

        if(transform.tag == "active" && !GameManager.Instance.changePathTransition2) {

             GameManager.Instance.point1_T2 = point1;
             GameManager.Instance.point2_T2 = point2;
             GameManager.Instance.point3_T2 = point3;

         

        }
     
      
        if (GameManager.Instance != null && transform.tag == "active" && GameManager.Instance.isInSwapTransition1)
        {


            if (Vector3.Distance(GameManager.Instance.point2_T1.position, GameManager.Instance.XRRig.transform.position) < 0.1)
            {

                GameManager.Instance.isInSwapTransition1 = false;
                transform.tag = "unactive";
                GameManager.Instance.currentCharacter.transform.tag = "active";

            }

        }
        else if (GameManager.Instance != null && transform.tag == "active" && GameManager.Instance.isInSwapTransition2) {


            if (Vector3.Distance(GameManager.Instance.point3_T2.position, GameManager.Instance.currentCharacter.transform.position) < 0.1)
            {

                GameManager.Instance.isInSwapTransition2 = false;
                transform.tag = "unactive";
                GameManager.Instance.currentCharacter.transform.tag = "active";


            }

        }

    }
}
