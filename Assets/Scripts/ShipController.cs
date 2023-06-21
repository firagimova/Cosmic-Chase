using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class ShipController : MonoBehaviour
{
    private Camera cam;
     public Vector3 dir;

    public int hp;

    private Rigidbody rb;

    [SerializeField] private float speed;
    [SerializeField] private float maxSpeed;

    private bool takingDamage = false;

    public Manager manager;
    private bool isNotifying = false;

    public GameObject firePrefab;

     float fireRate = 0.2f;
    private bool canFire = true;
    private bool isFiring = false;


    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        rb = GetComponent<Rigidbody>();

        
       hp = PlayerPrefs.GetInt("HP");

        
        
        //PlayerPrefs.SetInt("HP", hp);

        //StartCoroutine(FireRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        //hp = PlayerPrefs.GetInt("HP", 3);

        if (!manager.panel.activeSelf)
        {
            moveIt();
        }
        stayInScreen();

        

        //if there is no object with tag "collect" in the scene, then load scene 3
        if (GameObject.FindGameObjectsWithTag("collect").Length == 0 && SceneManager.GetActiveScene().buildIndex == 1)
        {
            SceneManager.LoadScene(3);
        }

        if (GameObject.FindGameObjectsWithTag("astroid").Length == 0 && SceneManager.GetActiveScene().buildIndex == 3)
        {
            SceneManager.LoadScene(4);
        }
        if (GameObject.FindGameObjectsWithTag("astroid").Length == 0 && SceneManager.GetActiveScene().buildIndex == 4)
        {
            SceneManager.LoadScene(5);
        }
        if (GameObject.FindGameObjectsWithTag("astroid").Length == 0 && SceneManager.GetActiveScene().buildIndex == 5)
        {
            SceneManager.LoadScene(6);
        }
        if (PlayerPrefs.GetInt("count") == 4 && SceneManager.GetActiveScene().buildIndex == 6)
        {
            SceneManager.LoadScene(9);
        }

        canFire = !manager.panel.activeSelf && hp > 0 && (SceneManager.GetActiveScene().buildIndex == 3 || SceneManager.GetActiveScene().buildIndex == 4 || SceneManager.GetActiveScene().buildIndex == 5 || SceneManager.GetActiveScene().buildIndex == 6);

        if (manager.panel.activeSelf)
        {
            isFiring = false;
        }

        if (canFire && !isFiring)
        {
            StartCoroutine(FireRoutine());
        }

    }

    private void FixedUpdate()
    {
        if(dir == Vector3.zero)
        {
            return;
        }
        
        rb.AddForce(dir * speed, ForceMode.Force);
        rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed);

    }

    public void moveIt()
    {
        if (Touchscreen.current.primaryTouch.press.isPressed)
        {
            Vector2 touchPos = Touchscreen.current.primaryTouch.position.ReadValue();
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(touchPos);

            dir = worldPos - transform.position;

            dir.z = 0;

            dir.Normalize();

        }
        else
        {

            dir = Vector3.zero;
        }
    }

    public void stayInScreen()
    {
        Vector3 newPos = transform.position;
        Vector3 viewPos = cam.WorldToViewportPoint(transform.position);

        if(viewPos.x > 1)
        {
            newPos.x = -newPos.x + 0.1f;
        }
        else if(viewPos.x < 0)
        {
            newPos.x = -newPos.x - 0.1f;
        }

        if(viewPos.y > 1)
        {
            newPos.y = -newPos.y + 0.1f;
        }
        else if(viewPos.y < 0)
        {
            newPos.y = -newPos.y - 0.1f;
        }

        transform.position = newPos;

    }


    // when it collides with an object with tag "Asteroid" it will destroy the object
    private void OnTriggerEnter(Collider other)
    {
        if(!takingDamage && other.gameObject.tag == "astroid")
        {
            takingDamage = true;

            other.gameObject.GetComponent<Asteroids>().hp--;

            if (other.gameObject.GetComponent<Asteroids>().hp == 0)
            {
                Destroy(other.gameObject);
            }

            
            

            if (hp > 0)
            {
                --hp;
                PlayerPrefs.SetInt("HP", hp); // Set the new value in PlayerPrefs
            }


            if (hp <= 0)
            {
                // get Manager's script and call the function
                //StopMove();
                GameObject.FindGameObjectWithTag("manager").GetComponent<Manager>().WantCont();
                //make ship's movement stop
                //dir = Vector3.zero;

                //Destroy(gameObject);
            }

            takingDamage = false;

        }
        if (!takingDamage && other.gameObject.tag == "missile")
        {
            takingDamage = true;

            other.gameObject.GetComponent<Missile>().hp--;

            if (other.gameObject.GetComponent<Missile>().hp == 0)
            {
                Destroy(other.gameObject);
            }




            if (hp > 0)
            {
                --hp;
                PlayerPrefs.SetInt("HP", hp); // Set the new value in PlayerPrefs
            }


            if (hp <= 0)
            {
                // get Manager's script and call the function
                //StopMove();
                GameObject.FindGameObjectWithTag("manager").GetComponent<Manager>().WantCont();
                //make ship's movement stop
                //dir = Vector3.zero;

                //Destroy(gameObject);
            }

            takingDamage = false;

        }
        if (!takingDamage && other.gameObject.tag == "fly")
        {
            takingDamage = true;

            other.gameObject.GetComponent<Fly>().hp--;

            if (other.gameObject.GetComponent<Fly>().hp == 0)
            {   int count = PlayerPrefs.GetInt("count");
                count++;
                PlayerPrefs.SetInt("count", count);
                Destroy(other.gameObject);
            }




            if (hp > 0)
            {
                --hp;
                PlayerPrefs.SetInt("HP", hp); // Set the new value in PlayerPrefs
            }


            if (hp <= 0)
            {
                // get Manager's script and call the function
                //StopMove();
                GameObject.FindGameObjectWithTag("manager").GetComponent<Manager>().WantCont();
                //make ship's movement stop
                //dir = Vector3.zero;

                //Destroy(gameObject);
            }

            takingDamage = false;

        }

    }

    public void StopMove()
    {
        dir = Vector3.zero;
        rb.velocity = Vector3.zero;
    }

    
    //it should fire an object by 2 seconds using instantiate and its direction should be the same as the ship's direction when firing
    public void Fire()
    {
        Vector3 fireDirection = transform.right;

        GameObject fire = Instantiate(firePrefab, transform.position + transform.right * 0.8f, Quaternion.identity);
        fire.transform.up = fireDirection;
        Rigidbody fireRb = fire.GetComponent<Rigidbody>();
        fireRb.velocity = fireDirection * 70;
    }

    IEnumerator FireRoutine()
    {
        isFiring = true;
        while (canFire)
        {
            Fire();
            yield return new WaitForSeconds(fireRate);

            if (manager.panel.activeSelf)
            {
                yield break;
            }

        }
        isFiring = false;
    }

    public void GameOver()
    {
        PlayerPrefs.SetInt("HP", 10);
        PlayerPrefs.SetInt("count", 0);
        // Rest of your game over logic...
    }

}
