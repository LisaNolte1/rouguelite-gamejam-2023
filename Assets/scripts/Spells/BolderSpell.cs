using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BolderSpell : MonoBehaviour
{
    // Start is called before the first frame update
    bool istargeted = false;
    GameObject target;
    float counter = 0;
    public float DamageScaling = 0.5f;
    Vector3 startPos = Vector3.zero;
    void Start()
    {
        
    }

    public void setTarget(GameObject target)
    {
        istargeted = true;
        this.target = target;
        startPos = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (istargeted)
        {
            counter += Time.deltaTime;
            if(target != null)
            {
                this.transform.position = Vector3.Lerp(startPos, target.transform.position, counter);
                if (counter >= 1)
                {
                    target.GetComponent<EnemyAbstract>().damageEnemy(StatManager.getDamageMultiplyer() * DamageScaling);
                    Destroy(gameObject);

                }
            }
            else
            {
                Destroy(gameObject);
            }

        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
