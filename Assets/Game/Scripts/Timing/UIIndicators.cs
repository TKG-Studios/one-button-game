using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SimpleAudioManager;
using System.Collections.Specialized;

public class UIIndicators : MonoBehaviour
{
  
 
    public Text countUpText;
    public GameObject indicator;
    public float indicatorDisplayTime;

    public float introScreenDisplayTime;
    public float countUpMultiplier;


    public Image[] introImageArray;



    public int minimumTimeToStart;
    public int maximumTimeToStart;
    public Text winOrLose;

    private float countdown;
    private float countUp = 0;
    private bool timerIsRunning;

    private PlayerScript player;
    private RivalScript rival;
   
    private void OnEnable()
    {
        InputManager.onInputEvent += CheckInput;
        PlayerScript.AttackEventTime += TimeRegistered;
        PlayerScript.NextRival += StartBattle;

    }

    private void OnDisable()
    {
        InputManager.onInputEvent -= CheckInput;
        PlayerScript.AttackEventTime -= TimeRegistered;
        PlayerScript.NextRival -= StartBattle;
    }
    void Start()
    {
  
 
    
        player = FindObjectOfType<PlayerScript>();
        rival = FindObjectOfType<RivalScript>();

        StartBattle();
    }

    public void CheckInput(string action)
    {
        if (timerIsRunning)
        {
            if (action == "Attack")
            {
                timerIsRunning = false;
                TimeRegistered(countUp);
                GameManager.Instance.changeState(GameManager.GameStates.MatchSet);
              
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (GameManager.Instance.currentState == GameManager.GameStates.SetUp) StartCoroutine(IntroScreen());

        if (GameManager.Instance.currentState == GameManager.GameStates.Waiting)
        {
          
            if (countdown > 0)
            {
                timerIsRunning = true;
                if (timerIsRunning)
                {
                    countdown -= Time.deltaTime;
                }
            }
            else if (countdown <= 0)
            {
                timerIsRunning = false;
            }

            if (!timerIsRunning)
            {
                AudioManager.instance.playUISound0();
                indicator.SetActive(true);
                StartCoroutine(RemoveIndicator());
                GameManager.Instance.changeState(GameManager.GameStates.Draw);
            }
        }

        if (GameManager.Instance.currentState == GameManager.GameStates.Draw)
        {
            countUp += Time.deltaTime * countUpMultiplier;

            if (countUp >= player.rivalAttackSpeed) player.InputEvent("Attack");
            countUpText.text = countUp.ToString("F1");
        }

        if (GameManager.Instance.currentState == GameManager.GameStates.MatchDecided)
        {
           
            if (player.didPLayerWin)
            {
                winOrLose.text = "You Win";
            }

            else if (!player.didPLayerWin)
            {
                winOrLose.text = "You Lose";
            }
            winOrLose.gameObject.SetActive(true);
        }

    }

    IEnumerator RemoveIndicator()
    {
        yield return new WaitForSeconds(indicatorDisplayTime);
        indicator.SetActive(false);
    }

    IEnumerator IntroScreen()
    {
   
        yield return new WaitForSeconds(introScreenDisplayTime);
     
     
        GameManager.Instance.changeState(GameManager.GameStates.Waiting);
    }
    public float TimeRegistered(float attackTime)
    {
        attackTime = countUp;
        return attackTime;
    }


    public void StartBattle()
    {
        GameManager.Instance.changeState(GameManager.GameStates.SetUp);
        LevelMusic.instance.playTrack1();
        countdown = Random.Range(minimumTimeToStart, maximumTimeToStart);
        countUp = 0;
        countUpText.text = countUp.ToString();
        timerIsRunning = true;
        indicator.SetActive(false);
        winOrLose.gameObject.SetActive(false);


    }
}
