using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour {

    private Animator anim;
    private Player player;
    private Controller con;
    private SpriteRenderer spr;
    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
        player = GetComponent<Player>();
        con = GetComponent<Controller>();
        spr = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
        if (player.wallSliding)
        {
            anim.SetBool("WallSliding", true);
            if(con.collisions.left)
            {
                spr.flipX = false;
            }
            else if (con.collisions.right)
            {
                spr.flipX = true;
            }
        }
        else
            anim.SetBool("WallSliding", false);
        if (player.velocity.y != 0 && !con.collisions.below)
        {
            anim.SetBool("Falling", true);
        }
        else
        {
            anim.SetBool("Falling", false);
        }
	}
}
