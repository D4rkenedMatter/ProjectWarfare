using UnityEngine;
using System.Collections;

public class bulletController : MonoBehaviour {
    public float bulletSpeed = 10F;
    public Rigidbody rb;
    public int gunRange = 100;
    public GameObject gunObject;
    public float spreadRand = Random.value;
    public float spreadMult = 4;
    private float zRand = 0;
    private float xRand = 0;
    // Use this for initialization
    void Start () {
        xRand = ((Random.value * 2) - 1) * spreadMult;
        zRand = ((Random.value * 2) - 1) * spreadMult;
        transform.Rotate(gunObject.transform.localEulerAngles.x + xRand, 0, gunObject.transform.localEulerAngles.z + zRand);
        
        rb.velocity = transform.TransformDirection(new Vector3(0, 1, 0)) * bulletSpeed;
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        
        if (transform.position.x > gunRange || transform.position.x < -gunRange || transform.position.y > gunRange || transform.position.y < -gunRange || transform.position.z > gunRange || transform.position.z < -gunRange)
        {
            Destroy(gameObject);
        }
	}
}
