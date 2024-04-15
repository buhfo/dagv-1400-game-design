using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    [SerializeField] Vector3 offset = new Vector3(0, 10, -15);

  
    void LateUpdate()
    {
        transform.position = player.transform.position + offset;
    }
}
