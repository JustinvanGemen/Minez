using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

    public GameObject enemy;
    public Transform spawner;
    public int time;
    public int repeatRate;

	// Activates Spawn() 
	void Start () {
        InvokeRepeating("Spawn", time, repeatRate);
	}
	
	// Spawns an Enemy
	void Spawn () {
        Instantiate(enemy, spawner.position, spawner.rotation);
	}
}
