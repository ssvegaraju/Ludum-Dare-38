using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscMenu : MonoBehaviour
{
    public Rect windowRect;
    public int windowY;
    public int windowX;
    public bool visible;
    public bool cameraZoom;
    public GameObject player;
    public Player playerScript;
    public Vector3 vStorage;

    private Cabinet cab;
    public GUIStyle menuStyle;
    public GUIStyle resetButtonStyle;
    public GUIStyle quitButtonStyle;


    private Vector3 zero = Vector3.zero;
    private AudioComprehensive aud;
	// Use this for initialization
	void Start ()
    {
        aud = GameObject.Find("AudioManager").GetComponent<AudioComprehensive>();
        windowX = Screen.width / 2;
        windowY = Screen.height / 2;
        windowRect = new Rect(Screen.width / 2 - windowX / 2, 
                Screen.height / 2 - windowY / 2, windowX, windowY);
        cameraZoom = false;
        cab = GameObject.Find("Best Cabinet Ever_0").GetComponent<Cabinet>();
        player = GameObject.Find("Player");
        playerScript = player.GetComponent<Player>();
    }
	
	// Update is called once per frame
	void Update ()
    {

        if (visible)
        {
            player.GetComponent<PlayerInput>().locked = true;
            playerScript.velocity = zero;
        }
        else
        {
            if (player.GetComponent<PlayerInput>().locked)
                playerScript.velocity = vStorage;
            player.GetComponent<PlayerInput>().locked = false;
            vStorage = playerScript.velocity;
        }

        cameraZoom = cab.cameraZoom;
        if (cameraZoom)
        {
            visible = false;
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            visible = !visible;
        }
	}

    void OnGUI()
    {
        if (visible)
        {
            GUI.DrawTexture(windowRect, menuStyle.normal.background, ScaleMode.ScaleToFit, true, 10.0f);
            windowRect = GUI.Window(0, windowRect, doWindow, "Pause", menuStyle);
        }
    }

    void doWindow(int windowID)
    {
        if (GUI.Button(new Rect(windowRect.width / 2 - 50, windowRect.height / 2 + 20,
                100, 50), "", quitButtonStyle))
        {
            aud.once = false;
            aud.twice = false;
            aud.playing = false;
            aud.thrice = false;
            aud.fource = false;
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        }
        if (GUI.Button(new Rect(windowRect.width / 2 - 50, windowRect.height / 2 - 60,
                    100, 50), "", resetButtonStyle))
            KillPlayer.kill();
    }
}
