using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    [SerializeField]
    //The player game object
    GameObject Player;

    [SerializeField]
    //The speed the camera will move
    float CamSpeed;

    [SerializeField]
    //The distance from the player the camera can get
    int CamDistance = 5;

	// Use this for initialization
	void Start ()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //If the player is moving right
        if(Player.GetComponent<Rigidbody2D>().velocity.x > 0)
        {
            //Move the camera right by CAM DISTANCE
            this.transform.position = Vector3.MoveTowards(this.transform.position, new Vector3(Player.transform.position.x + CamDistance, this.transform.position.y, this.transform.position.z), CamSpeed * Time.deltaTime);
        }
        //If the player is moving left
        else if(Player.GetComponent<Rigidbody2D>().velocity.x < 0)
        {
            //Move the camera left by CAM DISTANCE
            this.transform.position = Vector3.MoveTowards(this.transform.position, new Vector3(Player.transform.position.x - CamDistance, this.transform.position.y, this.transform.position.z), CamSpeed * Time.deltaTime);
        }
        //If the player isn't moving
        else
        {
            //Center the camera
            this.transform.position = Vector3.MoveTowards(this.transform.position, new Vector3(Player.transform.position.x, this.transform.position.y, this.transform.position.z),15 * Time.deltaTime);
        }
    }
}
