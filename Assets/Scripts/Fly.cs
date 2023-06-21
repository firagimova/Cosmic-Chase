using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fly : MonoBehaviour
{
    public int hp = 5;
    float speed = 2f;

    bool canMove = true;

    public Manager manager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        canMove = !manager.panel.activeSelf && hp > 0;


        //find diffrence between the fly and the ship
        float distance = Vector3.Distance(transform.position, GameObject.FindGameObjectWithTag("ship").transform.position);

        if (canMove && distance > 1)
        {
            //chase the "ship"
            transform.LookAt(GameObject.FindGameObjectWithTag("ship").transform.position);
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
    }
}
