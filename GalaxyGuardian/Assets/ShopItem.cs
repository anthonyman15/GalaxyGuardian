using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopItem : MonoBehaviour
{
    public string itemName;
    public string itemDesc;
    public int price;
    public GameObject nameLabel;
    public GameObject priceLabel;

    public void Start()
    {
        nameLabel.GetComponent<Text>().text = itemName;
        priceLabel.GetComponent<Text>().text = price.ToString();
    }
    
    public void Purchase(){
        Player player = GameObject.Find("PlayerBody").GetComponent<Player>();
            switch(itemName){
            case "Health":
            player.updateHealth();
            break;
            case "Speed":
            player.updateSpeed();
            break;
            case "Damage":
            player.updateDamage();
            break;
        }
    }
}
