using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionsInteration : MonoBehaviour {
   
    public Transform cam;
    public float playerActivateDistance;
    bool active = false;


    void Update() {
        RaycastHit hit;
        active = Physics.Raycast(cam.position, cam.TransformDirection(Vector3.forward, out hit, playerActivateDistance));

        if(input.GetKeyDown(KeyCode.E)){
            print("Welcome to the very old and abandoned castle! \n
            In order to use your conveniently equiped weapon, click the Left Mouse Button \n
            Have fun exploring!");
        }
    }
}