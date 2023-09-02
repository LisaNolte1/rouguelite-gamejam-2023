using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fade : MonoBehaviour
{
    public SpriteRenderer renderer;
    public float counter;
    
    // Start is called before the first frame update
    void Start()
    {
        this.renderer = this.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(counter < 1)
        {
            renderer.color = Color.Lerp(Color.white, Color.clear, counter);
            counter += Time.deltaTime;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
