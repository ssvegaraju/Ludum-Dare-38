using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalKillPlayer : MonoBehaviour {

    private GameObject quilt;

    private PlatformController pc;
    private FinalLevelScriptMaster flsm;

    private void Start()
    {
        quilt = GameObject.Find("Quilt");
        pc = this.GetComponent<PlatformController>();
        flsm = GameObject.Find("ShoutBubble").GetComponent<FinalLevelScriptMaster>();
    }

    private void Update()
    {
        if (quilt.GetComponent<FinalKey>().pickedUp && flsm.dialogueSpoken)
        {
            pc.enabled = true;
        }
        else
        {
            pc.enabled = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
            DeathCount.deathCount++;
        }
    }
}
