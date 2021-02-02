using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public Weapon weapon;
    public Transform positionToSpawnBullet;
    public float nextShoot;

    public float currentAmmo;

    public bool isReloading = false;

    private float totalTimeToReload;

    // Start is called before the first frame update
    void Start()
    {
        currentAmmo = weapon.totalAmmo;
    }

    // Update is called once per frame
    void Update()
    {
        if (isReloading)
        {
            totalTimeToReload -= Time.deltaTime;
            LevelController.instance._uiLevel.reloadIndicatorPlayer.fillAmount = totalTimeToReload / weapon.timeToReload;
        }
        else
        {
            LevelController.instance._uiLevel.reloadIndicatorPlayer.fillAmount = 0;
        }
    }

    public void PrimaryWeaponShootController()
    {
        //TO-DO: colocar sistema de munição completo. Pensar em pente ou total de munição 
        if (Time.time >= (weapon.fireRate + nextShoot) && currentAmmo > 0 && !isReloading)
        {

            GameObject b = Instantiate(weapon.bulletObj, positionToSpawnBullet.position, Quaternion.identity);
            b.transform.rotation = transform.rotation;
            Bullet _bullet = b.GetComponent<Bullet>();
            _bullet.rb.AddForce(positionToSpawnBullet.up * _bullet.speedMove, ForceMode2D.Impulse);


            currentAmmo -= weapon.costShoot;
            nextShoot = Time.time;

        }

        else if (currentAmmo <= 0 && !isReloading)
            StartCoroutine(ReloadingWeapon());
    }

    public void SecondaryWeaponShootController()
    {

    }

    public IEnumerator ReloadingWeapon()
    {

        totalTimeToReload = weapon.timeToReload;
        isReloading = true;
        Debug.Log("Esta Carregfando");
        yield return new WaitForSeconds(weapon.timeToReload);
        Debug.Log("Nao ta carregando");
        isReloading = false;
        currentAmmo = weapon.totalAmmo;
    }
}
