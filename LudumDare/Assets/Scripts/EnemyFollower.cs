using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollower : MonoBehaviour {

    private GameObject player;
    private Cabinet cab;
    public float speed = 2f;

    void Start()
    {
        player = GameObject.Find("Player");
        cab = GameObject.Find("Best Cabinet Ever_0").GetComponent<Cabinet>();
    }

    // Update is called once per frame
    void Update () {
        if (!cab.cameraZoom) {
            Vector3 displacementFromTarget = player.transform.position - transform.position;
            Vector3 directionToTarget = displacementFromTarget.normalized;
            Vector3 velocity = directionToTarget * speed;

            float distanceToTarget = displacementFromTarget.magnitude;
            transform.Translate(velocity * Time.deltaTime);
        }
    }
}
