using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    float attackSpeed { get; set; } = 1f;
    float attackTime = 0f;
    const float offset = 1f;
    public GameObject projectile;

    void Start()
    {
        attackTime = attackSpeed;
    }

    void attack()
    {
        if(attackTime >= attackSpeed)
        {
            float VerticalInput = Input.GetKey(KeyCode.DownArrow) ? -1 : 0;
            VerticalInput += Input.GetKey(KeyCode.UpArrow) ? 1 : 0;
            float HorizontalInput = Input.GetKey(KeyCode.RightArrow)? 1 : 0;
            HorizontalInput += Input.GetKey(KeyCode.LeftArrow)? -1 : 0;
            
            if (Input.GetKey(KeyCode.DownArrow)
                || Input.GetKey(KeyCode.UpArrow)
                || Input.GetKey(KeyCode.RightArrow)
                || Input.GetKey(KeyCode.LeftArrow))
            {
                Vector2 direction = new Vector2 (HorizontalInput, VerticalInput);
                GameObject currentProject = Instantiate(projectile, new Vector3(this.transform.position.x + direction.x*offset, this.transform.position.y + direction.y*offset, this.transform.position.z), Quaternion.identity);
                currentProject.GetComponent<Projectile>().direction = direction;
                attackTime = 0f;
            }
            //else if (Input.GetKeyDown(KeyCode.UpArrow))
            //{
            //    GameObject currentProject = Instantiate(projectile, new Vector3(this.transform.position.x, this.transform.position.y + offset, this.transform.position.z), Quaternion.identity);
            //    currentProject.GetComponent<Projectile>().direction = Vector2.up;
            //    attackTime = 0f;
            //}
            //else if (Input.GetKeyDown(KeyCode.RightArrow))
            //{
            //    GameObject currentProject = Instantiate(projectile, new Vector3(this.transform.position.x + offset, this.transform.position.y, this.transform.position.z), Quaternion.identity);
            //    currentProject.GetComponent<Projectile>().direction = Vector2.right;
            //    attackTime = 0f;
            //}
            //else if (Input.GetKeyDown(KeyCode.LeftArrow))
            //{
            //    GameObject currentProject = Instantiate(projectile, new Vector3(this.transform.position.x - offset, this.transform.position.y, this.transform.position.z), Quaternion.identity);
            //    currentProject.GetComponent<Projectile>().direction = Vector2.left;
            //    attackTime = 0f;
            //}
        }
        else
        {
            attackTime += Time.deltaTime;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        attack();
    }
}
