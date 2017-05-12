using UnityEngine;
using UnityEngine.SceneManagement;

public class Checker : MonoBehaviour {
    public static int[,] state = new int[12,12];
    // Use this for initialization

    public float minSwipeDistY;

    public float minSwipeDistX;

    private Vector2 startPos;

    

    void Start () {
        for (int i = 0; i < 12; i++)
        {
            for (int j = 0; j < 12; j++)
            {
                state[i, j] = -1;
            }
        }

        for (int i = 1; i < 11; i++)
        {
            for (int j = 1; j < 11; j++)
            {
                state[i, j] = 0;
            }
        }

        state[1, 1] = 1;
        state[2, 1] = 2;
        state[4, 2] = 3;
        state[5, 4] = 4;
        state[7, 5] = 5;
        state[3, 8] = 6;

        state[3, 5] = -1;
        state[3, 6] = -1;
        state[3, 7] = -1;
        state[4, 5] = -1;
        state[4, 6] = -1;
        state[4, 7] = -1;
        state[5, 5] = -1;
        state[5, 6] = -1;
        state[5, 7] = -1;

        state[7, 2] = -1;
        state[7, 3] = -1;
        state[7, 4] = -1;
        state[8, 2] = -1;
        state[8, 3] = -1;
        state[8, 4] = -1;
        state[9, 2] = -1;
        state[9, 3] = -1;
        state[9, 4] = -1;
    }
	
    void CheckCorrect(int x, int y, int depth, int modif)
    {
        if (depth == 3)
        {
            if (modif == 1)
            {
                var trash = GameObject.FindGameObjectsWithTag("One");
                foreach (GameObject One in trash)
                {
                    Destroy(One.gameObject);
                    Score.score += 100;
                }
                return;
            }
            if (modif == 2)
            {
                var trash = GameObject.FindGameObjectsWithTag("Two");
                foreach (GameObject Two in trash)
                {
                    Destroy(Two.gameObject);
                    Score.score += 100;
                }
                return;
            }
        }

        if ((state[x, y + 1] + 2) / 3 == modif)
        {
            int temp = state[x, y];
            state[x, y] = 0;
            CheckCorrect(x, y + 1, depth + 1, modif);
            if (modif == 1)
            {
                if (GameObject.FindGameObjectWithTag("One") != null)
                {
                    state[x, y] = temp;
                }
            }
            else
            {
                if (GameObject.FindGameObjectWithTag("Two") != null)
                {
                    state[x, y] = temp;
                }
            }      
        }
        if ((state[x, y - 1] + 2)/ 3 == modif)
        {
            int temp = state[x, y];
            state[x, y] = 0;
            CheckCorrect(x, y - 1, depth + 1, modif);
            if (modif == 1)
            {
                if (GameObject.FindGameObjectWithTag("One") != null)
                {
                    state[x, y] = temp;
                }
            }
            else
            {
                if (GameObject.FindGameObjectWithTag("Two") != null)
                {
                    state[x, y] = temp;
                }
            }
        }
        if ((state[x + 1, y] + 2)/ 3 == modif)
        {
            int temp = state[x, y];
            state[x, y] = 0;
            CheckCorrect(x + 1, y, depth + 1, modif);
            if (modif == 1)
            {
                if (GameObject.FindGameObjectWithTag("One") != null)
                {
                    state[x, y] = temp;
                }
            }
            else
            {
                if (GameObject.FindGameObjectWithTag("Two") != null)
                {
                    state[x, y] = temp;
                }
            }
        }
        if ((state[x - 1, y] + 2)/ 3 == modif)
        {
            int temp = state[x, y];
            state[x, y] = 0;
            CheckCorrect(x - 1, y, depth + 1, modif);
            if (modif == 1)
            {
                if (GameObject.FindGameObjectWithTag("One") != null)
                {
                    state[x, y] = temp;
                }
            }
            else
            {
                if (GameObject.FindGameObjectWithTag("Two") != null)
                {
                    state[x, y] = temp;
                }
            }
        }
    }

	// Update is called once per frame
	void Update ()
    {
        {
            if (GameObject.FindGameObjectWithTag("One") == null)
                if (GameObject.FindGameObjectWithTag("Two") == null)
                {
                    SceneManager.LoadScene("LevelCompleted");
                }

                    //#if UNITY_ANDROID
            if (Input.touchCount > 0)

            {

                Touch touch = Input.touches[0];

                switch (touch.phase)
                {
                    case TouchPhase.Began:
                        startPos = touch.position;
                        break;

                    case TouchPhase.Ended:
                        float swipeDistVertical = (new Vector3(0, touch.position.y, 0) - new Vector3(0, startPos.y, 0)).magnitude;
                        float swipeDistHorizontal = (new Vector3(touch.position.x, 0, 0) - new Vector3(startPos.x, 0, 0)).magnitude;
                        if (swipeDistVertical > swipeDistHorizontal)
                        {
                            if (swipeDistVertical > minSwipeDistY)
                            {
                                float swipeValue = Mathf.Sign(touch.position.y - startPos.y);

                                if (swipeValue > 0)//up swipe
                                {
                                    for (int i = 1; i < 11; i++)
                                        for (int j = 1; j < 11; j++)
                                        {
                                            int k = j;
                                            while ((state[i,k] > 0) && (state[i,k - 1] == 0))
                                            {
                                                state[i, k - 1] = state[i, k];
                                                state[i, k] = 0;
                                                k--;
                                            }
                                        }
                                }
                                else if (swipeValue < 0)//down swipe
                                {
                                    for (int i = 1; i < 11; i++)
                                        for (int j = 10; j > 0; j--)
                                        {
                                            int k = j;
                                            while ((state[i, k] > 0) && (state[i, k + 1] == 0))
                                            {
                                                state[i, k + 1] = state[i, k];
                                                state[i, k] = 0;
                                                k++;
                                            }
                                        }
                                }
                            }
                        }
                        else
                        {
                            if (swipeDistHorizontal > minSwipeDistX)
                            {
                                float swipeValue = Mathf.Sign(touch.position.x - startPos.x);
                                if (swipeValue < 0)//left swipe
                                {
                                    for (int j = 1; j < 11; j++)
                                        for (int i = 1; i < 11; i++)
                                        {
                                            int k = i;
                                            while ((state[k, j] > 0) && (state[k - 1, j] == 0))
                                            {
                                                state[k - 1, j] = state[k, j];
                                                state[k, j] = 0;
                                                k--;
                                            }
                                        }
                                }
                                else if (swipeValue > 0)//right swipe
                                {
                                    for (int j = 1; j < 11; j++)
                                        for (int i = 10; i > 0; i--)
                                        {
                                            int k = i;
                                            while ((state[k, j] > 0) && (state[k + 1, j] == 0))
                                            {
                                                state[k + 1, j] = state[k, j];
                                                state[k, j] = 0;
                                                k++;
                                            }
                                        }
                                }
                            }
                        }
                        break;
                }
            }

            for (int i = 1; i < 11; i++)
            {
                for (int j = 1; j < 11; j++)
                {
                    if (state[i, j] > 0)
                    {
                        int temp = state[i, j];
                        state[i, j] = 0;
                        CheckCorrect(i, j, 1, (temp + 2) / 3);
                        if ((temp + 2) / 3 == 1)
                        {
                            if (GameObject.FindGameObjectWithTag("One") != null)
                            {
                                state[i, j] = temp;
                            }
                        }
                        else
                        {
                            if (GameObject.FindGameObjectWithTag("Two") != null)
                            {
                                state[i, j] = temp;
                            }
                        }
                    }
                }
            }
        }
    }
}
