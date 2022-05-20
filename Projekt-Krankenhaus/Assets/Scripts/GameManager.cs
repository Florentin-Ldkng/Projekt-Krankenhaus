using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject TempOff, TempOn;
    // Start is called before the first frame update
    private void Awake()
    {
        
    }
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {

    }
    public void MapSwap()
    {
        TempOff.SetActive(false);
        TempOn.SetActive(true);
    }
    
    
}
