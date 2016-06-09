using UnityEngine;
using System.Collections;

public class TargetMovement : MonoBehaviour {
    public GameObject rotat;
    private float slerpSpeed = .1F;
    private float startTime = 0;
    private bool down = false;
	// Use this for initialization
	void Start () {
        gameObject.GetComponent<Renderer>().material.color = new Color(1, 0, 0, 1);

    }
	
    void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
        down = true;
        startTime = Time.time;
        
    }
	// Update is called once per frame
	void FixedUpdate () {
        if (down && slerpSpeed <= 1)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, rotat.transform.rotation, slerpSpeed);
            slerpSpeed += .1F;
            gameObject.GetComponent<Renderer>().material.color = new Color(0, 0, 0, 1);
        }
        else if (!down && gameObject.GetComponent<Renderer>().material.color == new Color(0, 0, 0, 1) && Time.time - startTime > 5)
        {
            transform.rotation = Quaternion.Slerp(transform.parent.rotation, rotat.transform.rotation, slerpSpeed);
            slerpSpeed += .1F;
            gameObject.GetComponent<Renderer>().material.color = new Color(1, 0, 0, 1);
        }
        if (slerpSpeed > 1)
        {
            slerpSpeed = 0;
            down = !down;
        }
	}
}
