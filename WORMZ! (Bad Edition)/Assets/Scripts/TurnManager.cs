using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    private static TurnManager instance;
    private int currentPlayerIndex = 1;
    private float timeLeft = 10f;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;

        }
    }

    private void Update()
    {
        if (timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
        }
        else
        {
            ChangeTurn();

            timeLeft = 10f;
        }
       
    }

    public bool IsItPlayerTurn(int index)
    {
        return index == currentPlayerIndex;
    }

    public static TurnManager GetInstance()
    {
        return instance;
    }

    public void ChangeTurn()
    {
        if (currentPlayerIndex == 1)
            currentPlayerIndex = 2;

        else if (currentPlayerIndex == 2)
            currentPlayerIndex = 3;

        else if (currentPlayerIndex == 3)
            currentPlayerIndex = 4;

        else
            currentPlayerIndex = 1;
    }

}
