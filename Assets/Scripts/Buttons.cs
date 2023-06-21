using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttons : MonoBehaviour
{
    // Start is called before the first frame update
    public void PlayB()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(1); //go to game scene
    }

    public void QuitB()
    {
        PlayerPrefs.DeleteKey("GameStarted");
        Application.Quit();
    }

    public void PurchaseB()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(2); //go to purchase scene
    }

    public void MenuB()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0); //go to menu scene
    }
    private void Start()
    {
        PlayerPrefs.SetInt("HP", 10);
        PlayerPrefs.SetInt("count", 0);
    }

    public void AboutB()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(7); //go to about scene
    }

    public void HowToB()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(8);
    }

}
