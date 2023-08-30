using System;
using UnityEngine;

public class TornadoSpell : MonoBehaviour
{
    // Start is called before the first frame update
    Vector3 direction = Vector3.zero;
    Vector3 startPos;
    bool upgraded = false;
    GameObject lightning;
    void Start()
    {
        startPos = transform.position;
        int randomNumber = UnityEngine.Random.Range(0, 4);
        switch(randomNumber)
        {
            case 0:
                direction = Vector3.up; break;
            case 1:
                direction = Vector3.down; break;
            case 2:
                direction = Vector3.left; break;
            case 3:
                direction = Vector3.right; break;

        }

    }


    void DoTornado()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        enemies = Array.FindAll(enemies, x => Vector3.Distance(this.transform.position, x.transform.position) < StatManager.getRange()/2);
        foreach (GameObject enemy in enemies)
        {
            if(upgraded)
            {
               GameObject currentLightning = Instantiate(lightning,enemy.transform.position,Quaternion.identity);
                enemy.GetComponent<EnemyAbstract>().damageEnemy(StatManager.getDamageMultiplyer());
            }
            Vector3 directionToSuckingPoint = (this.transform.position - enemy.transform.position).normalized;
            Vector3 attractionVector = directionToSuckingPoint * StatManager.getSpeed() * 2 * Time.deltaTime;
            enemy.transform.position += attractionVector;

            //Damage enemies
        }
    }

    void movement()
    {
        if (direction != Vector3.zero)
        {
            this.transform.position += (direction * StatManager.getSpeed() * Time.deltaTime);
            if(Vector3.Distance(this.transform.position,startPos) > StatManager.getRange())
            {
                Destroy(this.gameObject);
            }
            else
            {
                DoTornado();
            }
        }
    }

    public void setUpgrade()
    {
        upgraded = true;
        lightning = Resources.Load<GameObject>("Lightning");

    }

    // Update is called once per frame
    void Update()
    {
        movement();
    }
}
