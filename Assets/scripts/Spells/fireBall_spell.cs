using UnityEngine;

public class fireBall_spell : MonoBehaviour
{

    
    [SerializeField]
    private float lifeSpan;

    private Vector3 direction;

    [SerializeField]
    private float damageMultiplyer;

    private Vector3 startpos;

    bool upgraded = false;

    public float sizeFactor = 2;

    public float speedFactor = 2;

    public float damageFactor = 2;

    // Start is called before the first frame update
    void Start()
    {
        startpos = transform.position;
        direction = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0);
    }

    // Update is called once per frame
    void Update()
    {
        rangeCheck();
        movement();
    }

    void movement()
    {
        this.transform.position += upgraded ? (direction * StatManager.getSpeed() * Time.deltaTime * speedFactor) : (direction * StatManager.getSpeed() * Time.deltaTime);
        Vector3 currentDirection = (this.transform.position - startpos).normalized;

        float rotationAngle = Mathf.Atan2(currentDirection.y, currentDirection.x) * Mathf.Rad2Deg;

        // Apply rotation to the object
        transform.rotation = Quaternion.Euler(0f, 0f, rotationAngle);

        // Apply rotation to the object

    }

    void rangeCheck()
    {
        if(Vector3.Distance(transform.position,startpos) >= StatManager.getRange() * 2)
        {
            Destroy(gameObject);
        }
    }

    public void setUpgraded()
    {
        upgraded = true;
        this.gameObject.transform.localScale = this.gameObject.transform.localScale * 1.5f;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            //do damage
            if (!upgraded)
            {
                collision.gameObject.GetComponent<EnemyAbstract>().damageEnemy(StatManager.getDamageMultiplyer() * damageMultiplyer);
            }
            else
            {
                collision.gameObject.GetComponent<EnemyAbstract>().damageEnemy(StatManager.getDamageMultiplyer() * damageMultiplyer * damageFactor);
            }
            
            Destroy(this.gameObject);
        }
        else
        {
            Destroy(gameObject) ;
        }
    }
}
