using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Shop : MonoBehaviour
{
    public Transform container;
    public Transform shopItemTemplate;

    public void Awake()
    {
        //Reference for Container
        container = transform.Find("container");
        //Reference for Shop Item Template
        shopItemTemplate = container.Find("shopItemTemplate");
        shopItemTemplate.gameObject.SetActive(false);
    }
}
