using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

public class Cabinet : MonoBehaviour
{
    private Animator anim;
    private GameObject key;
    private Key k;
    private bool load = false;
    public bool cameraZoom = false;

    private Camera cam;
    private GameObject camer;

    private GameObject player;
    private FlipPlayerInput input;

    private Vector3 startZless;
    private Vector3 endZless;
    private float fracJourney = 0;
    private Transform startPos;
    private Transform endPos;
    // Use this for initialization
    void Start ()
    {
        anim = this.GetComponent<Animator>();
        key = GameObject.Find("Key");
        k = key.GetComponent<Key>();
        camer = GameObject.Find("Main Camera");
        player = GameObject.Find("Player");
        cam = camer.GetComponent<Camera>();
        input = player.GetComponent<FlipPlayerInput>();
        startPos = camer.transform;
        endPos = transform;
        startZless = new Vector3(startPos.position.x, startPos.position.y, startPos.position.z);
        endZless = new Vector3(endPos.position.x, endPos.position.y, endPos.position.z - 11);
    }

    // Update is called once per frame
    void Update()
    {
        if (cameraZoom)
        {
            CeasePlayerMovement();
            ZoomInOnCabinet();
        }
        if (load)
            loadLevel();
    }

    void loadLevel()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex + 1);
    }

    void CeasePlayerMovement()
    {
        player.GetComponent<PlayerInput>().locked = true;
    }

    void ZoomInOnCabinet()
    {
        cam.orthographicSize -= 1.3f * Time.deltaTime;
        fracJourney += Time.deltaTime * 0.28f;
        camer.transform.position = Vector3.Lerp(startZless, endZless, fracJourney);
        if (input.flipped)
        {
            camer.transform.Rotate(0, 0, 0.8f);
           
        }
    }

    void OnTriggerEnter2D(Collider2D c)
    {
        if(c.gameObject.tag == "Player" && k.getBool())
        {
            anim.SetBool("KeyPickedCollision", k.getBool());
            transform.DetachChildren();
            cameraZoom = true;
            Timer t = new Timer(3900);
            t.Elapsed += T_Elapsed;
            t.Start();
        }
    }

    private void T_Elapsed(object sender, ElapsedEventArgs e)
    {
        load = true;
    }
}
