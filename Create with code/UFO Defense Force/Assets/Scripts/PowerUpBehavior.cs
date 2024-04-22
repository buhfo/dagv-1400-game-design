using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpBehavior : MonoBehaviour
{
    public Material green;
    public Material white;



    public bool isGreen;
    public float startDelay = 1f;
    public float switchInterval = 0.5f;

    private Renderer selfRenders;


    void Start()
    {
        selfRenders = GetComponent<Renderer>();
        isGreen = true;
        InvokeRepeating("SwapMaterial", startDelay, switchInterval);
    }

    void SwapMaterial()
    {
        Debug.Log("Called Switch");
        if (isGreen) 
        {
            selfRenders.material = white;
        }
        if (!isGreen) 
        {
            selfRenders.material = green; 
        }
        isGreen = !isGreen;
    }

}
