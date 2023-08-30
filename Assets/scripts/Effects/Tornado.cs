using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tornado : MonoBehaviour, IEffect
{
    public void ApplyEffect(GameObject player)
    {
        GameObject tornado = Resources.Load<GameObject>("Tornado");
        Vector3 direction = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0f);
        GameObject currentTornado = Instantiate(tornado,player.transform.position,Quaternion.identity);

    }

    // Start is called before the first frame update
    void Start()
    {
        EffectManager.AddEffect(EffectManager.Effects.Tornado, 1, 1, this);
    }

    // Update is called once per frame
}
