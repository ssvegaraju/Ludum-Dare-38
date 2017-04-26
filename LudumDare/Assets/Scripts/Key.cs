using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    private GameObject player;
    [HideInInspector]
    public bool pickedUp;
    private AudioSource aud;
    public AudioClip keySound;
        
    public bool developerMode = false;

    private float startTime;
    private bool waited;

    public float speed = 5f;

    // Use this for initialization
    void Start ()
    {
        player = GameObject.Find("Player");
        aud = GetComponent<AudioSource>();
        waited = false;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (developerMode)
        {
            Vector3 displacementFromTarget = player.transform.position - transform.position;
            Vector3 directionToTarget = displacementFromTarget.normalized;
            Vector3 velocity = directionToTarget * speed;
            float distanceToTarget = displacementFromTarget.magnitude;
            transform.Translate(velocity * Time.deltaTime);
        }
        else if (pickedUp) {
            waited = Time.time - startTime > 0.1f;
            if (waited)
            {
                Vector3 displacementFromTarget = player.transform.position - transform.position;
                Vector3 directionToTarget = displacementFromTarget.normalized;
                Vector3 velocity = directionToTarget * speed;
                float distanceToTarget = displacementFromTarget.magnitude;
                
                if (distanceToTarget > 1.5f && pickedUp)
                {
                    transform.Translate(velocity * Time.deltaTime);
                }
            }
        }
    }

    void OnTriggerEnter2D(Collider2D c)
    {
        if(c.gameObject.tag == "Player" && !pickedUp)
        {
            pickedUp = true;
            startTime = Time.time;
            aud.PlayOneShot(keySound);
        }
            
    }

    public bool getBool()
    {
        return pickedUp;
    }
}
