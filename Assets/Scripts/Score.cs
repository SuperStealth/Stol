using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {
    public static int score = 0;
    public Text scoreText;
	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        scoreText.text = score.ToString();
    }
}
