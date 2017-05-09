using UnityEngine;
using System.Collections;

public class Lever : MonoBehaviour {

    public bool On;
    char StartPos;

	// Use this for initialization
	void Start () {

        if (this.transform.localScale.x == -1)
        {
            StartPos = 'L';
        }
        else
        {
            StartPos = 'R';
        }

	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void SwitchIO()
    {
        this.transform.localScale = new Vector3(-this.transform.localScale.x, this.transform.localScale.y, this.transform.localScale.z);
        if (On)
        {
            On = false;
        }
        else
        {
            On = true;
        }

        if (StartPos == 'L')
        {
            StartPos = 'R';
        }
        else
        {
            StartPos = 'L';
        }
    }

    void OnTriggerEnter2D(Collider2D Col)
    {
        if (Col.transform.name == "Player")
        {
            if((StartPos == 'L' && !Col.transform.GetComponent<PlayerMovement>().Left) || (StartPos == 'R' && Col.transform.GetComponent<PlayerMovement>().Left))
            SwitchIO();
        }
    }
}
