using UnityEngine;
using System.Collections;

public class EnemyShooting : MonoBehaviour {
    [SerializeField]
    private EnemyProjectile enemyProjectile;
    [SerializeField]
    private Transform muzzle;
    public float bulletSpeed = 10;
    private float delayCounter = 0.0F;
    private float fireRate = 1F;
    private GameObject Player;
    private Transform player;
    [SerializeField]
    private Transform target;
    private bool shooting;
    public float range;
    public float seeRange;
    public bool inRange;


	
	void Start ()
    {
        inRange = false;
    }
	
	
	void Awake ()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
	}

    void Update()
    {        
        delayCounter -= Time.deltaTime;
    
        if(Vector3.Distance (transform.position, target.position) < range)
        {
            inRange = true;
        }
        else
        {
            inRange = false;
        }   
        if (inRange == true && delayCounter <= Time.deltaTime)
        {
            transform.LookAt(player.position);
            Shoot();
        }
    }
    void Shoot()
    {        
        shooting = true;
        EnemyProjectile bullet = Instantiate(enemyProjectile, muzzle.position, muzzle.rotation) as EnemyProjectile;
        bullet.SetSpeed(bulletSpeed);
        delayCounter = Time.deltaTime + fireRate;
    }
}
