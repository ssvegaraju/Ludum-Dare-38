using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Player))]
public class PlayerInput : MonoBehaviour {

    Player player;
    [HideInInspector]
    public bool locked = false;
    Animator anim;

    private bool once;
    private Vector3 initialPos;
    private Vector3 vel;

    private GameObject cab;

	// Use this for initialization
	void Start () {
        player = GetComponent<Player>();
        anim = GetComponent<Animator>();
        cab = GameObject.Find("Best Cabinet Ever_0");
        vel = Vector3.zero;
        initialPos = cab.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        if (!locked)
        {
            Vector2 directionalInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            player.setDirectionalInput(directionalInput);

            if (Input.GetKeyDown(KeyCode.Space))
            {
                player.OnJumpInputDown();
            }
            if (Input.GetKeyUp(KeyCode.Space))
            {
                player.OnJumpInputUp();
            }
        }
        if (locked && !once)
        {
            initialPos = player.transform.position;
            once = true;
        }
        if (locked)
        {
            player.transform.position = Vector3.SmoothDamp(player.transform.position, initialPos, ref vel, .2f);
        }
        if (Input.GetAxisRaw("Horizontal") != 0 && !locked)
        {
            anim.SetBool("isWalking", true);
        } else
        {
            anim.SetBool("isWalking", false);
        }
	}
}
