using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour, IDamagable
{
    [SerializeField] int hp;
    [SerializeField] ParticleSystem particle;

    private void Die()
    {
        Instantiate(particle, transform.position, transform.rotation);
        Destroy(gameObject);
    }

    public void TakeDamage(int damage)
    {
        hp -= damage;
        if (hp <= 0)
        {
            Die();
        }
    }
}
