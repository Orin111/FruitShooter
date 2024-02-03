using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Handler : MonoBehaviour
{
    public void OnClick () 
    {
        Debug.Log (Time.time);
    }
    public void Slide (float value)
    {
        Debug.Log ("Slider value :" +value);
    }

}
