using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public HUD hud;
    int coins;

    public static LevelManager Instance;
    private void Awake()
    {
        if(Instance != null)
        {
            Instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        coins = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AddCoins()
    {
        coins++;
        hud.UpdateCoins(coins);
    }
}
