using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get;  set; }

    public Transform point1;
    public Transform point2;
    public Transform currentCharacter;
    public bool isInSwap = false;

    private void Awake()
    {
        Instance = this;
    }
}