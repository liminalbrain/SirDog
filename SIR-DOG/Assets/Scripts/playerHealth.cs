using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class playerHealth : MonoBehaviour
{
    public float health;
    public float maxHealth;
    public Image healthBar;
    // Start is called before the first frame update
    void Start()
    {
        maxHealth = health;
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.fillAmount = Mathf.Clamp(health / maxHealth, 0, 1);
        if (health <= 0)
        {
            Debug.Log("Health is 0 or lower!");
            GetComponent<PlayerController1>().RespawnPlayer();
            health = maxHealth;
        }
    }
}
