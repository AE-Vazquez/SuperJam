using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MusicPlayer : MonoBehaviour {

    public AudioClip[] soundClips;
    private int clipIndex = 0;
    private AudioSource audio;
    void Start()
    {
        audio=GetComponent<AudioSource>();
        StartCoroutine(playEngineSound());
    }

    IEnumerator playEngineSound()
    {
        while (soundClips.Length>1 && clipIndex < soundClips.Length-1)
        {
            audio.clip = soundClips[clipIndex];
            audio.Play();
            clipIndex++;
            yield return new WaitForSeconds(audio.clip.length);
        }
        audio.clip = soundClips[clipIndex];
        audio.loop = true;
        audio.Play();
    }

}
