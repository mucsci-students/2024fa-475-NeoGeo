using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using Mono.Cecil.Cil;
using Unity.Entities.UniversalDelegates;
using UnityEngine;
using UnityEngine.UI;

public class heart5 : MonoBehaviour
{

    public Image heartslot;
    


    // Start is called before the first frame update
    void Start()
    {
        heartslot = GetComponent<Image>();
        heartslot.sprite = GetComponentInParent<panel>().full;
        
    }

    // Update is called once per frame
    void Update()
    {
        //if(Player.hp == 100)
            heartslot.sprite = GetComponentInParent<panel>().full;
        //if(Player.hp == 90)
            heartslot.sprite = GetComponentInParent<panel>().half;
        //else if(Player.hp < 90)
            heartslot.sprite = GetComponentInParent<panel>().empty;
    
    }
}