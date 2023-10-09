using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transition1VectorCheck : MonoBehaviour
{
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }


    private void FixedUpdate()
    {
        if (player.transform.localEulerAngles.y >= 220 && player.transform.localEulerAngles.y <= 320)
        {
            player.GetComponent<PlayerController>().gameManager.GetComponent<TransitionScript>().Transition("DoorLoad2");
            Destroy(this.gameObject);
        }
    }
}
