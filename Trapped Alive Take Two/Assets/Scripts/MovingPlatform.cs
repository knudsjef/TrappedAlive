using UnityEngine;
using System.Collections;

public class MovingPlatform : MonoBehaviour {

    [SerializeField]
    bool Running;

    [SerializeField]
    bool Up;

    [SerializeField]
    [Header("If no lever leave blank!")]
    GameObject Lever;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

        if (Running)
        {
            if (Up)
            {
                this.transform.Find("Platform").position = Vector3.MoveTowards(this.transform.Find("Platform").position, this.transform.Find("TopPoint").position, Time.deltaTime);
                if (Vector2.Distance(this.transform.Find("TopPoint").position, this.transform.Find("Platform").position) < 0.1)
                {
                    Up = false;
                }
            }
            else
            {
                this.transform.Find("Platform").position = Vector3.MoveTowards(this.transform.Find("Platform").position, this.transform.Find("BottomPoint").position, Time.deltaTime);
                if (Vector2.Distance(this.transform.Find("BottomPoint").position, this.transform.Find("Platform").position) < 0.1)
                {
                    Up = true;
                }
            }
            if (Lever != null)
            {
                if (!Lever.GetComponent<Lever>().On)
                {
                    Running = false;
                }
            }
        }
        else
        {
            if (Lever != null)
            {
                if (Lever.GetComponent<Lever>().On)
                {
                    Running = true;
                }
            }
        }
	}
}
