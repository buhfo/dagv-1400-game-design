using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollision : MonoBehaviour
{
    public ScoreManager scoreManager; // store reference to score manager

    public int scoreToGive;

    public AudioClip explode;

    private AudioSource ufoAudio;

    public ParticleSystem explosion;

    void Start()
    {
        ufoAudio = GetComponent<AudioSource>();
        scoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Laser"))
        {
            scoreManager.IncreaseScore(scoreToGive);
            Instantiate(explosion, transform.position, explosion.transform.rotation);
            Destroy(other.gameObject); // destroy other gameobject
            Destroy(gameObject); // destroy this gameobject
        }
        if (other.gameObject.CompareTag("BigLaser"))
        {
            Instantiate(explosion, transform.position, explosion.transform.rotation);
            scoreManager.IncreaseScore(scoreToGive * 2);
            ufoAudio.PlayOneShot(explode, 10.0f);
            Destroy(gameObject); // destroy this gameobject
            
        }
        if (other.gameObject.CompareTag("Player"))
        {
            Instantiate(explosion, transform.position, explosion.transform.rotation);
            ufoAudio.PlayOneShot(explode, 3.0f);
        }
    }


}