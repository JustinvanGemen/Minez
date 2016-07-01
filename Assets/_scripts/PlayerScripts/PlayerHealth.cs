using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

    // Use this for initialization
    private PowerUpScript _pus;
    [SerializeField]
    private Text healthText;
    public float Health;                                  // The current health the player has.
    private float counter;

    void Start () {
        _pus = gameObject.GetComponent<PowerUpScript>();
        Health = 1000;
        counter = 0;
	}
	// Updates HealthUI and creates a regen counter. Manages MaxHealth and kills player if it reaches 0hp.
	void Update () {
        
        UpdateHealthUI();

        if (Health <= 750 && counter < Time.time)
        {
            counter = Time.time + 1f;
            regen();
        }

        if (Health >= 1000)
        {
            Health = 1000;
        }
        if (Health <= 0)
        {
            Destroy(this.gameObject);
        }
    }
    private void UpdateHealthUI()
    {
        healthText.text = "Health:" + Health.ToString();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Mine"))
        { 
            Health -= 500;
            Destroy(other.gameObject);
        }
        if (other.CompareTag("EnemyBullet"))
        {
            Health -= 80;
        }
    }

    void regen()
    {
        if (_pus.powerUp5 == true)
        {
            Health += 25;
        }
        else
        {
            Health += 12;
        }
    }
}
