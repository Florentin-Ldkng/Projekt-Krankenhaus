using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EPScript : MonoBehaviour
{
    [SerializeField] private AudioSource aSource,bSource;
    [SerializeField] private ParticleSystem particles;
    private bool alreadyPressed = false;
    public void UseElectroPanel()
    {
        if(alreadyPressed == false)
        {
            GameManager.FlipSwitch();
            alreadyPressed = true;
            bSource.Play();
            aSource.enabled = false;
            particles.Play();
        }
    }
}
