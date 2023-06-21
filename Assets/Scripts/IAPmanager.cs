using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;
using UnityEngine.Purchasing.Extension;

public class IAPmanager : MonoBehaviour
{

    


    private string skin1 = "com.6.1.";
    private string skin2 = "com.6.2.";
    private string skin3 = "com.6.3.";

    public GameObject restoreB;

    private void Awake()
    {
        if(Application.platform == RuntimePlatform.IPhonePlayer)
        {
            restoreB.SetActive(false);
        }




    }


    public void OnPurchaseComplete(Product product)
    {
        if(product.definition.id == skin1)
        {
            print("Skin 1 purchased");
        }
        else if(product.definition.id == skin2)
        {
            print("Skin 2 purchased");
        }
        else if(product.definition.id == skin3)
        {
            print("Skin 3 purchased");
        }
    }

    public void OnPurchaseFailed(Product product, PurchaseFailureDescription reason)
    {
        print(product.definition.id + "failed to purchase cuz " + reason);
    }


}
