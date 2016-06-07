using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
    public GameObject camera;
    public GameObject player;
    public GameObject bullet;
    public GameObject bulletSpawner;
    private float fireRate = .4F;
    private float timeToFire = 0;
    private bool canFire = true;
	// Use this for initialization
	void Start () {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
	}
	
	
	void FixedUpdate () {
        camera.transform.position = new Vector3(player.transform.position.x, camera.transform.position.y, player.transform.position.z);

        if (Input.GetMouseButton(0) && canFire)
        {
            Instantiate(bullet, bulletSpawner.transform.position, Quaternion.Euler(transform.rotation.x, transform.rotation.y, transform.rotation.z));
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
