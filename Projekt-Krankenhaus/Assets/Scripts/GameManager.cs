using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    [SerializeField] private static GameObject ExitTrigger, ExitCloseTrigger;
    [SerializeField] private GameObject Triggers;
    [SerializeField] private static PlayerController player;
    static AudioSource ChaseMusic;
    public static int switchesPressed = 0;
    public bool GameOver = false; 

    // Start is called before the first frame update
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 165;
        PrepareTriggers();
        ChaseMusic = gameObject.GetComponent<AudioSource>();
    }
    public static void FlipSwitch()
    {
        switchesPressed++;
        switch (switchesPressed)
        {
            case 0:
                break;
            case 1:
                LightSupportClass.IsFlickering = true;
                LightSupportClass.OffTime = 2f;
                LightSupportClass.OnTime = 10f;
                break;
            case 2:
                LightSupportClass.OffTime = 5f;
                LightSupportClass.OnTime = 5f;
                break;
            case 3:
                ExitCloseTrigger.SetActive(true);
                ExitTrigger.SetActive(true);
                LightSupportClass.IsOff = true;
                LightSupportClass.OffTime = 2f;
                LightSupportClass.OnTime = .5f;
                break;
            case 4:
                LightSupportClass.IsOff = false;
                ChaseMusic.Play();
                player.walkSpeed = 4.5f;
                player.timeModifier = 0.5f;
                break;
        }
    }

    private void PrepareTriggers()
    {
        var test = Triggers.GetComponentsInChildren<ExitTriggerScript>();
        ExitTrigger = test[0].gameObject;
        ExitCloseTrigger = test[1].gameObject;
        ExitTrigger.SetActive(false);
        ExitCloseTrigger.SetActive(false);
    }

}
