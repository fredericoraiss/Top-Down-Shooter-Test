using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    private InputController controls;


    [Header("Movimento")]
    public float speedMove = 5f;
    private float h;
    private float v;
    private Vector3 mousePosition;

    private Rigidbody2D rb;

    InputAction primaryShootAction;
    InputAction secondaryShootAction;
    ButtonControl leftMouseButton;
    ButtonControl rightMouseButton;

    [Header("Weapon")]
    public GameObject weponObject;
    public WeaponController weaponController;

    Keyboard kb;

    [Header("Status Player")]
    public float currentLife;
    public float totalLife;



    private void Awake()
    {
        controls = new InputController();

        weponObject = transform.GetChild(0).gameObject;
        weaponController = weponObject.GetComponent<WeaponController>();

        controls.Player.SecondaryShoot.performed += secondShoot_cntx => SecondaryShootButton();

        ChangeWeapon(GameManager._instance.weponsToPlay[0]);

        primaryShootAction = controls.Player.PrimaryShoot;
        secondaryShootAction = controls.Player.SecondaryShoot;

        leftMouseButton = ((ButtonControl)primaryShootAction.controls[0]);
        rightMouseButton = ((ButtonControl)secondaryShootAction.controls[0]);

        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        kb = Keyboard.current;

        ResetPlayer();
    }

    void Update()
    {
        h = controls.Player.Horizontal.ReadValue<float>();
        v = controls.Player.Vertical.ReadValue<float>();
        mousePosition = controls.Player.MousePosition.ReadValue<Vector2>();

        // Rotate();
        PrimaryShootButton();


        if (kb.digit1Key.wasPressedThisFrame)
        {
            ChangeWeapon(GameManager._instance.weponsToPlay[0]);
        }
        if (kb.digit2Key.wasPressedThisFrame)
        {
            ChangeWeapon(GameManager._instance.weponsToPlay[1]);
        }

        if (kb.rKey.wasPressedThisFrame && !weaponController.isReloading)
            StartCoroutine(weaponController.ReloadingWeapon());
    }


    private void FixedUpdate()
    {
        Move();
    }

    private void OnEnable()
    {
        controls.Enable();
    }
    private void OnDisable()
    {
        controls.Disable();
    }


    public void ResetPlayer()
    {
        currentLife = totalLife;
    }

    public void ChangeWeapon(Weapon w)
    {
        weaponController.weapon = w;
        weaponController.currentAmmo = w.totalAmmo;
        LevelController.instance._uiLevel.playerWeapon.SetText(weaponController.weapon.name);

    }

    public void Move()
    {
        Vector2 move = new Vector2(h, v);
        //rb.velocity = (move * Time.deltaTime) * speedMove;
        rb.MovePosition(rb.position + move * speedMove * Time.fixedDeltaTime);

        Rotate();
    }

    public void PrimaryShootButton()
    {
        if (leftMouseButton.isPressed)
            weaponController.PrimaryWeaponShootController();
    }

    public void SecondaryShootButton()
    {
        weaponController.SecondaryWeaponShootController();
    }

    public void Rotate()
    {
        Vector3 dir = mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
    }
}
