using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.Events;

public class Sheep_Controller : MonoBehaviour
{
    
	//private bool m_FacingRight = true;  // For determining which way the player is currently facing.
	
    private Vector3 m_Velocity = Vector3.zero;
    const float detect_range = 3.5f; //Range to detect player
    const float close_range = 1f;
    private bool in_range; 
    private bool too_close;
    float nextTimeToSearch = 0;

    public GameObject target;

    // Start is called before the first frame update
    void Start()
    {
        
    }

 
    void FixedUpdate()
    {
        if (target == null) {
            FindPlayer ();
            return;
        }

        in_range = (Vector3.Distance(transform.position, target.transform.position) <= detect_range);
        too_close = (Vector3.Distance(transform.position, target.transform.position) < close_range);

        if(in_range && !too_close)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, 0.1f);
        } 
    }

    void FindPlayer () {
        if (nextTimeToSearch <= Time.time) {
            GameObject searchResult = GameObject.FindGameObjectWithTag ("Player");
            if (searchResult != null)
                target = searchResult.transform.gameObject;
            nextTimeToSearch = Time.time + 0.5f;
        }
    }
}