using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class MenuScript : MonoBehaviour {
  
    public Button startText;

	// Use this for initialization
	void Start () {
        startText = startText.GetComponent<Button>();

	}
    public void StartLevel()
    {
        SceneManager.LoadScene("scene1");
    }
}
