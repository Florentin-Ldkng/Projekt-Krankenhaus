using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiScript : MonoBehaviour
{
    [SerializeField] Image Crosshair;
    [SerializeField] Sprite Standart, Grab;
    private byte index = 0;

    public void ChangeCrosshair(byte i)
    {
        if(i != index)
        {
            switch (i)
            {
                case 0:
                    Crosshair.sprite = Standart;
                    index = 0;
                    break;
                case 1:
                    Crosshair.sprite = Grab;
                    index = 1;
                    break;
            }
        }        
    }
}
