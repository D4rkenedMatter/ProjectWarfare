using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
    public GameObject player;
    public GameObject bullet;
    public GameObject bulletSpawner;
    public GameObject gunObject;
    public float fireRate = .4F;
    private float timeToFire = 0;
    private bool canFire = true;
	// Use this for initialization
	void Start () {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
	}
	
	
	void Update () {

        if (Input.GetMouseButton(0) && canFire)
        {
            Instantiate(bullet, bulletSpawner.transform.position, bulletSpawner.transform.rotation);
            canFire = false;
        }
        if (canFire == false)
        {
            if (timeToFire > fireRate)
            {
                timeToFire = 0;
                canFire = true;
            }
            else
            {
                timeToFire += Time.deltaTime;
            }
        }


        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Cursor.lockState == CursorLockMode.Locked)
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
            if (Cursor.lockState == CursorLockMode.None)
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = true;
            }
        }
	}
}
