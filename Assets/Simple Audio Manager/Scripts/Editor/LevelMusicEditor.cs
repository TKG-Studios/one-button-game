using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace SimpleAudioManager
{

    [CustomEditor(typeof(LevelMusic))]
    public class LevelMusicEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            LevelMusic script = (LevelMusic)target;
            if (GUILayout.Button("Add New Track"))
            {
                GameObject source = new GameObject();
                source.name = script.trackName + " Music";
                source.transform.parent = script.transform;
                AudioSource newSource = source.AddComponent<AudioSource>();
                newSource.clip = script.audioClip;
                newSource.playOnAwake = false;
                script.trackList.Add(newSource);
            }
        }
    }
}