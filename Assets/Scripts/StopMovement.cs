using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopMovement : MonoBehaviour
{
    public float fadespeed = 0.1f;
    private List<Move> objsToChangeBack = new List<Move>();
    public float maxAmplitude = 1.0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        for (int i = objsToChangeBack.Count - 1; i >= 0; i--)
        {
            Move movement = objsToChangeBack[i];
            
            float currentAmplitude = movement.amplitude;
            if (Mathf.Abs(currentAmplitude - maxAmplitude) < 0.000001f)
            {
                objsToChangeBack.RemoveAt(i);
            }
            else
            {
                movement.amplitude = Mathf.Lerp(currentAmplitude, maxAmplitude, fadespeed);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Portal"))
        {
            Move movement = other.gameObject.GetComponent<Move>();

            if (movement != null)
            {
                objsToChangeBack.Remove(movement);
            }
           

        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Portal"))
        {

            Move movement = other.gameObject.GetComponent<Move>();

            if (movement != null)
            {
                float currentAmplitude = movement.amplitude;
                if (Mathf.Abs(currentAmplitude) > 0)
                {
                    movement.amplitude = Mathf.Lerp(currentAmplitude, 0, fadespeed);
                }
                Debug.Log("change amplitude");
            }
            
        }
    }

    private void OnTriggerExit(Collider other)
    {

        Move movement = other.gameObject.GetComponent<Move>();
        if (movement != null && !objsToChangeBack.Contains(movement))
        {
          
                objsToChangeBack.Add(movement);
        }
    }
}
