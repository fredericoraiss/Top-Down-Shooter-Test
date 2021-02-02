using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    public static GameManager _instance { get; private set; }

    [Header("Game Variables")]
    [SerializeField] private float moneyInGame = 100;
    [SerializeField] private float totalDeaths = 0;


    [Header("Player Status")]
    public Weapon[] weponsToPlay;

    #region Encapsulamento

    public float MoneyInGame { get { return moneyInGame; } set { moneyInGame = value; } }
    public float TotalDeaths { get { return totalDeaths; } set { totalDeaths = value; } }

    #endregion



    void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else
        {
            Destroy(this.gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);


    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            Application.Quit();
            Debug.Log("IS QUITTING");
        }
    }
}
