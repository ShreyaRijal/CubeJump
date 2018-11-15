using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class death : MonoBehaviour {

    public bool isDead = true;
    public coinScript coin;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isDead = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        coin.getScore(0);
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        isDead = false;
    }
}
