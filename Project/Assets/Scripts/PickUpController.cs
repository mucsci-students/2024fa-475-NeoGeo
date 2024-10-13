using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpController : MonoBehaviour {

//copy and paste weapon position to WeaponContainer position

    private void Start() {
        //setup
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


    public Weapon weaponScript;
    public Rigidbody rb;
    public BoxCollider coll;
    public Transform player, weaponContainer;

    public float pickUpRange;
    public bool equipped;
    public static bool slotFull;

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