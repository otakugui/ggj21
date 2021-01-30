using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    [Header("Áudio")]
    public AudioSource music;
    public AudioSource sound;
    public AudioSource fx;
    public AudioClip dogAudio, catAudio, ratAudio;
    public float songLength;
    
    public void ChangeMusic(AudioClip newClip)
    {
        songLength = music.time;
        music.clip = newClip;
        music.time = songLength;
        music.Play();
    }

    public void Mute()
    {
        music.Stop();
    }
}
