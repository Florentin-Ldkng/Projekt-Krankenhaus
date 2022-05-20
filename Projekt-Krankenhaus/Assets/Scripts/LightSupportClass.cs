using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class LightSupportClass
{
    private static int switchesPressed = 0;
    public static float OffTime;
    public static float OnTime;
    public static bool IsFlickering;
    public static bool IsOff;
    public static bool IsColored;
    public static Color LampColor;

    public static void FlipSwitch()
    {
        switchesPressed++;
        switch (switchesPressed)
        {
            case 0:
                break;
            case 1:
                IsFlickering = true;
                OffTime = 2f;
                OnTime = 10f;
                break;
            case 2:
                OffTime = 5f;
                OnTime = 5f;
                break;
            case 3:
                IsOff = true;
                break;
        }

    }
    public static void OpenDoor()
    {
        IsOff = false;
        LampColor = Color.red;
    }
}
