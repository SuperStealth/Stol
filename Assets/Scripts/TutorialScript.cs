using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TutorialScript : MonoBehaviour {
    public Canvas canvas;
    public Button playButton;
    public Sprite newSprite;
    public Sprite sprite12;
    public Sprite sprite13;
    public Sprite sprite14;
    public Sprite sprite15;
    public SpriteRenderer backGround;
    int state = 1;
    // Use this for initialization

    void Start()
    {
        backGround = backGround.GetComponent<SpriteRenderer>();
        canvas = canvas.GetComponent<Canvas>();
        playButton = playButton.GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartGame()
    {
        if (state == 5)
        {
            CurLevel.level = 1;
            SceneManager.LoadScene("Level1");
        }
        else 
        if (state == 4)
        {
            state++;
            backGround.sprite = sprite15;
            playButton.image.overrideSprite = newSprite;
        }
        
        else
        if (state == 3)
        {
            state++;
            backGround.sprite = sprite14;
        }
        
        else
        if (state == 2)
        {
            state++;
            backGround.sprite = sprite13;
        }
        
        else
        if (state == 1)
        {
            state++;
            backGround.sprite = sprite12;
        }

    }
}
