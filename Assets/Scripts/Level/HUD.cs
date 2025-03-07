using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HUD : MonoBehaviour
{
    public TextMeshProUGUI score;
    public TextMeshProUGUI numCoins;
    public TextMeshProUGUI time;

    private float countdownTime = 300f;

    int coins = 0;
    // Start is called before the first frame update
    void Start()
    {
        coins = 0;
        numCoins.text = "x" + coins.ToString("D2");
    }

    // Update is called once per frame
    void Update()
    {
        if (countdownTime > 0)
        {
            countdownTime -= Time.deltaTime;
            //Debug.Log("Tiempo restante: " + Mathf.Floor(countdownTime));
        }
        //score.text = Score.Instance.puntos.ToString("D6");
    }
    public void AddCoins()
    {
        coins++;
        numCoins.text = "x" + coins.ToString("D2");
    }
    public void UpdateCoins(int totalCoins)
    {
        numCoins.text = "x" + totalCoins.ToString("D2");
    }
}
