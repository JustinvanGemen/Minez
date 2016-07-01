using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {
    [SerializeField]
    private float eHealth = 100;
    private SphereCollider col;
    private ScoreManager scoreManager;

    void Awake ()
    {
        col = GetComponent<SphereCollider>();
        scoreManager = GameObject.FindGameObjectWithTag("sManager").GetComponent<ScoreManager>();
    }
    void Start () {
        Destroy(gameObject, 180f);
    }
    void Update () {
        if(eHealth == 0)
        {
            scoreManager.score += 150;
            Destroy(gameObject);
        }     
    }
    void OnTriggerEnter(Collider other)
    {
       if (other.CompareTag("playerBullet"))
       {
            eHealth -= 10;
            Destroy(other.gameObject);
        }

    }
}
