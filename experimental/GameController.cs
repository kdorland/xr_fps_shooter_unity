using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    private int playerHealth;
    public Text uiPlayerHealthText;

    public void Start()
    {
        this.playerHealth = 100;
    }

    public void Update()
    {
        if (this.playerHealth <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);   
        }
    }

    public int GetHealth()
    {
        return this.playerHealth;
    }

    public void AddPlayerDamage(int damage)
    {
        this.playerHealth -= damage;
        uiPlayerHealthText.text = "Health: " + this.playerHealth;
        Color init;
        ColorUtility.TryParseHtmlString("#47B473", out init);
        uiPlayerHealthText.color = Color.Lerp(init, Color.red, 1 - this.playerHealth / 100f);

    }

}
