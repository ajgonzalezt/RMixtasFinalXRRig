using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get;  set; }

    public Transform point1_T1;
    public Transform point2_T1;

    public Transform point1_T2;
    public Transform point2_T2;
    public Transform point3_T2;


      public Transform currentCharacter;
    public bool isInSwapTransition1 = false;
    public bool isInSwapTransition2 = false;
    public bool changePathTransition1 = false;
    public bool changePathTransition2 = false;
    public Transform XRRig;

    private void Awake()
    {
        Instance = this;
    }
}