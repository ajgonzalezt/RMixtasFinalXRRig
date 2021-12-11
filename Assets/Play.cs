using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Play : MonoBehaviour
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
        if(GameManager.Instance.currentCharacter != null && start) { 

        GameManager.Instance.point1 = point1;
        GameManager.Instance.point2 = point2;
        GameManager.Instance.currentCharacter.position = point3.position;
        GameManager.Instance.currentCharacter.rotation = point3.rotation;
        GameManager.Instance.isInSwap = true;


        StartCoroutine(passiveMe(5));

        IEnumerator passiveMe(int secs)
        {
            yield return new WaitForSeconds(secs);
            GameManager.Instance.isInSwap = false;
            GameManager.Instance.currentCharacter.tag = "";
            GameManager.Instance.transform.tag = "active";
            GameManager.Instance.currentCharacter = transform;
        }
        }
    }
}
