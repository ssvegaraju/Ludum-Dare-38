using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonBehavior : MonoBehaviour
{

    private AudioComprehensive aud;

	// Use this for initialization
	void Start ()
    {
        aud = GameObject.Find("AudioManager").GetComponent<AudioComprehensive>();
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void play()
    {
        Debug.Log("ran play");
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void quit()
    {
        Application.Quit();
    }

    public void toMenu()
    {
        aud.once = false;
        aud.twice = false;
        aud.thrice = false;
        aud.playing = false;
        aud.fource = false;
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
}
