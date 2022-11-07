using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


namespace SimpleAudioManager
{
    [CustomEditor(typeof(CreateChildAudioSource))]
    public class CreateChildAudioSourceEditor : Editor
    {
        private bool gameSound;
        private bool uiSound;

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            
        CreateChildAudioSource script = (CreateChildAudioSource)target;


            if (target.name == "PlayerSounds" || target.name == "EnemySounds")
            {
                if (GUILayout.Button("Create New Game Sound"))
                {
                    GameObject source = new GameObject();
                    source.transform.parent = script.transform;
                    source.name = script.audioSourceName;
                    AudioSource newSource = source.AddComponent<AudioSource>();
                    newSource.clip = script.audioClip;
                    newSource.playOnAwake = false;
                    script.audioManager.gameSounds.Add(newSource);

                }
            }
            if (target.name == "UISounds")
            {
                if (GUILayout.Button("Create New UI Sound"))
                {
                    GameObject source = new GameObject();
                    source.transform.parent = script.transform;
                    source.name = script.audioSourceName;
                    AudioSource newSource = source.AddComponent<AudioSource>();
              
                    newSource.playOnAwake = false;
                    script.audioManager.UISounds.Add(newSource);

                }
            }


        }

    }
}