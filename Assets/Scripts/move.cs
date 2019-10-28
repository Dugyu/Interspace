using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    float y;
    bool isMoving = true;
    // Start is called before the first frame update
    void Start()
    {
        y = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x,  1.0f * Mathf.Sin(Time.timeSinceLevelLoad) + y,transform.position.z);
    }
}
