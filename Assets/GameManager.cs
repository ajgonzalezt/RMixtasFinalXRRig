using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get;  set; }

    public Transform point1T1;
    public Transform point2T1;

    public Transform point1T2;
    public Transform point2T2;
    public Transform point3T2;


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