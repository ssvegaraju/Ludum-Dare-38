using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeIn : MonoBehaviour {

    // Use this for initialization
    private SpriteRenderer spr;
    private float s;
    void Start () {
        spr = GetComponent<SpriteRenderer>();
        s = spr.color.a;
        spr.enabled = true;
    }
	
	// Update is called once per frame
	void Update () {
        s -= Time.deltaTime * 0.7f;
        spr.color = new Color(255, 255, 255, s);
	}
}
