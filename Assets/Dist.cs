using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Dist : MonoBehaviour
{

    public Transform cube;
    public Text distScore;
    private Rigidbody2D rigid;
    float horizontalVelocity = 0f;
    bool grounded = false;
    float time=0;

    // Update is called once per frame
    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        distScore.text = "Distance: " + cube.position.x.ToString("0");


        if (cube.position.y <= -4)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        horizontalVelocity = Vector2.Dot(rigid.velocity, Vector2.right);

        if (grounded == true)
        {
            if (horizontalVelocity == 0)
            {
                time += Time.time;

                if (time > 3000)
                {
                    time = 0;
                    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                }
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        grounded = true;
    }
}
