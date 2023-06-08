using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDying : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<Player>()) 
        {
            Destroy(this.gameObject);
        }
    }
}
