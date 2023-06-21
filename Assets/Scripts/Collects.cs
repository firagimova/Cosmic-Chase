using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collects : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //if it collides with the ship, then destroy the object
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "ship")
        {
            Destroy(gameObject);
        }
    }



}
