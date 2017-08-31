using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformingScript : MonoBehaviour {

    public float speed = 1;
    public float turningspeed = 1;

	// Update is called once per frame
	void Update ()
    {
        transform.Translate(Vector3.up * Time.deltaTime * speed);

        if(Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(new Vector3(0,0,1) * turningspeed);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(new Vector3(0, 0, -1) * turningspeed);
        }
    }
}
