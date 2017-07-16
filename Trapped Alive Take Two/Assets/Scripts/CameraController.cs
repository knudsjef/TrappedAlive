using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    [SerializeField]
    GameObject Player;
    [SerializeField]
    float Damp;
    float x;

	// Use this for initialization
	void Start ()
    {
        x = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Player.GetComponent<Rigidbody2D>().velocity.x > 0)
        {
            x += Time.deltaTime * Damp;
            this.transform.position = new Vector3(x, this.transform.position.y, -10);
        }
        else if(Player.GetComponent<Rigidbody2D>().velocity.x < 0)
        {
            x -= Time.deltaTime * Damp;
            this.transform.position = new Vector3(x, this.transform.position.y, -10);
        }
    }
}
