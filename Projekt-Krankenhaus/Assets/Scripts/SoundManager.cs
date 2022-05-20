using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private float time = 0.0f;
    public AudioSource aSource;
    public AudioClip[] WoodSteps;
    public AudioClip[] TileSteps;
    void Update()
    {
        time += Time.deltaTime;
    }

    public void PlayStepSound(Vector2 Direction)
    {
        if(Direction.magnitude > 0 && time > .7f)
        {
            time = 0;
            aSource.PlayOneShot(TileSteps[Random.Range(0,8)]);
        }
    }
}
