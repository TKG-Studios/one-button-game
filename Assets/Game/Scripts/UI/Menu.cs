using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public UIFader fader;
    public Text GameIntroText;

    private void OnEnable()
    {
        UIIndicators.menuFadeInEvent += FadeIn;
        UIIndicators.menuFadeOutEvent += FadeOut;
    }

    private void OnDisable()
    {
        UIIndicators.menuFadeInEvent -= FadeIn;
        UIIndicators.menuFadeOutEvent -= FadeOut;
    }

    public void FadeOut()
    {
        fader.Fade(UIFader.FADE.FadeOut, 2.0f, 0f);
    }

    public void FadeIn()
    {
        fader.Fade(UIFader.FADE.FadeIn, 2.0f, 0f);
        GameIntroText.gameObject.SetActive(false);
    }
}
