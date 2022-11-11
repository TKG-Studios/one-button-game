using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace SimpleAudioManager { 

    public class AudioManager : MonoBehaviour
    {

        //Reference to your Audio Manager that can be called anywhere in your project
        public static AudioManager instance;

        //List For your Game Sounds (Character Sounds, Enemy Sounds, Etc)
        public List<AudioSource> gameSounds = new List<AudioSource>();


        //List for your User Interface Sounds
        public List<AudioSource> UISounds = new List<AudioSource>();


        private void Awake()
        {
            instance = this;
            
        }
        private void Start()
        {
            DontDestroyOnLoad(this);
        }
        //Game Sound Functions Here

        public void playGameSound0()
        {
            gameSounds[0].Stop();
            gameSounds[0].Play();
        }


        public void playGameSound1()
        {
            gameSounds[1].Stop();
            gameSounds[1].Play();
        }




        //UI Sound Functions Here

        public void playUISound0()
        {
            UISounds[0].Stop();
            UISounds[0].Play();
        }
    }
}