using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    [SerializeField] private AudioSource aSource;
    [SerializeField] private AudioClip openingDoor, bangingDoor, fakeOpeningDoor, fakeClosingDoor;
    [SerializeField] private GameManager gManager;
    [SerializeField] private GameObject exitLights;
    public byte FakeDoor;

    private float doorRotation = 0;
    public void Update()
    {
        switch(FakeDoor)
        {
            case 0:
                break;
            case 1:
                FakeDoorOpen();
                break;
            case 2:
                FakeDoorClose();
                break;
        }
    }
    public void OpenDoor()
    {
        switch(GameManager.switchesPressed)
        {
            case 3:
                break;
            default:
                if(aSource.isPlaying == false)
                {
                    aSource.PlayOneShot(bangingDoor);
                }
                break;
        }
    }
    public void FakeDoorOpen()
    {
        doorRotation -= 50 * Time.deltaTime;
        doorRotation = Mathf.Clamp(doorRotation, -90, 0);
        transform.rotation = Quaternion.Euler(0, doorRotation, 0);
    }
    public void FakeDoorClose()
    {
        doorRotation += 250 * Time.deltaTime;
        doorRotation = Mathf.Clamp(doorRotation, -90, 0);
        transform.rotation = Quaternion.Euler(0, doorRotation, 0);
    }
    public void SetExitLights(bool active)
    {
        switch(active)
        {
            case true:
                exitLights.SetActive(true);
                aSource.PlayOneShot(fakeOpeningDoor);
                break;
            case false:
                StartCoroutine(ResetDoorFunctionality());
                aSource.PlayOneShot(fakeClosingDoor);
                Destroy(exitLights, 1);
                break;
        }
    }
    private IEnumerator ResetDoorFunctionality()
    {
        yield return new WaitForSeconds(1);
        FakeDoor = 0;
    }
}
