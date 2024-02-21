using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHolder : MonoBehaviour
{
    [SerializeField] Gun[] guns;

    private Gun curGun;

    public void Start()
    {
        curGun = guns[0];
    }

    public void Fire()
    {
        curGun.Fire();
    }
}
