using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentTag : MonoBehaviour

{


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance != null && transform.tag == "active" && GameManager.Instance.isInSwapTransition1)
        {
       

            if (Vector3.Distance(GameManager.Instance.point2T1.position, GameManager.Instance.XRRig.transform.position) < 0.1) {

                GameManager.Instance.isInSwapTransition1 = false;
                transform.tag = "unactive";
                GameManager.Instance.currentCharacter.transform.tag = "active";


            }
          
        }
    }
}
