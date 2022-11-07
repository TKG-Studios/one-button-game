using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class RivalPortraitScript : MonoBehaviour
{
    public Image[] portraits;


    private void OnEnable()
    {
        PlayerScript.NextRival += ChangeRivalPortrait;
    }

    private void OnDisable()
    {
        PlayerScript.NextRival -= ChangeRivalPortrait;
    }

    public void ChangeRivalPortrait()
    {
        int currentRivalPortrait = 0;
        if (currentRivalPortrait < portraits.Length - 1)
        {
            portraits[currentRivalPortrait].gameObject.SetActive(false);
            currentRivalPortrait++;
            portraits[currentRivalPortrait].gameObject.SetActive(true);
        }
    }
}
