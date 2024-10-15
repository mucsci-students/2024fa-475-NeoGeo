using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public SpriteRenderer spriteRenderer; 
    public Sprite[] frames; 
    public float framesPerSecond = 12f; // Frames per second

    private int currentFrame; 


    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        currentFrame = 0;
    }

    void Update()
    {
        currentFrame = (int)(Time.time * framesPerSecond) % frames.Length;

        spriteRenderer.sprite = frames[currentFrame];
    }


}
