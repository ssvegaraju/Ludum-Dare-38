using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalCabinet : MonoBehaviour {

    private FinalLevelScriptMaster flsm;
    private bool collided;
    private GameObject cab;
    private Animator anim;
    private SpriteRenderer spr;
    private GameObject cam;
    private Camera c;

	// Use this for initialization
	void Start () {
        flsm = GameObject.Find("ShoutBubble").GetComponent<FinalLevelScriptMaster>();
        cab = GameObject.Find("Cabinet");
        spr = cab.GetComponent<SpriteRenderer>();
        anim = cab.GetComponent<Animator>();
        cam = GameObject.Find("Main Camera");
        c = cam.GetComponent<Camera>();
        spr.enabled = false;
        anim.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (flsm.zoomFinished && flsm.positionFinished)
        {
            spr.enabled = true;
            anim.enabled = true;
            c.orthographicSize += .6f * Time.deltaTime;
        }
        if (c.orthographicSize > 15f)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex + 1);
        }
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collided = true;
        }
    }
}
