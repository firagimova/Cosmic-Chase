using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //if it collides with an object with tag "collect", then destroy the object
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("astroid"))
        {
            other.gameObject.GetComponent<Asteroids>().hp--;

            if (other.gameObject.GetComponent<Asteroids>().hp == 0)
            {
                Destroy(other.gameObject);
            }
        }
        else if (other.gameObject.CompareTag("missile"))
        {
            other.gameObject.GetComponent<Missile>().hp--;

            if (other.gameObject.GetComponent<Missile>().hp == 0)
            {
                Destroy(other.gameObject);
            }
        }
        else if (other.gameObject.CompareTag("missile") && this.gameObject.CompareTag("fireMis"))
        {
            Destroy(gameObject);
        }
        else if (other.gameObject.CompareTag("ship"))
        {
            other.gameObject.GetComponent<ShipController>().hp--;

            if (other.gameObject.GetComponent<ShipController>().hp == 0)
            {
                Destroy(other.gameObject);
            }
        }
        else if (other.gameObject.CompareTag("fly"))
        {
            other.gameObject.GetComponent<Fly>().hp--;

            if (other.gameObject.GetComponent<Fly>().hp == 0)
            {
                int count = PlayerPrefs.GetInt("count");
                count++;
                PlayerPrefs.SetInt("count", count);
                Destroy(other.gameObject);
            }
        }

        Destroy(gameObject);
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

}
