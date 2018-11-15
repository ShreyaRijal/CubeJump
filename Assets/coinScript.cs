using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class coinScript : MonoBehaviour {

    public Text coinScoreText;
    public static int coinScore = 0;
    public Transform cube;
    death d;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        coinScore++;
        coinScoreText.text = "Coins: " + coinScore;
        Destroy(gameObject);

    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (cube.position.y <= -4)
        {
            coinScore = 0;
        }
    }

    public int getScore(int coinScore)
    {
        coinScript.coinScore = coinScore;

        return coinScore;
    }
}
