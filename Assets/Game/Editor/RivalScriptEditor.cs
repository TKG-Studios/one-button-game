using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


[CustomEditor(typeof(RivalScript))]
public class RivalScriptEditor : Editor
{

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        RivalScript script = (RivalScript)target;

        if (GUILayout.Button("Add New Rival"))
        {
            GameObject GFX = new GameObject();
            GFX.transform.parent = script.transform;
            GFX.transform.localPosition = new Vector3(0, 0, 0);
            Animator anim = GFX.AddComponent<Animator>();
            SpriteRenderer renderer = GFX.AddComponent<SpriteRenderer>();
            RivalAnimator rivalAnimator = GFX.AddComponent<RivalAnimator>();
            renderer.sprite = script.newRivalSprite;
            GFX.name = renderer.sprite.name.Remove(renderer.sprite.name.Length - 1, 1) + "GFX";
            renderer.flipX = true;
            script.rivals.Add(GFX);
            script.newRivalSprite = null;
            GFX.SetActive(false);

        }

    }
}
