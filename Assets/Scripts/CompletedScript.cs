using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CompletedScript : MonoBehaviour {

    public Canvas canvas;
    public Button playButton;
    // Use this for initialization
    void Start () {
        canvas = canvas.GetComponent<Canvas>();
        playButton = playButton.GetComponent<Button>();
    }
    public void StartGame()
    {
        if (CurLevel.level == 1)
        {
            CurLevel.level = 2;
            SceneManager.LoadScene("Level2");
        }
        else  
        if (CurLevel.level == 2)
        {
            CurLevel.level = 3;
            SceneManager.LoadScene("Level3");
        }
        else  
        if (CurLevel.level == 3)
        {
            CurLevel.level = 1;
            SceneManager.LoadScene("Level1");
        }
            
    }
}
