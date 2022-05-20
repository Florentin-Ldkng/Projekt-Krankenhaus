using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitTriggerScript : MonoBehaviour
{
    [SerializeField] DoorScript Door;
    [SerializeField] private GameObject TempOn, TempOff;
    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Player")
        {
            switch(gameObject.name)
            {
                case "ExitTrigger":
                    Door.FakeDoor = 1;
                    Door.SetExitLights(true);
                    break;
                case "ExitCloseTrigger":
                    Door.SetExitLights(false);
                    Door.FakeDoor = 2;
                    TempOn.SetActive(true);
                    TempOff.SetActive(false);
                    GameManager.FlipSwitch();
                    break;
            }
            Destroy(gameObject);
        }
    }
}
