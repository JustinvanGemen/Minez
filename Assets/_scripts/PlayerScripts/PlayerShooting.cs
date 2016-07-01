using UnityEngine;
using System.Collections;

public class PlayerShooting : MonoBehaviour {

	public bool poweredUp;
    [SerializeField]
    private GameObject torpedo1;
    [SerializeField]
	private GameObject torpedo2;
    [SerializeField]
    private Transform muzzle;
    private float bulletSpeed;
    private float _delayCounter = 0.0F;
    public float _fireRate = 0.3F;
	
	// Handles the Mouse input and activates Shoot()
	void Update () {
	 if (Input.GetMouseButton(0) && Time.time > _delayCounter)
        {
            Shoot();
        }
	}
    //Shoots a projectile when it gets the command to do so from Update()
    private void Shoot()
    {
		if (!poweredUp) {
			GameObject Torpedo1 = Instantiate (torpedo1, muzzle.position, muzzle.rotation) as GameObject;
			_delayCounter = Time.time + _fireRate;
		} else if (poweredUp) {
			GameObject Torpedo2 = Instantiate (torpedo2, muzzle.position, muzzle.rotation) as GameObject;
			_delayCounter = Time.time + _fireRate;
		}
    }
}
