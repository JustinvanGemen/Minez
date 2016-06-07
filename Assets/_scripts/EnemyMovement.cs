using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour
{
    //Shooting
    public EnemyProjectile enemyProjectile;
    public Transform muzzle;
    public float bulletSpeed = 10;
    private float delayCounter = 0.0F;
    private float fireRate = 1F;
    private GameObject Player;
    private SphereCollider col;
    private Transform player;
    private bool shooting;

    //Movement
    private GameObject _playerObj;
    private NavMeshAgent _navMeshAgent;
    public Transform target;
    public float RANGE;
    public bool inRange;

    // Use this for initialization
    void Start()
    {
        //shooting
        Destroy(gameObject, 120f);
    }

    void Awake()
    {
        //shooting
        col = GetComponent<SphereCollider>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        //movement
        inRange = false;
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _playerObj = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        //shooting
        //delayCounter -= Time.deltaTime;
        
        if (inRange && target && Time.time > delayCounter)
		{
            Shoot();
        }

        //movement
        if (target)
        {
            if (Vector3.Distance(transform.position, target.position) < RANGE)
            {
                inRange = true;
            }
            else
            {
                inRange = false;
            }
        }
		if (_playerObj) {
			_navMeshAgent.SetDestination (_playerObj.transform.position);
		}
    }

    void Shoot()
    {
        shooting = true;
        EnemyProjectile bullet = Instantiate(enemyProjectile, muzzle.position, muzzle.rotation) as EnemyProjectile;
        bullet.SetSpeed(bulletSpeed);
        delayCounter = Time.time + fireRate;
    }
	void OnTriggerEnter(Collider other){
		if (other.tag == "Bullet") {
			Destroy (this.gameObject);
		}
	
	}

    //void OnTriggerEnter (Collider other)
    //{

    //Destroy(other.gameObject);
    //Destroy(gameObject);
    //}

}
