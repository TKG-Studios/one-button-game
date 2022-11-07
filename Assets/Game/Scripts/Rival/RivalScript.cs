using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RivalScript : MonoBehaviour
{
    public Transform rivalWinPosition;

    public List<GameObject> rivals = new List<GameObject>();
 

    [Header("Create New Rival")]
    public Sprite newRivalSprite;
    void Start()
    {
        
    }

    public float randomNumber(float randomNumber)
    {
        randomNumber = Random.Range(1f, 5.5f);
        return randomNumber;
    }
}
