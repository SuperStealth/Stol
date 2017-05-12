using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HomeButton : MonoBehaviour {
    public Canvas canvas;
    public Button homeButton;
    // Use this for initialization
    void Start () {
        canvas = canvas.GetComponent<Canvas>();
        homeButton = homeButton.GetComponent<Button>();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void GoHome()
    {
        SceneManager.LoadScene("Menu");
    }
}
