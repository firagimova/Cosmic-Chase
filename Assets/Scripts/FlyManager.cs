using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class FlyManager : MonoBehaviour
{
    

    GameObject[] spawns;
    public GameObject fly;


    // Start is called before the first frame update
    void Start()
    {
        spawns = GameObject.FindGameObjectsWithTag("spawn");
        
        
    }

    private void Update()
    {
        // if there is no object with tag "fly" in the scene
        if (GameObject.FindGameObjectsWithTag("fly").Length == 0)
        {
            SpawnFlies();
        }
    }

    // Update is called once per frame
    public void SpawnFlies()
    {
        
        
            //get a random spawn point
            int spawnIndex = UnityEngine.Random.Range(0, spawns.Length);

            //spawn a missile at the spawn point every 5 seconds
            Instantiate(fly, spawns[spawnIndex].transform.position, Quaternion.Euler(0, -90, 0));

            
        
    }
}
