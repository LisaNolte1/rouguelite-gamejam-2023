using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LightningTornado : MonoBehaviour, IEffect
{
    // Start is called before the first frame update

    public static float cooldown = 5f;
    void Start()
    {
        
    }

    public void ApplyEffect(GameObject player)
    {
        GameObject tornado = Resources.Load<GameObject>("Tornado");
        GameObject currentTornado = Instantiate(tornado, player.transform.position, Quaternion.identity);
        currentTornado.GetComponent<TornadoSpell>().setUpgrade();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
