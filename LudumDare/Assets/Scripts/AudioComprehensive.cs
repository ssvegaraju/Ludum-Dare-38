using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioComprehensive : MonoBehaviour {

    public AudioClip music;
    public AudioClip level10To20Music;
    public AudioClip level1To10Music;
    public AudioClip level20To30Music;
    public AudioClip endLevelMusic;
    private AudioSource aud;
    private Cabinet cab;
    public bool playing;
    private bool cabinetOpen;
    public bool once = false;
    public bool twice = false;
    public bool thrice = false;
    public bool fource = false;

    // UnityEngine.SceneManagement.SceneManager

    // Use this for initialization
    void Start () {
        aud = this.GetComponent<AudioSource>();
        aud.volume = 0.8f;
        if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex <= 2)
        {
            aud.clip = music;
            aud.Play();
            playing = false;
        }
        else
        {
            if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex > 2 && UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex < 13)
                aud.clip = level1To10Music;
            else if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex > 12 && UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex < 23)
                aud.clip = level10To20Music;
            else if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex > 22 && UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex < 32)
                aud.clip = level20To30Music;
            else if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex >= 32)
                aud.clip = endLevelMusic;
            aud.Play();
            playing = true;
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (!playing)
        {
            if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex == 2)
            {
                cab = GameObject.Find("Best Cabinet Ever_0").GetComponent<Cabinet>();
                if (cab.cameraZoom)
                {
                    aud.Stop();
                    aud.clip = level1To10Music;
                    aud.Play();
                    playing = true;
                    cab = null;
                }
            }
            else if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex == 0)
            {
                aud.Stop();
                aud.clip = music;
                aud.Play();
                playing = true;
            }
        }
        else if (playing)
        {
            if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex == 12)
            {
                cab = GameObject.Find("Best Cabinet Ever_0").GetComponent<Cabinet>();
                if (cab.cameraZoom && !once)
                {
                    aud.Stop();
                    aud.clip = level10To20Music;
                    aud.Play();
                    once = true;
                }
            }
            else if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex == 22)
            {
                cab = GameObject.Find("Best Cabinet Ever_0").GetComponent<Cabinet>();
                if (cab.cameraZoom && !twice)
                {
                    aud.Stop();
                    aud.clip = level20To30Music;
                    aud.Play();
                    twice = true;
                }
            }
            else if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex == 31)
            {
                cab = GameObject.Find("Best Cabinet Ever_0").GetComponent<Cabinet>();
                if (cab.cameraZoom && !thrice)
                {
                    aud.Stop();
                    aud.clip = endLevelMusic;
                    aud.Play();
                    thrice = true;
                }
            }
            else if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex == 2)
            {
                cab = GameObject.Find("Best Cabinet Ever_0").GetComponent<Cabinet>();
                if (cab.cameraZoom && !fource)
                {
                    aud.Stop();
                    aud.clip = level1To10Music;
                    aud.Play();
                    fource = true;
                }
            }
        }
    }

}
