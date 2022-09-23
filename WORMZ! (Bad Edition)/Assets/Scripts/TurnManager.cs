using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class TurnManager : MonoBehaviour
{
    private static TurnManager instance;
    private int currentPlayerIndex = 1;
    private float timeLeft = 10f;
    [SerializeField] public CinemachineFreeLook  camera;

    [SerializeField] Transform playerOne;
    [SerializeField] Transform playerTwo;
    [SerializeField] Transform playerThree;
    [SerializeField] Transform playerFour;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        camera.Follow = playerOne;
        camera.LookAt = playerOne;
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
        {
            currentPlayerIndex = 2;

            camera.Follow = playerTwo;
            camera.LookAt = playerTwo;
        }
            

        else if (currentPlayerIndex == 2)
        {
            currentPlayerIndex = 3;

            camera.Follow = playerThree; 
            camera.LookAt = playerThree; 
        }
       

        else if (currentPlayerIndex == 3)
        { 
            currentPlayerIndex = 4;

            camera.Follow = playerFour;
            camera.LookAt = playerFour;
        }
        else
        {
            currentPlayerIndex = 1;
            camera.Follow = playerOne;
            camera.LookAt = playerOne;
            
        }
            
    }



}
