using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{

    public Image HealthBar;
    public float HealthAmount = 100f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (HealthAmount <= 0)
        {
          //  SceneManager.LoadScene(String LoadedScene);
        }
        if (Input.GetKeyDown(KeyCode.Return))
        {
            TakeDamage(20);
        }

        if (Input.GetKeyDown(KeyCode.Space))
            {
            Heal(5);
        }
    }

public void TakeDamage(float Damage)
    {
        HealthAmount -= Damage;
        HealthBar.fillAmount = HealthAmount / 100f;
    }

public void Heal(float HealingAmount)
    {
        HealthAmount += HealingAmount;
        HealthAmount = Mathf.Clamp(HealthAmount, 0, 100);

        HealthBar.fillAmount = HealthAmount / 100f;
    }
}
