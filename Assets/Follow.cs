using UnityEngine;

public class Follow : MonoBehaviour {

    public Transform cube;
    public Vector3 vec;
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.RightArrow))
        {
            transform.position = cube.position + vec;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.LeftArrow))
        {
            transform.position = cube.position - vec;
        }
	}
}
