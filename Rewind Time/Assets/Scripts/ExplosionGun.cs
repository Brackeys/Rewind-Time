using UnityEngine;

public class ExplosionGun : MonoBehaviour {

	public GameObject explosion;	// The explosion prefab
	public Camera cam;              // Reference to the Player camera

	void Update ()
	{
		// If the player presses fire
		if (Input.GetButtonDown("Fire1"))
			Shoot();
	}

	void Shoot ()
	{
		RaycastHit _hitInfo;
		// If we hit something
		if (Physics.Raycast(cam.transform.position, cam.transform.forward, out _hitInfo))
		{
			// Create an explosion at the impact point
			Instantiate(explosion, _hitInfo.point, Quaternion.LookRotation(_hitInfo.normal));
		}
	}

}
