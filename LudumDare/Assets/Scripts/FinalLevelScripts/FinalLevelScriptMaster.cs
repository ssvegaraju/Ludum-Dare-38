using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalLevelScriptMaster : MonoBehaviour {

    public bool dialogueSpoken;
    private bool once = false;
    private bool isSpeaking = false;

    public bool zoomFinished = false;
    public bool positionFinished = false;

    private SpriteRenderer spr;
    private Animator anim;
    private FinalKey quilt;
    private GameObject cam;

    private float startTime = 100;
    private float fracJourney;
    private Vector3 startPos;

	// Use this for initialization
	void Start () {
        spr = this.GetComponent<SpriteRenderer>();
        anim = this.GetComponent<Animator>();
        cam = GameObject.Find("Main Camera");
        quilt = GameObject.Find("Quilt").GetComponent<FinalKey>();
        startPos = cam.transform.position;
    }
	
	// Update is called once per frame
	void Update () {
        if (Time.time - startTime > 2f)
        {
            spr.enabled = false;
            anim.enabled = false;
            dialogueSpoken = true;
            isSpeaking = false;
        }
        if (quilt.pickedUp && isSpeaking && !once)
        {
            spr.enabled = true;
            anim.enabled = true;
            once = true;
            startTime = Time.time;
        }
        if (quilt.pickedUp)
        {
            isSpeaking = true;
        }
        if (dialogueSpoken)
        {
            if (!zoomFinished)
            {
                cam.GetComponent<Camera>().orthographicSize -= .43f * Time.deltaTime;
                zoomFinished = cam.GetComponent<Camera>().orthographicSize < 0.7;
            }
            if (!positionFinished)
            {
                fracJourney += 0.26f * Time.deltaTime;
                cam.transform.position = Vector3.Lerp(startPos, new Vector3(0, -4.183604f, -10), fracJourney);
                positionFinished = cam.transform.position == new Vector3(0, -4.183604f, -10);
            }
        }
    }
}
