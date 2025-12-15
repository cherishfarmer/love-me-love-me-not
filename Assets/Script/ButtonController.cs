using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{

    public GameObject buttons;
    public PetalGenerator petalGenerator;
    public EndText endText;

    public AudioClip buttonSound;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        buttons.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        if (!buttons.activeSelf && petalGenerator.pulledPetals >= petalGenerator.petalCount && petalGenerator.pulledPetals != 0)
        {
            buttons.SetActive(true);
        }
    }

    public void TryAgain()
    {
        PlaySound();
        petalGenerator.Restart();
        endText.Hide();
        buttons.SetActive(false);
    }

    public void Quit()
    {
        StartCoroutine(PlaySoundThenLoadScene());
    }

    void PlaySound()
    {
        audioSource.PlayOneShot(buttonSound);
    }

    IEnumerator PlaySoundThenLoadScene()
    {
        PlaySound();

        yield return new WaitForSeconds(buttonSound.length);

        SceneManager.LoadScene("MainMenu");
    }
}
