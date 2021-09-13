using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Observer : MonoBehaviour
{

    public static void SaveCoinsToMemory(int amount)
    {
        PlayerPrefs.SetInt("CoinAmount", PlayerPrefs.GetInt("CoinAmount") + amount);
    }

}
