using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{
    Text healthText;
    Player playerHealth;

    private void Start()
    {
        healthText = GetComponent<Text>();
        playerHealth = FindObjectOfType<Player>();
    }


    private void Update()
    {
        healthText.text = playerHealth.GetHealth().ToString();
    }
}
