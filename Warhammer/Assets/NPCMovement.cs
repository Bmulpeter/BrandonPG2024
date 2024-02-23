using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCMovement : MonoBehaviour
{
    // Start is called before the first frame update

    
    void Start()
    {
        transform.position = Random.insideUnitSphere * 5;
    }

    // Update is called once per frame
    void Update()
    {
  
    }
}
