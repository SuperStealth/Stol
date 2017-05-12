using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelsScript : MonoBehaviour {
    public Canvas canvas;
    public Button level1Button;
    public Button level2Button;
    public Button level3Button;
    // Use this for initialization
    void Start () {
        canvas = canvas.GetComponent<Canvas>();
        level1Button = level1Button.GetComponent<Button>();
        level2Button = level2Button.GetComponent<Button>();
        level3Button = level3Button.GetComponent<Button>();
    }

    // Update is called once per frame
    public void StartLevel1()
    {
        CurLevel.level = 1;
        SceneManager.LoadScene("Level1");
    }
    public void StartLevel2()
    {
        CurLevel.level = 2;
        SceneManager.LoadScene("Level2");
    }
    public void StartLevel3()
    {
        CurLevel.level = 3;
        SceneManager.LoadScene("Level3");
    }
}
