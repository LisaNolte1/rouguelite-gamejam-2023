using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    [SerializeField]
    float shopRange = 3f;
    void Start()
    {
        
    }

    private void toggleShop()
    {
        if(Vector3.Distance(player.transform.position, this.transform.position) <= shopRange)
        {
            if(UIManager.shopPanel?.activeInHierarchy == false)
            {
                UIManager.toggleShopPanel();
            }

        }
        else
        {
            if(UIManager.shopPanel?.activeInHierarchy == true)
            {
                UIManager.toggleShopPanel();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        toggleShop();
    }
}
