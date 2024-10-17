using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using System;

public class EnemyAggroRange : MonoBehaviour
{
    private GameObject girard;
    private AIPath pathing;

    // Start is called before the first frame update
    void Start()
    {
        pathing = this.GetComponent<AIPath>();
    }

    // Update is called once per frame
    void Update()
    {
        girard = GameObject.Find("Girard");
        if(Math.Abs(this.transform.position.x - girard.transform.position.x) < 10
        && Math.Abs(this.transform.position.y - girard.transform.position.y) < 10)
        {
            pathing.enabled = true;
        }
        else
        {
            pathing.enabled = false;
        }
    }
}
