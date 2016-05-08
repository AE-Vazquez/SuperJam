using UnityEngine;
using System.Collections;

public class Flicker : MonoBehaviour {

    public float fadeTime;
    public int fadeCount;

    private int times;
    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    public void StartFlickering()
    {
        times = fadeCount;
        if (!PlayerPrefs.GetString("gameMode").Equals("VR"))
        {
            FadeOut();
        }
        else
        {
            Invoke("StopInvulTime", times * fadeTime);
        }

    }

    public void FadeIn()
    {
        times--;
        if (times > 0)
        {
            iTween.FadeTo(this.gameObject, iTween.Hash("alpha", 1f, "time", fadeTime, "onComplete", "FadeOut"));
        }
        else
        {
            iTween.FadeTo(this.gameObject, iTween.Hash("alpha", 1f, "time", fadeTime, "onComplete", "StopInvulTime"));
        }

    }

    public void FadeOut()
    {
        if (times > 0)
        {
            iTween.FadeTo(this.gameObject, iTween.Hash("alpha", 0f, "time", fadeTime, "onComplete", "FadeIn"));
        }
    }

    private void StopInvulTime()
    {
        GetComponent<ShipBase>().invulnerable = false;
    }


}

