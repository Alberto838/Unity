using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinPick : MonoBehaviour
{

    int coins = 0;
    public TextMeshProUGUI countCoinsText;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name.Contains("Coin")){
            coins++;
            collision.gameObject.SetActive(false);
            SoundManager.PlaySound("Coin");
            UpdateCoinCounter();
        }
    }
    
    void UpdateCoinCounter() {
        countCoinsText.SetText("Coins: " + coins);
    }
}
