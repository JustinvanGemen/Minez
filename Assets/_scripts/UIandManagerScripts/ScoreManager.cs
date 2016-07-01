using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    
    public Text scoreText;
    public float score;

    

	// Use this for initialization
	void Start () {
      
        score = 0;
        
	}
	
	// Update is called once per frame
	void Update () {
        UpdateScoreUI();
    }

    private void UpdateScoreUI()
    {
        scoreText.text = "Score:" + score.ToString();
    }
}
