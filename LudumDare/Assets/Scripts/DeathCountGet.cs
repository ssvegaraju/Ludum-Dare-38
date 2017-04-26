using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class DeathCountGet : MonoBehaviour
{
    public Text deathBox;

	// Use this for initialization
	void Start ()
    {

	}
	
	// Update is called once per frame
	void Update ()
    {
        deathBox.text = "Death Count: " + (DeathCount.deathCount).ToString();
    }
}
