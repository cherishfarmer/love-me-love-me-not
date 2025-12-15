using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenterMood : MonoBehaviour
{

    public Sprite neutralFace;
    public Sprite happyFace;
    public Sprite sadFace;
    public Sprite superHappyFace;
    public Sprite superSadFace;

    private SpriteRenderer spriteRenderer;
    public bool isHappy = false;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = neutralFace;
    }

    public void Restart()
    {
        isHappy = false;
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = neutralFace;
    }

    public void ChangeMood()
    {
        isHappy = !isHappy;
        spriteRenderer.sprite = isHappy ? happyFace : sadFace;
        return;
    }

    public void ExtremeMood(bool isSuperHappy)
    {
        spriteRenderer.sprite = isSuperHappy ? superHappyFace : superSadFace;
    }
}
