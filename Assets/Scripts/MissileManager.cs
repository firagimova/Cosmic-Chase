using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Unity.VisualScripting;
using UnityEngine;

public class MissileManager : MonoBehaviour
{
    GameObject[] spawns;
    public GameObject missile;


    // Start is called before the first frame update
    void Start()
    {
        spawns = GameObject.FindGameObjectsWithTag("spawn");
        StartCoroutine(SpawnMissiles());
    }

    // Update is called once per frame
    IEnumerator SpawnMissiles()
    {
        while (true)
        {
            //get a random spawn point
            int spawnIndex = UnityEngine.Random.Range(0, spawns.Length);

            //spawn a missile at the spawn point every 5 seconds
            Instantiate(missile, spawns[spawnIndex].transform.position, Quaternion.Euler(0, -90, 0));

            yield return new WaitForSeconds(15);
        }
    }
}








