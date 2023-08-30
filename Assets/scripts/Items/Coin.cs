using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    // Start is called before the first frame update
    static float value = 5;
    SoundManager soundManager;
    void Start()
    {
        soundManager = GameObject.FindGameObjectWithTag("soundManager")?.GetComponent<SoundManager>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            StatManager.addCoins(value);
            soundManager.PlayClip(SoundManager.clips.coin);
            Destroy(this.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
