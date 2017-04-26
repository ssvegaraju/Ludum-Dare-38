using UnityEngine;
using System.Collections;

public class Jump : MonoBehaviour {

    private Animator a;
    private Rigidbody2D rigid;
    private Player player;

    void Start()
    {
        a = this.GetComponent<Animator>();
        rigid = this.GetComponent<Rigidbody2D>();
        player = this.GetComponent<Player>();
    }
    
    void Update()
    {
        rigid.velocity = new Vector2(player.velocity.x, player.velocity.y);
        a.SetFloat("YVelocity", rigid.velocity.y);
    }
}
