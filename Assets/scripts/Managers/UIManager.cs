using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI coinsLabel;
    void Start()
    {
        coinsLabel.text = "Coins: " + StatManager.getCoins();
    }

    public void setCoinsLabel(float coins)
    {
        coinsLabel.text = "Coins: " + coins;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
