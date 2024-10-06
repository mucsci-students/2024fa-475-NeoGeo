using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DirectionsInteration : MonoBehaviour {

    public GameObject instructionsPanel;
    public Text instructionsText;
    public string[] instructions;
    private int index;

    public float wordSpeed;
    public bool playerInRange;

    void Update() {
        if(Input.GetKeyDown(KeyCode.E) && playerInRange) {
            if(instructionsPanel.activeInHierarchy){
                 zeroText();
            } else {
            instructionsPanel.SetActive(true);
            StartCoroutine(Typing());
            }
        }
    }

    //resets text
    public void zeroText(){
        instructionsText.text = "";
        index = 0;
        instructionsPanel.SetActive(false);
    }


    //text and text generation speed
    IEnumerator Typing(){
        foreach(char letter in instructions[index].ToCharArray()){
            instructionsText.text += letter;
            yield return new WaitForSeconds(wordSpeed);
        }
    }


    public void NextLine(){
        if(index < instructions.Length - 1){
            index++;
            instructionsText.text = "";
            StartCoroutine(Typing());
        } else {
            zeroText();
        }
    }



    //if the player is in range or not
    private void OnTriggerEnter2D (Collider2D other){
        if(other.CompareTag("Player"))
            playerInRange = true;
    }

    private void OnTriggerExit2D (Collider2D other){
        if(other.CompareTag("Player")){
            playerInRange = false;
            zeroText();
        }
    }

}