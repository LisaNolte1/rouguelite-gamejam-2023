using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    // Start is called before the first frame update

    AIPath aiPath;

    enum direction
    {
        up =1 , down =2, left =3, right =4
    }

    direction currentDirection = direction.up;

    void Start()
    {
        aiPath = GetComponent<AIPath>();
    }

    void changeCurrentDirection()
    {
        if(aiPath.desiredVelocity.x > 0)
        {
            currentDirection = direction.right;
        }else if(aiPath.desiredVelocity.x < 0) 
        { 
            currentDirection = direction.left;
        }else if(aiPath.desiredVelocity.y > 0 ) 
        { 
            currentDirection=direction.up;
        }else if(aiPath.desiredVelocity.y < 0)
        {
            currentDirection=direction.down;
        }
    }

    // Update is called once per frame
    void Update()
    {
        changeCurrentDirection();
    }
}
