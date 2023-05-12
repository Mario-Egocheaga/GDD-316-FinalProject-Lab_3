using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class HealthController : MonoBehaviour
{
    [SerializeField]
    private float maximumInjuredLayerWeight;

    private float maximumHealth = 100;
    public static float currentHealth;

    private Animator animator;
    private int injuredLayerIndex;
    private float layerWeightVelocity;

    public Slider healthSlider;

    public GameObject gameOverScreen;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maximumHealth;
        animator = GetComponent<Animator>();
        injuredLayerIndex = animator.GetLayerIndex("Injured");
    }

    // Update is called once per frame
    void Update()
    {
        healthSlider.value = currentHealth;

        if (currentHealth <= 0)
        {
            gameOverScreen.SetActive(true);

        }
    }

    void InjuredLayerAnim()
    {
        float healthPercentage = currentHealth / maximumHealth;

        float currentInjuredLayerWeight = animator.GetLayerWeight(injuredLayerIndex);
        float targetInjuredLayerWeight = (healthPercentage * 10) * maximumInjuredLayerWeight;
        animator.SetLayerWeight(
            injuredLayerIndex,
            Mathf.SmoothDamp(
                currentInjuredLayerWeight,
                targetInjuredLayerWeight,
                ref layerWeightVelocity,
                0.2f)
            );
    }
    
    public void OnTest()
    {
        currentHealth -= maximumHealth / 10;
        /*
        if (currentHealth < 0)
        {
            currentHealth = maximumHealth;
            animator.SetLayerWeight(1, 0f);
        }
        */
        InjuredLayerAnim();
    }

}
