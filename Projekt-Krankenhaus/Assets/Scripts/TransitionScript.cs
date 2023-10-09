using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionScript : MonoBehaviour
{
    [SerializeField] byte T1Used,T2Used = 0;
    [SerializeField] GameObject[] mapObjects;
    [SerializeField] GameObject playerLamp;
    public void Transition(string Type)
    {
        switch (Type)
        {
            case "DoorLoad1":
                if (T1Used == 0)
                {
                    mapObjects[0].SetActive(false);
                    mapObjects[1].SetActive(true);

                    GameObject test = new GameObject();
                    test.AddComponent<Transition1VectorCheck>();

                    playerLamp.SetActive(false);
                    T1Used = 1;
                }
                break;
            case "DoorLoad2":

                if (T2Used == 0)
                {
                    mapObjects[2].SetActive(false);

                    T2Used = 1;
                }
                break;
        }


    }
}
