using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FacePlayer : MonoBehaviour
{
    public static bool faceRight = true;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        GameObject girard = GameObject.Find("Girard");
        if(faceRight && girard.transform.position.x < this.transform.position.x)
        {
            this.transform.Rotate(0, 180, 0, Space.World);
            faceRight = false;
        }
        else if(!faceRight && girard.transform.position.x > this.transform.position.x)
        {
            this.transform.Rotate(0, 180, 0, Space.World);
            faceRight = true;
        }

        
    }
}
