using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    [SerializeField]
    GameObject Player;

    float X;
    float Y;
    bool Centered;
    bool Left;

	// Use this for initialization
	void Start () {
        X = transform.position.x;
	}
	
	// Update is called once per frame
	void Update () {
        if(Camera.main.WorldToScreenPoint(Player.transform.position).x > (Screen.width / 2) + 169 && Camera.main.WorldToScreenPoint(Player.transform.position).x <= (Screen.width / 2) + 232.5)
        {
            Centered = false;
            Left = false;
            X += Time.deltaTime * 3;
            this.transform.position = new Vector3(X, transform.position.y, transform.position.z);
        }
        else if (Camera.main.WorldToScreenPoint(Player.transform.position).x > (Screen.width / 2) + 232.5)
        {
            Centered = false;
            Left = false;
            X += Time.deltaTime * 5;
            this.transform.position = new Vector3(X, transform.position.y, transform.position.z);
        }
        else if (Camera.main.WorldToScreenPoint(Player.transform.position).x < (Screen.width / 2) - 169 && Camera.main.WorldToScreenPoint(Player.transform.position).x >= (Screen.width / 2) - 232.5)
        {
            Centered = false;
            Left = true;
            X -= Time.deltaTime * 3;
            this.transform.position = new Vector3(X, transform.position.y, transform.position.z);
        }
        else if(Camera.main.WorldToScreenPoint(Player.transform.position).x < (Screen.width / 2) - 232.5)
        {
            Centered = false;
            Left = true;
            X -= Time.deltaTime * 5;
            this.transform.position = new Vector3(X, transform.position.y, transform.position.z);
        }
        else
        {
            if(Centered == false)
            {
                if (Left)
                {
                    X -= Time.deltaTime * 2;
                    this.transform.position = new Vector3(X, transform.position.y, transform.position.z);
                }
                else
                {
                    X += Time.deltaTime * 2;
                    this.transform.position = new Vector3(X, transform.position.y, transform.position.z);
                }

                if(Camera.main.WorldToScreenPoint(Player.transform.position).x > (Screen.width / 2) - 1 && Camera.main.WorldToScreenPoint(Player.transform.position).x < (Screen.width / 2) + 1)
                {
                    Centered = true;
                }
            }
        }

    }
}
