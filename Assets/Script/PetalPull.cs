using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class PetalPull : MonoBehaviour
{
    private bool isHeld = false;
    private bool isFalling = false;
    private Vector3 offset; 
    private float fallSpeed = 25f;
    private float fallAcceleration = 250f;
    private float maxFallSpeed = 1000f;
    private float fallDistance = 0f;
    private float maxFallDistance = 400f;

    public GameObject flowerCenter;
    public PetalGenerator petalGenerator;

    private AudioSource audioSource;
    public AudioClip petalPluck;

    SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (isHeld)
        {
            FollowMouse(); 
        }
        else if (isFalling)
        {
            Fall(); 
        }
    }

    void OnMouseDown()
    {
        if (!isFalling)
        {
        
            isHeld = true;

        
            Vector3 mousePosition = Input.mousePosition;
            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
            offset = transform.position - new Vector3(mousePosition.x, mousePosition.y, 0f);
        }
    }

    void OnMouseUp()
    {
        if (!isFalling)
        {

            audioSource.PlayOneShot(petalPluck);
            spriteRenderer.sortingOrder = -10;

            isHeld = false;
            isFalling = true;

            flowerCenter.GetComponent<CenterMood>().ChangeMood();
        } else
        {
            isHeld = false;
        }
    }

    void FollowMouse()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        transform.position = new Vector3(mousePosition.x, mousePosition.y, 0f) + offset;
    }

    void Fall()
    {

        float movement = fallSpeed * Time.deltaTime;
        transform.position += new Vector3(0, -movement, 0);

        fallSpeed += fallAcceleration * Time.deltaTime;

        if (fallSpeed > maxFallSpeed)
        {
            fallSpeed = maxFallSpeed;
        }

        fallDistance += movement;

        if (fallDistance >= maxFallDistance)
        {
            petalGenerator.PetalPulled();
            Destroy(gameObject);
        }
    }
}
