using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class TargetPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<AIDestinationSetter>().target = GameObject.Find("Girard").transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
