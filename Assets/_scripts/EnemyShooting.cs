using UnityEngine;
using System.Collections;

public class EnemyShooting : MonoBehaviour {

    public EnemyProjectile enemyProjectile;
    public Transform muzzle;
    public float bulletSpeed = 10;
    private float delayCounter = 0.0F;
    private float fireRate = 1F;
    private GameObject Player;
    private SphereCollider col;
    private Transform player;
    private bool shooting;

    private EnemyMovement enemyMovement = new EnemyMovement();


	// Use this for initialization
	void Start () {
        Destroy(gameObject, 45f);
	}
	
	// Update is called once per frame
	void Awake () {
        col = GetComponent<SphereCollider>();
        player = GameObject.FindGameObjectWithTag("Player").transform;

	}

    void Update()
    {
        delayCounter -= Time.deltaTime;
    
        
        Debug.Log(enemyMovement.inRange);
        
        if (enemyMovement.inRange && enemyMovement.target)
        {
         
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
