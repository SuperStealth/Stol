using UnityEngine;


public class Move : MonoBehaviour
{
    public int x, y, id, group;
    

    // Use this for initialization
    void Start()
    {
    }

    Vector3 convertToTransform(int x, int y)
    {
        return new Vector3(-6.056f + (x - 1) * 1.405f, 7.287f - (y - 1) * 1.405f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Checker.state[x,y] != id)
        {
            for (int i = 1; i < 11; i++)
                for (int j = 1; j < 11; j++)
                {
                    if (Checker.state[i, j] == id)
                    {
                        x = i;
                        y = j;
                        transform.position = convertToTransform(x, y);
                    }
                }
        }
    }
}
