using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using static UnityEngine.Rendering.DebugUI;

public class Manager : MonoBehaviour
{
    public TextMeshProUGUI HPtext;
    public GameObject panel;

    GameObject ship;

    public AdManager adManager;

    public TextMeshProUGUI countText;

    [SerializeField] private AndroidNotificationsController androidNotificationsController;
    private bool isNotifying = false;


    // Start is called before the first frame update
    void Start()
    {
        //get me object with tag "ship" and get its hp
        ship = GameObject.Find("Ship");
        ship.GetComponent<ShipController>().manager = this;
        //print("found ship in  manager");

        if (!PlayerPrefs.HasKey("GameStarted") && ship.GetComponent<ShipController>().hp == 0)
        {
            PlayerPrefs.SetInt("GameStarted", 1);
            SendNotification();
        }

        panel.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateHP();

        if (panel.activeSelf == true)
        {
            ship.GetComponent<ShipController>().StopMove();
        }

    }

    public void UpdateHP()
    {
        if(ship.GetComponent<ShipController>().hp == 0)
        {
            HPtext.text = "HP: 0" ;
            

        }

        else
        {
            HPtext.text = "HP: " + ship.GetComponent<ShipController>().hp;
        }
        
        if (SceneManager.GetActiveScene().buildIndex == 6)
        {
            
            countText.text =  PlayerPrefs.GetInt("count") + "/4";
        }
        
        
        

    }

    public void WantCont()
    {   
        panel.SetActive(true);
       
    }

    
    public void NoButton()
    {
        ship.GetComponent<ShipController>().GameOver();
        
        SceneManager.LoadScene(0);
        
    }

    private void SendNotification()
    {
#if UNITY_ANDROID
        
        print("Notification should be sent");
        androidNotificationsController.ScheduleNotification(DateTime.Now.AddMinutes(1));
        
#endif
    }

    

    

    
}


