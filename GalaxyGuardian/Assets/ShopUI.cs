using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopUI : MonoBehaviour
{
    //Check shop is opened
    public static bool isOpen = false;
    public GameObject itemPrefab;

    //Upgrade
    string[,] array2D = new string[,] {
        {"Health", "Health Upgrade","10"},
        {"Speed","Speed Upgrade","10" },
        {"Damage","Damage Upgrade","10" }
    };

    public static Dictionary<string, int> upgradePurchase = new Dictionary<string, int>();

    void Start()
    {
        upgradePurchase.Clear();
        Debug.Log("Start Shop");
        GameObject shopMenu = GameObject.Find("ShopMenu");
        for (int i = 0; i < array2D.GetLength(0); i++)
        {
            upgradePurchase.Add(array2D[i, 0], 0);
            var item = Instantiate(itemPrefab, shopMenu.transform.position, Quaternion.identity).GetComponent<ShopItem>();
            item.itemName = array2D[i, 0];
            item.itemDesc = array2D[i, 1];
            item.price = int.Parse(array2D[i, 2]);
            item.transform.parent = shopMenu.transform;
        }
    }
    void ShopOpen()
    {
        if (isOpen)
            return;
        isOpen = true;
    }

    void ShopClose()
    {
        if (!isOpen)
            return;
        isOpen = false;
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            ShopOpen();
            Debug.Log("Shop Open");
        }
    }

    void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            ShopClose();
            Debug.Log("Shop Close");

            new Player().maxHealth = 100 + (upgradePurchase["Health"] * 20);

        }
    }


}
