using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    [SerializeField]
    GameObject Player;

    [SerializeField]
    float CamSpeed;

	// Use this for initialization
	void Start ()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Player.GetComponent<Rigidbody2D>().velocity.x > 0)
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, new Vector3(Player.transform.position.x + 10, this.transform.position.y, this.transform.position.z), CamSpeed * Time.deltaTime);
        }
        else if(Player.GetComponent<Rigidbody2D>().velocity.x < 0)
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, new Vector3(Player.transform.position.x - 10, this.transform.position.y, this.transform.position.z), CamSpeed * Time.deltaTime);
        }
        else
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, new Vector3(Player.transform.position.x, this.transform.position.y, this.transform.position.z),15 * Time.deltaTime);
        }
    }
}
