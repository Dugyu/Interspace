using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    float y;
    float z;
    float x;
    //bool isMoving = true;
    public float amplitude = 1.0f;
    public bool horizontal = false;
    // Start is called before the first frame update
    void Start()
    {
        y = transform.position.y;
        z = transform.position.z;
        x = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (!horizontal)
        {
            transform.position = new Vector3(x, amplitude * Mathf.Sin(Time.timeSinceLevelLoad) + y, z);
        }
        else
        {
            transform.position = new Vector3(x, y, 2 * (1-amplitude) * Mathf.Sin(Time.timeSinceLevelLoad *1.5f) + z);

        }

    }
}
