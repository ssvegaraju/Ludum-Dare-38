using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipPlayerInput : MonoBehaviour {

    // Use this for initialization
    private SpriteRenderer spr;
    private PlayerInput key;
    private Player player;
    private GameObject cam;
    public bool flipped;
	void Start () {
        spr = GetComponent<SpriteRenderer>();
        key = GetComponent<PlayerInput>();
        cam = GameObject.Find("Main Camera");
        player = GetComponent<Player>();
	}
	
	// Update is called once per frame
	void Update () {
        flipped = UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex % 5 == 2;
        if (!player.wallSliding)
        {
            if (Input.GetAxisRaw("Horizontal") == 1 && !key.locked)
                spr.flipX = false;
            else if (Input.GetAxisRaw("Horizontal") == -1 && !key.locked)
                spr.flipX = true;
        }
	}

    void OnParticleCollision(GameObject other)
    {
        if (!key.locked)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
        }
    }
}
