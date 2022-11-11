using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SimpleAudioManager
{
    public class LevelMusic : MonoBehaviour
    {
        public static LevelMusic instance;

      
        public string trackName;
        public AudioClip audioClip;
        public List<AudioSource> trackList = new List<AudioSource>();

        public bool playMusic;

        private void Start()
        {
            instance = this;
        }


        //Track Functions

        public void playTrack1()
        {
            if (playMusic)
            {
                if (!trackList[0].isPlaying)
                {
                    trackList[0].Stop();
                    trackList[0].Play();
                }

            }
        }

    }
}