using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {
    public GameObject player;
    public GameObject gun;
    public GameObject gunObject;
    public Rigidbody rb;
    public enum RotationAxes { MouseXAndY = 0, MouseX = 1, MouseY = 2 }
    public RotationAxes axes = RotationAxes.MouseXAndY;
    public float sensitivityX = .5F;
    public float sensitivityY = .5F;
    public float minimumX = -360F;
    public float maximumX = 360F;
    public float minimumY = -60F;
    public float maximumY = 60F;
    private int zDegrees = 0;
    private float lerpSpeed = .1F;
    float rotationY = 0F;
    private Vector3 gunObjPos;
    private Vector3 gunObjPosAimed;

    void FixedUpdate()
    {
        transform.position = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z);
        if (axes == RotationAxes.MouseXAndY)
        {
            float rotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivityX;

            rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
            rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);

            transform.localEulerAngles = new Vector3(-rotationY, rotationX, zDegrees);
        }
        else if (axes == RotationAxes.MouseX)
        {
            transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivityX, 0);
        }
        else
        {
            rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
            rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);

            transform.localEulerAngles = new Vector3(-rotationY, transform.localEulerAngles.y, zDegrees);
        }
        player.transform.eulerAngles = new Vector3(0,transform.localEulerAngles.y);
        gunObject.transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, 0);

        
    }
    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            if(lerpSpeed < 1)
            {
                lerpSpeed += .1F;
            }
            zDegrees = -10;
            gunObject.transform.localPosition = Vector3.Lerp(gunObjPos, gunObjPosAimed, lerpSpeed); 
        }
        else
        {
            lerpSpeed = 0;
            zDegrees = 0;
            gunObject.transform.localPosition = gunObjPos;
        }
    }

    void Start()
    {
        gunObjPos = gunObject.transform.position;
        gunObjPosAimed = new Vector3(gunObject.transform.position.x - 0.5F, transform.position.y, gunObject.transform.position.z);
        // Make the rigid body not change rotation
        if (rb)
            rb.freezeRotation = true;
    }
}
