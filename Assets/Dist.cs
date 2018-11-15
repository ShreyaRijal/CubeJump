using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Dist : MonoBehaviour {

    public Transform cube;
    public Text distScore;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        distScore.text = "Distance: "+cube.position.x.ToString("0");

        if (cube.position.y <= -4)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
	}
}
