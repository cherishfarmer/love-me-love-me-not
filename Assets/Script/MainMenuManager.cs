using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public AudioClip buttonSound;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void StartGame()
    {
        StartCoroutine(PlaySoundThenLoadScene("GameScene"));
    }

    public void SettingsButton()
    {
        StartCoroutine(PlaySoundThenLoadScene("Settings"));
    }

    void PlaySound()
    {
        audioSource.PlayOneShot(buttonSound);
    }

    IEnumerator PlaySoundThenLoadScene(string sceneName)
    {
        PlaySound();

        yield return new WaitForSeconds(buttonSound.length);

        SceneManager.LoadScene(sceneName);
    }
}