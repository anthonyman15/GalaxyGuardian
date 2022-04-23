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
/*        nameLabel = transform.Find("nameText").gameObject;
        priceLabel = transform.Find("priceText").gameObject;*/

        nameLabel.GetComponent<Text>().text = itemName;
        priceLabel.GetComponent<Text>().text = price.ToString();
    }
}
