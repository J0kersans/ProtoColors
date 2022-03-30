using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarScript : MonoBehaviour
{
//Détails de la barre de vie
    #region HealthBar
    private Image HealthBar;
    public float CurrentHealth;
    private float MaxHealth = 100f;
    #endregion

//Elément du script PlayerControl
    #region PlayerSpecifics
    private PlayerControl Player;
    #endregion

    // Start is called before the first frame update
    private void Start()
    {
        HealthBar = GetComponent<Image>();
        Player = FindObjectOfType<PlayerControl>();
    }

    // Update is called once per frame
    public void Update()
    {
//Complétion de la barre de vie
        CurrentHealth = Player.Health;
        HealthBar.fillAmount = CurrentHealth / MaxHealth;

        ColorChanges();
    }

    public void ColorChanges()
    {
        //Changement de couleur selon l'environnement
        if (Player.powerJump == true)
        {
            HealthBar.color = Color.blue;
        }
        
        if (Player.slowFall == true)
        {
            HealthBar.color = Color.red;
        }
        
        if (Player.powerJump == false && Player.slowFall == false)
        {
            HealthBar.color = Color.green;
        }
    }
}
