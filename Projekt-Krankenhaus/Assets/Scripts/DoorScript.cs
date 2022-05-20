using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    [SerializeField] private AudioSource aSource;
    [SerializeField] private AudioClip openingDoor, bangingDoor;
    [SerializeField] private GameManager gManager;
    public void OpenDoor()
    {
        if(LightSupportClass.IsOff == true)
        {
            gManager.MapSwap();
        }
        else
        {
            if(aSource.isPlaying == false)
            {
                aSource.PlayOneShot(bangingDoor);
            }
            
        }
    }
}
