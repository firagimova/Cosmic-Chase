using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Missile : MonoBehaviour
{
    public int hp = 2;
    float speed = 1f;
    bool canMove = true;

    public GameObject firePrefab;
     float fireRate = 5f;

    private bool canFire = true;
    private bool isFiring = false;

    public Manager manager;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DestroyRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        //move the missile toward
        if (canMove)
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
        


        canFire = !manager.panel.activeSelf && hp > 0 && SceneManager.GetActiveScene().buildIndex == 5;
        canMove = !manager.panel.activeSelf && hp > 0;

        if (canFire && !isFiring)
        {
            StartCoroutine(FireRoutine());
        }
    }

    public void Fire()
    {
        Vector3 fireDirection = transform.forward;

        GameObject fire = Instantiate(firePrefab, transform.position + transform.forward * 1.8f, Quaternion.identity);
        fire.transform.up = fireDirection;
        Rigidbody fireRb = fire.GetComponent<Rigidbody>();
        fireRb.velocity = fireDirection * 5;
    }

    IEnumerator FireRoutine()
    {
        isFiring = true;
        while (canFire)
        {
            Fire();
            yield return new WaitForSeconds(fireRate);
        }
        isFiring = false;
    }

    //get destroyed after 15 seconds
    IEnumerator DestroyRoutine()
    {
        yield return new WaitForSeconds(25);
        Destroy(gameObject);
    }

}
