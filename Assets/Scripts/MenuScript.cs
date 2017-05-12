using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour {
    public Canvas canvas;
    public Button playButton;
    public Button levelsButton;
    // Use this for initialization

    void Start () {
        canvas = canvas.GetComponent<Canvas>();
        playButton = playButton.GetComponent<Button>();
        levelsButton = levelsButton.GetComponent<Button>();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void StartGame()
    {
        CurLevel.level = 1;
        SceneManager.LoadScene("Tutorial");
    }

    public void SelectLevel()
    {
        SceneManager.LoadScene("LevelSelect");
    }
}
