using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
using SimpleAudioManager;
public class PlayerScript : MonoBehaviour
{

    public delegate float AttackEventTimeHandler(float attackTime);
    public static event AttackEventTimeHandler AttackEventTime;

    public delegate void NextRivalEventHandler();
    public static event NextRivalEventHandler NextRival;

    public delegate void FirstEnemyEvent();
    public static event FirstEnemyEvent FirstEnemy;

    internal int playerVictories;

    public Transform playerWinPosition;
    private Vector3 playerInitPosition;
    internal bool didPLayerWin;



    private float attackTime;
    private RivalScript rival;
    internal float rivalAttackSpeed;
   

    private void OnEnable()
    {
        InputManager.onInputEvent += InputEvent;
     
    }

    private void OnDisable()
    {
        InputManager.onInputEvent -= InputEvent;
       
    }

    private void Start()
    {
        rival = FindObjectOfType<RivalScript>();
        rivalAttackSpeed = rival.randomNumber(attackTime);
        playerInitPosition = transform.position;
        playerVictories = 0;
    }

    public void InputEvent(string action)
    {
        if (action == "Up") Debug.Log("Up");
        if (action == "Down") Debug.Log("Down");

        if (GameManager.Instance.currentState == GameManager.GameStates.Menu)
        {
            if (FirstEnemy != null) FirstEnemy();
            GameManager.Instance.changeState(GameManager.GameStates.SetUp);
        }
            
           

        if (GameManager.Instance.currentState == GameManager.GameStates.Draw)
        {
            if (action == "Attack")
            {
                AudioManager.instance.playGameSound0();
                if (AttackEventTime != null) AttackEventTime(attackTime); //Know how long the player takes to press the button
                Debug.Log(AttackEventTime(attackTime));

                if (AttackEventTime(attackTime) < rivalAttackSpeed)
                {
                    didPLayerWin = true;
                    playerVictories++;
                    Debug.Log(playerVictories);
                    GetComponentInChildren<PlayerAnimator>().Attack();
                    rival.GetComponentInChildren<RivalAnimator>().Death();
                    transform.position = playerWinPosition.transform.position;
                    AudioManager.instance.playGameSound1();
                }
                if (AttackEventTime(attackTime) > rivalAttackSpeed)
                {
                    didPLayerWin = false;
                    rival.GetComponentInChildren<RivalAnimator>().Attack();
                    GetComponentInChildren<PlayerAnimator>().Death();
                    rival.transform.position = rival.rivalWinPosition.transform.position;
                    AudioManager.instance.playGameSound1();
                }
                  
                GameManager.Instance.changeState(GameManager.GameStates.MatchSet);
                
            }
        }

       if (GameManager.Instance.currentState == GameManager.GameStates.Waiting)
        {
            if (action == "Attack")
            {
                if (AttackEventTime != null) AttackEventTime(attackTime);
                Debug.Log(AttackEventTime(attackTime));
                GameManager.Instance.changeState(GameManager.GameStates.MatchSet);
              
            }
           
        }

       if (GameManager.Instance.currentState == GameManager.GameStates.MatchSet)
        {
            StartCoroutine(MatchDecided());
        }

        if (GameManager.Instance.currentState == GameManager.GameStates.MatchDecided)
        {
            if (action == "Attack")
            {
                if (didPLayerWin)
                {
                    if (playerVictories != rival.rivals.Count)
                    {
                        if (NextRival != null) NextRival();
                        rivalAttackSpeed = rival.randomNumber(attackTime);
                        int currentRival = 0;
                        GameManager.Instance.changeState(GameManager.GameStates.SetUp);
                        if (currentRival < rival.rivals.Count - 1)
                        {
                            rival.rivals[currentRival].SetActive(false);
                            currentRival++;
                            rival.rivals[currentRival].SetActive(true);
                        }
                    } else if (playerVictories == rival.rivals.Count)
                    {
                        GameManager.Instance.changeState(GameManager.GameStates.ResultsScreen);

                    }
                    gameObject.transform.position = playerInitPosition;
                 
                } else if (!didPLayerWin)
                {
                    GameManager.Instance.changeState(GameManager.GameStates.ResultsScreen);
                }

            }
     
        }
    
    }

    IEnumerator MatchDecided()
    {
        yield return new WaitForSeconds(2f);
        GameManager.Instance.changeState(GameManager.GameStates.MatchDecided);
        
    }

    IEnumerator RivalDeath()
    {
        yield return new WaitForSeconds(1f);
    }

}
