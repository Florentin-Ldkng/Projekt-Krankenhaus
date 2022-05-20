using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerTest : MonoBehaviour
{
    [SerializeField] GameObject Door,FakeExit;
    bool openDoor = false;
    private float doorRotation = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(openDoor == true)
        {
            doorRotation -= 20 * Time.deltaTime;
            doorRotation = Mathf.Clamp(doorRotation,-90,0);
            Door.transform.rotation = Quaternion.Euler(0,doorRotation,0);
            //Door.transform.Rotate(new Vector3(0, -15, 0)*Time.deltaTime, Space.Self);
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Player")
        {
            FakeExit.SetActive(true);
            openDoor = true;
        }
    }
}
