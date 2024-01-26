using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DoctorAI : MonoBehaviour
{
    [SerializeField] NavMeshAgent agent = null;
    [SerializeField] GameObject player = null;


    // Update is called once per frame
    void Update()
    {
        agent.destination = player.transform.position;
    }
}
