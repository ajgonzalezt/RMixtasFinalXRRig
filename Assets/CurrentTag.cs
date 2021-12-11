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
        if (transform.tag == "active" && GameManager.Instance.isInSwap)
        {
       

            if (Vector3.Distance(GameManager.Instance.point2.position, GameManager.Instance.XRRig.transform.position) < 0.1) {

                GameManager.Instance.isInSwap = false;
                transform.tag = "unactive";
                GameManager.Instance.currentCharacter.transform.tag = "active";


            }
          
        }
    }
}
