using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class CanvasManager : MonoBehaviour
{
    [SerializeField]private GameObject healthText;
    private TextMeshProUGUI healthTMPro;
    private PlayerPunk playerPunk;

    [SerializeField] private Slider healthBar;

    

    private void Awake()
    {
        healthTMPro = healthText.GetComponent<TextMeshProUGUI>();
        playerPunk = FindObjectOfType<PlayerPunk>();

    }


    private void Start()
    {
        healthBar.maxValue = playerPunk.GetPlayerMAxHealth();

    }


    private void Update()
    {


        UpdateHealthSlider();

        UpdateHealthAmountText();


    }

    private void UpdateHealthAmountText()
    {
        healthTMPro.text = playerPunk.GetPlayerCurrentHealth().ToString();
    }

    private void UpdateHealthSlider()
    {

        healthBar.value = playerPunk.GetPlayerCurrentHealth();

    }
}
