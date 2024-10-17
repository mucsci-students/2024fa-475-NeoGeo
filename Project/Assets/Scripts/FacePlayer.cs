using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FacePlayer : MonoBehaviour
{
    private GameObject girard;
    private FaceDirection facing;

    // Start is called before the first frame update
    void Start()
    {
        facing = new FaceDirection();
    }

    // Update is called once per frame
    void Update()
    {
        girard = GameObject.Find("Girard");
        if(facing.getFacing() && girard.transform.position.x < this.transform.position.x)
        {
            //this.transform.Translate(0f,0.001f,0f);
            this.transform.Rotate(0, 180, 0, Space.Self);
            facing.flipFacing();
        }
        else if(!facing.getFacing() && girard.transform.position.x > this.transform.position.x)
        {
            //this.transform.Translate(0f,-0.001f,0f);
            this.transform.Rotate(0, 180, 0, Space.Self);
            facing.flipFacing();
        }
    }
}

// Class assumes all objects are at default facing right
public class FaceDirection
{
    private bool faceRight;

    public
    FaceDirection()
    {
        faceRight = true;
    }

    //returns true if object is facing right and false otherwise
    public bool
    getFacing()
    {
        return faceRight;
    }

    public void
    flipFacing()
    {
        faceRight = !faceRight;
    }
}