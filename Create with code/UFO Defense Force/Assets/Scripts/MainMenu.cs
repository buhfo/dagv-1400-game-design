using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public int sceneToLoad;
    public AudioClip notif;
    private AudioSource notifAudioPlayer;

    private void Start()
    {
        notifAudioPlayer = GetComponent<AudioSource>();
    }

    public void StartGame()
    {
        notifAudioPlayer.PlayOneShot(notif, 1.0f);
        StartCoroutine(WaitToStart());
        
    }

    public void QuitGame()
    {
        notifAudioPlayer.PlayOneShot(notif, 1.0f);
        StartCoroutine(WaitToEnd());
    }
    IEnumerator WaitToStart()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(sceneToLoad);
    }
    IEnumerator WaitToEnd()
    {
        yield return new WaitForSeconds(1);
        Application.Quit();
    }
}
