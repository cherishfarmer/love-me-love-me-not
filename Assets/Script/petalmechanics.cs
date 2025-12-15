using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetalGenerator : MonoBehaviour
{
    public GameObject petalPrefab;
    public GameObject flowerCenter;
    public GameObject flowerMood;
    public EndText endText;

    public int minPetals = 6;
    public int maxPetals = 12;
    public float radius = 0.7733f;

    [HideInInspector] public int petalCount;
    [HideInInspector] public int pulledPetals = 0;

    private AudioSource audioSource;
    public AudioClip happySound;
    public AudioClip sadSound;
    public AudioClip superHappySound;
    public AudioClip superSadSound;

    public int happyStreak = 0;
    public int sadStreak = 0;

    bool gameOver = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        GeneratePetals();
    }

    public void Restart()
    {
        foreach (Transform child in flowerCenter.transform)
        {
            if (child.name != "petal")
            {
                Destroy(child.gameObject);
            }
        }

        gameOver = false;
        flowerMood.GetComponent<CenterMood>().Restart();
        GeneratePetals();
    }

    public void GeneratePetals()
    {
        petalCount = Random.Range(minPetals, maxPetals + 1);
        pulledPetals = 0;

        for (int i = 0; i < petalCount; i++)
        {

            float angle = i * 360f / petalCount;

            GameObject petalContainer = new GameObject("PetalContainer_" + i);
            petalContainer.transform.SetParent(flowerCenter.transform);

            petalContainer.transform.localPosition = Vector3.zero;

            Quaternion rotation = Quaternion.Euler(0, 0, angle);
            petalContainer.transform.localRotation = rotation;

            GameObject petal = Instantiate(petalPrefab, petalContainer.transform);
            petal.SetActive(true);
            PetalPull petalPull = petal.AddComponent<PetalPull>();
            petalPull.petalGenerator = this;

            petalPull.flowerCenter = flowerCenter;
        }
    }

    public void PetalPulled()
    {

        pulledPetals++;

        if (pulledPetals >= petalCount)
        {
            EndGame();
        }
    }

    public void EndGame()
    {
        if (!gameOver)
        {

            gameOver = true;

            CenterMood centerMood = flowerMood.GetComponent<CenterMood>();

            string message;

            if (centerMood.isHappy)
            {
                ++happyStreak;
                sadStreak = 0;

                if (happyStreak >= 3)
                {
                    audioSource.PlayOneShot(superHappySound);
                    happyStreak = 0;
                    message = "Really loves me!!";
                    centerMood.ExtremeMood(true);
                } else
                {
                    audioSource.PlayOneShot(happySound);
                    message = "Loves me!";
                }
            } else
            {
                ++sadStreak;
                happyStreak = 0;

                if (sadStreak >= 3)
                {
                    audioSource.PlayOneShot(superSadSound);
                    sadStreak = 0;
                    message = "Really does not love me!!";
                    centerMood.ExtremeMood(false);
                }
                else
                {
                    audioSource.PlayOneShot(sadSound);
                    message = "Loves me not...";
                }
            }

                endText.ShowEndText(message);
        }
    }
}
