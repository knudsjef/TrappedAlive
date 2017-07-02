using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    [SerializeField]
    GameObject Player;

	// Use this for initialization
	void Start ()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Player.transform.position.x < Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 4, 0, 0)).x)
        {
            print("Move Cam");
        }
    }
}
