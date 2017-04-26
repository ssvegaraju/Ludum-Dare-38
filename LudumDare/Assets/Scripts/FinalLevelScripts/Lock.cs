using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lock : MonoBehaviour {

    private FinalLevelScriptMaster flsm;
    private GameObject player;
    private Vector3 initialPos;
    private bool once = false;
    private Vector3 targetPos;
    private Vector3 velocity;
	// Use this for initialization
	void Start () {
        flsm = GameObject.Find("ShoutBubble").GetComponent<FinalLevelScriptMaster>();
        player = GameObject.Find("Player");
        targetPos = new Vector3(0, -4.183604f, 0);
        velocity = Vector3.zero;
    }
	
	// Update is called once per frame
	void Update () {
		if (!once && flsm.positionFinished)
        {
            initialPos = player.transform.position;
        }
        if (flsm.zoomFinished && flsm.positionFinished)
        {
            player.transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref velocity, 0.2f);
        }
	}
}
