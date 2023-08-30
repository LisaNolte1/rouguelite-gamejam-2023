using UnityEngine;

public class PyroBlast : MonoBehaviour, IEffect
{
    // Start is called before the first frame update
    public static float cooldown = 4f;

    public void ApplyEffect(GameObject player)
    {
        GameObject fireBall = Resources.Load<GameObject>("fire_spell");
        for (int i = 0; i < 5; i++)
        {
            GameObject temp = Instantiate(fireBall, player.transform.position, Quaternion.identity);
            temp.GetComponent<fireBall_spell>().setUpgraded();
        }
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
