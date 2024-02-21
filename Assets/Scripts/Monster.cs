using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Monster : MonoBehaviour, IDamagable
{
    [SerializeField] int hp;
    [SerializeField] new Rigidbody rigidbody;
   

    public void TakeDamage(int damage)
    {
        hp -= damage;
        rigidbody.AddForce(Vector3.up * 15f, ForceMode.Impulse);
        if (hp <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Destroy(gameObject);
    }
}
