using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveSideToSide : MonoBehaviour {

    public Transform cube;
    public Transform item;
    public float vel = 2f;
    public Vector3 speed;
    bool movingRight = true;
    public int xMax;
    public int xMin;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (movingRight)
        {
            item.Translate(Vector2.right * vel * Time.deltaTime);
        }
        else
        {
            item.Translate(-Vector2.right * vel * Time.deltaTime);
        }

        if (item.position.x >= xMax)
        {
            movingRight = false;
        }

        if (item.position.x <= xMin)
        {
            movingRight = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.collider.transform.SetParent(cube);
        cube.position+= speed * Time.deltaTime;
    }

    private void OnCollisionExit2D(Collision collision)
    {
        collision.collider.transform.SetParent(null);
    }
 
}
