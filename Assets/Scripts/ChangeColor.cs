using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    // Change the Object's Color when it is hit by Player's Gaze


    private Collider trigger;
    private int rimPowerId;
    public float fadeSpeed = 0.5f;
    public float min_rimPower = 0.5f;
    public float max_rimPower = 2.5f;

    private List<Material> objsToChangeBackColor = new List<Material>();


    // Start is called before the first frame update
    void Start()
    {
        rimPowerId = Shader.PropertyToID("_RimPower");
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = objsToChangeBackColor.Count - 1; i >= 0; i--)
        {
            Material mat = objsToChangeBackColor[i];
            float rimPowerCurrent = mat.GetFloat(rimPowerId);
            if (max_rimPower - rimPowerCurrent < 0.0001f)
            {
                objsToChangeBackColor.RemoveAt(i);
            }
            else
            {
                mat.SetFloat(rimPowerId, Mathf.Lerp(rimPowerCurrent, max_rimPower, fadeSpeed));
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("Portal"))
        {
            Material mat = other.gameObject.GetComponent<MeshRenderer>().material;
            objsToChangeBackColor.Remove(mat);
            Debug.Log("entered");
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Portal"))
        {
            Material mat = other.gameObject.GetComponent<MeshRenderer>().material;
            float rimPowerCurrent = mat.GetFloat(rimPowerId);

            if (rimPowerCurrent - min_rimPower < 0.0001f && !objsToChangeBackColor.Contains(mat))
            {
                objsToChangeBackColor.Add(mat);
            }
            else if(!objsToChangeBackColor.Contains(mat))
            {
                mat.SetFloat(rimPowerId, Mathf.Lerp(rimPowerCurrent, min_rimPower, fadeSpeed));
            }

            //Debug.Log("stay");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Portal"))
        {
            Material mat = other.gameObject.GetComponent<MeshRenderer>().material;
            if (!objsToChangeBackColor.Contains(mat))
            {
                objsToChangeBackColor.Add(mat);
            }
            //Debug.Log("exit");
        }
    }
}
