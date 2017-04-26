using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour {

    private Cabinet cab;
	// Use this for initialization
	void Start () {
        cab = GameObject.Find("Best Cabinet Ever_0").GetComponent<Cabinet>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && !cab.cameraZoom)
        {
            kill();
        }
    }

    public static void kill()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.
                SceneManagement.SceneManager.GetActiveScene().buildIndex);
        DeathCount.deathCount++;
    }
}
