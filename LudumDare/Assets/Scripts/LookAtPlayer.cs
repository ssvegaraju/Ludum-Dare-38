using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour {

    // speed is the rate at which the object will rotate
    private GameObject target;
    private Vector3 targetPoint;
    private Quaternion targetRotation;

    void Start()
    {
        target = GameObject.Find("Player");
    }

    void Update()
    {
        Vector3 mousePos = target.transform.position;
        mousePos.z = 5.23f;
        mousePos.x = mousePos.x - transform.position.x;
        mousePos.y = mousePos.y - transform.position.y;

        float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 45f));
    }
}
