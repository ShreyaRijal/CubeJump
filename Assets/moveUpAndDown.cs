using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveUpAndDown : MonoBehaviour {

    public Transform enemy;
    public float vel = 2f;
	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        enemy.position = new Vector3 (transform.position.x, Mathf.PingPong(Time.time * vel,5), transform.position.z);
    }
}
