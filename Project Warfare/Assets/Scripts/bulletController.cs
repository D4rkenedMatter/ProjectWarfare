using UnityEngine;
using System.Collections;

public class bulletController : MonoBehaviour {
    public float bulletSpeed = 3F;
    public Rigidbody rb;
	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        rb.AddForce(new Vector3(transform.position.x,transform.position.y,1) * bulletSpeed);
	}
}
