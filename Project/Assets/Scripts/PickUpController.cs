using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpController : MonoBehaviour {
    
    public Weapon weaponScript;
    public Rigidbody2D rb; //2D
    public BoxCollider2D coll; //2D
    public Transform player, weaponContainer;

    public float pickUpRange;
    public bool equipped;
    public static bool slotFull;

    private void Start() {
        //setup
        
        /* get the components to assign to variables to ensure 
            were actually able to change their state */
        weaponScript = GetComponent<Weapon>();
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        
        if (!equipped) {
            weaponScript.enabled = false;
            rb.isKinematic = false;
            coll.isTrigger = false;
        } if (equipped) {
            weaponScript.enabled = true;
            rb.isKinematic = true;
            coll.isTrigger = true;
            slotFull = true;
        }
    }


    private void Update() {
        Vector3 distanceToPlayer = player.position - transform.position;
        if(!equipped && distanceToPlayer.magnitude <= pickUpRange && Input.GetKeyDown(KeyCode.E) && !slotFull)
            PickUp();
        if(equipped && Input.GetKeyDown(KeyCode.Q))
            Drop();
    }

    private void PickUp() {
        equipped = true;
        slotFull = true;

        transform.SetParent(weaponContainer);
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.Euler(Vector3.zero);
        transform.localScale = Vector3.one;

        rb.isKinematic = true;
        coll.isTrigger = true;

        weaponScript.enabled = true;
    }

    private void Drop(){
        equipped = false;
        slotFull = false;

        transform.SetParent(null);

        rb.isKinematic = false;
        coll.isTrigger = false;

        //gun carriers momentum of player
        rb.velocity = player.GetComponent<Rigidbody>().velocity;

        //disables script
        weaponScript.enabled = false;
    }
}