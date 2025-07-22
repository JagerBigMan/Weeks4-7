using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hero : MonoBehaviour
{
    public Slider healthbarSlider;
    public float maxHealth;
    public float minHealth;
    public float damage;

    private float currentHealth;


    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthbarSlider.value = currentHealth / maxHealth;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnDamageClick()
    {
        currentHealth -= damage;
        healthbarSlider.value = currentHealth / maxHealth;
    }
}
