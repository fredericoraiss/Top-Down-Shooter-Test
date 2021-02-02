using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UILevelController : MonoBehaviour
{
    [Header("Interface Player")]
    public TMP_Text playerAmmo;
    public TMP_Text playerLife;
    public TMP_Text playerWeapon;


    public Image reloadIndicatorPlayer;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        playerAmmo.SetText($"Ammo: {LevelController.instance._player.weaponController.currentAmmo}/{LevelController.instance._player.weaponController.weapon.totalAmmo}");
        playerLife.SetText($"Life: {LevelController.instance._player.currentLife}");
        
    }


    public void ChangeWeapon()
    {

    }
}
