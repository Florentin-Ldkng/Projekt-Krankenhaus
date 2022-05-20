using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFlicker : MonoBehaviour
{
    [SerializeField]
    Light[] lights;
    float timer = 0;
    float localOffTime = 1f;
    bool lightoff = false;
    private void Start()
    {
    }
    void Update()
    {
        if(LightSupportClass.IsOff == false)
        {
            timer += Time.deltaTime;
            if (timer > localOffTime && LightSupportClass.IsFlickering == true)
            {
                if (lightoff == true)
                {
                    foreach (var light in lights)
                    {
                        light.enabled = false;
                    }
                    lightoff = false;
                    localOffTime = Random.Range(0f, LightSupportClass.OffTime);
                }
                else
                {
                    foreach (var light in lights)
                    {
                        light.enabled = true;
                        //light.color = LightSupportClass.LampColor; //Change Color of light for later
                    }
                    lightoff = true;
                    localOffTime = Random.Range(0f, LightSupportClass.OnTime);
                }
                timer = 0;
            }
       
        }
        else
        {
            foreach (var light in lights)
            {
                light.enabled = false;
                localOffTime = Random.Range(0f, LightSupportClass.OnTime);
            }
        }
    }
}
    

