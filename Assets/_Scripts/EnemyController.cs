using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{

    public Image healthBarImage;

    public float totalLife = 10;
    public float currentLife;

    // Start is called before the first frame update
    void Start()
    {
        currentLife = totalLife;
    }

    // Update is called once per frame
    void Update()
    {
        healthBarImage.fillAmount = currentLife/totalLife;

        if(currentLife <= 0 ) currentLife = totalLife; //DEBUG
    }


    public void Damage(float value){
        currentLife -= value;
    }


}
