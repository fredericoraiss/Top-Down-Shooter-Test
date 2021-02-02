using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon", menuName = "Weapon")]
public class Weapon : ScriptableObject
{
    public new string name;
    public float damage = 1;
    public float fireRate;
    public GameObject bulletObj;

    public float totalAmmo;
    public float costShoot;
    public float timeToReload;
    public bool canUsed = false;
    public float valueToBuy;
    

}
