using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeFaller : MonoBehaviour {

    // Use this for initialization
    private GameObject player;
    private Rigidbody2D rigid;
    private Cabinet cab;
    private BoxCollider2D box;
    public float triggerDistanceForKnives = 2;
    private Vector3 initialPos;
    private Vector3 smoothingVector;
    private bool smoothing;

    private Vector3 vel;

	void Start () {
        player = GameObject.Find("Player");
        rigid = GetComponent<Rigidbody2D>();
        box = GetComponent<BoxCollider2D>();
        cab = GameObject.Find("Best Cabinet Ever_0").GetComponent<Cabinet>();
        initialPos = this.transform.position;
        smoothingVector = new Vector3(0, 2, 0);
        vel = Vector3.zero;
	}
	
	// Update is called once per frame
	void Update () {
        if (smoothing)
        {
            transform.position = Vector3.SmoothDamp(transform.position, initialPos, ref vel, 0.1f);
            if (transform.position == initialPos)
            {
                smoothing = false;
                box.enabled = true;
            }
        }
		else if (transform.position.y < -10)
        {
            box.enabled = false;
            rigid.constraints = RigidbodyConstraints2D.FreezePositionY;
            transform.position = initialPos + smoothingVector;
            smoothing = true;
        }
        else if (Mathf.Abs(transform.position.x - player.transform.position.x) <= triggerDistanceForKnives && player.transform.position.y < transform.position.y)
        {
            rigid.constraints = RigidbodyConstraints2D.None;
        }
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && !cab.cameraZoom)
        {
            KillPlayer.kill();
        }
    }

    private void SlideInDMS()
    {
        
    }
}
