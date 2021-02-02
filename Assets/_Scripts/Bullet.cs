using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour
{

    private InputController controls;

    public float speedMove = 100f;
    [HideInInspector] public Rigidbody2D rb;
    public float timeDestroy = 2f;

    Vector3 moveDirection;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    private void Start()
    {
        controls = new InputController();
        Destroy(this.gameObject, timeDestroy);


    }
    void Update()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D c)
    {
        if (c.CompareTag("Enemy"))
        {
            c.GetComponent<EnemyController>().Damage(LevelController.instance._player.weaponController.weapon.damage);
            Destroy(gameObject);
        }
    }

}
