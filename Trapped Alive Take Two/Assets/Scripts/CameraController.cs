using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    [SerializeField]
    GameObject Player;

    float X;
    float Y;
    bool Centered;

	// Use this for initialization
	void Start () {
        X = transform.position.x;
	}
	
	// Update is called once per frame
	void Update () {
        if(Camera.main.WorldToScreenPoint(Player.transform.position).x > (Screen.width / 2) + 169 && Camera.main.WorldToScreenPoint(Player.transform.position).x <= (Screen.width / 2) + 232.5)
        {
            Centered = false;
            X += Time.deltaTime * 3;
            this.transform.position = new Vector3(X, transform.position.y, transform.position.z);
        }
        else if (Camera.main.WorldToScreenPoint(Player.transform.position).x > (Screen.width / 2) + 232.5)
        {
            Centered = false;
            X += Time.deltaTime * 5;
            this.transform.position = new Vector3(X, transform.position.y, transform.position.z);
        }
        else if (Camera.main.WorldToScreenPoint(Player.transform.position).x < (Screen.width / 2) - 169 && Camera.main.WorldToScreenPoint(Player.transform.position).x >= (Screen.width / 2) - 232.5)
        {
            Centered = false;
            X -= Time.deltaTime * 3;
            this.transform.position = new Vector3(X, transform.position.y, transform.position.z);
        }
        else if(Camera.main.WorldToScreenPoint(Player.transform.position).x < (Screen.width / 2) - 232.5)
        {
            Centered = false;
            X -= Time.deltaTime * 5;
            this.transform.position = new Vector3(X, transform.position.y, transform.position.z);
        }

        if(Camera.main.WorldToScreenPoint(Player.transform.position).y > (Screen.height / 2) + 60 && Camera.main.WorldToScreenPoint(Player.transform.position).y <= (Screen.height / 2) + 90)
        {
            Centered = false;
            Y += Time.deltaTime * 3;
            this.transform.position = new Vector3(transform.position.x, Y, transform.position.z);
        } 
        else if(Camera.main.WorldToScreenPoint(Player.transform.position).y > (Screen.height / 2) + 90)
        {
            Centered = false;
            Y += Time.deltaTime * 5;
            this.transform.position = new Vector3(transform.position.x, Y, transform.position.z);
        }
        else if (Camera.main.WorldToScreenPoint(Player.transform.position).y < (Screen.height / 2) - 60 && Camera.main.WorldToScreenPoint(Player.transform.position).y >= (Screen.height / 2) - 90)
        {
            Centered = false;
            Y -= Time.deltaTime * 3;
            this.transform.position = new Vector3(transform.position.x, Y, transform.position.z);
        }
        else if (Camera.main.WorldToScreenPoint(Player.transform.position).y < (Screen.height / 2) - 90)
        {
            Centered = false;
            Y -= Time.deltaTime * 5;
            this.transform.position = new Vector3(transform.position.x, Y, transform.position.z);
        }



        if (Player.GetComponent<Rigidbody2D>().velocity == new Vector2(0, 0))
        {
            if (Centered == false)
            {

                transform.position = Vector3.MoveTowards(this.transform.position, new Vector3(Player.transform.position.x, Player.transform.position.y, this.transform.position.z), Time.deltaTime * 2);

                if (Camera.main.WorldToScreenPoint(Player.transform.position).x > (Screen.width / 2) - 1 && Camera.main.WorldToScreenPoint(Player.transform.position).x < (Screen.width / 2) + 1)
                {
                    Centered = true;
                }
            }
        }

    }
}
