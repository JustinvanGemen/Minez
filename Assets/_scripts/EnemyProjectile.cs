using UnityEngine;
using System.Collections;

public class EnemyProjectile : MonoBehaviour {

    private float _speed = 1;

	// Use this for initialization
	void Start () {
        Destroy(gameObject, 15f);
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.forward * _speed * Time.deltaTime);
	}

    public void SetSpeed(float value)
    {
        _speed = value;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag ("Player"))
        {
            Destroy(other.gameObject);
			Destroy (this.gameObject);

        }

    }
}
