using UnityEngine;
using System.Collections;

public class SpreadDetector : MonoBehaviour {
    public float sub = 0.05F;

	// Use this for initialization
	void Start () {
        gameObject.GetComponent<Renderer>().material.color = new Color(0,0,0,1);
    }

    void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
        if (sub < 1)
        {
            sub += 0.05F;
        }
        gameObject.GetComponent<Renderer>().material.color = new Color(0 + sub,0,0,1);

    }
	// Update is called once per frame
	void FixedUpdate () {
        
    }
}
