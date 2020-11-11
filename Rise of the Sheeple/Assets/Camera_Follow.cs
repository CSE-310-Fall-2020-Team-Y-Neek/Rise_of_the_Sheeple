using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Follow : MonoBehaviour
{
    public Transform player;

    // Update is called once per frame
    void FixedUpdate ()
    {
        transform.position = new Vector3(player.position.x, player.position.y,player.position.z);
    }
}
