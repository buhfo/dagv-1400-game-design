using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    public float topBounds = 30.0f;
    public float lowerBounds = -15;

    private void Awake()
    {
        Time.timeScale = 1.0f;
    }
    // Update is called once per frame
    void Update()
    {
        if (transform.position.z > topBounds)
        {
            Destroy(gameObject);
        }
        else if (transform.position.z < lowerBounds && gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Game Over!");
            Destroy(gameObject);
            Time.timeScale = 0f;
        }
    }
}
