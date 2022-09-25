using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class TurnManager : MonoBehaviour
{
    private static TurnManager instance;
    private int currentPlayerIndex = 1;
    private float timeLeft = 15f;
    [SerializeField] public CinemachineFreeLook  camera;

    [SerializeField] GameObject playerOne;
    [SerializeField] GameObject playerTwo;
    [SerializeField] GameObject playerThree;
    [SerializeField] GameObject playerFour;
    private Health pOneHealth;
    private Health pTwoHealth;
    private Health pThreeHealth;
    private Health pFourHealth;

    private void Awake()
    {
       
        
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        pOneHealth = playerOne.GetComponent<Health>();
        pTwoHealth = playerTwo.GetComponent<Health>();
        pThreeHealth = playerThree.GetComponent<Health>();
        pFourHealth = playerFour.GetComponent<Health>();

           camera.Follow = playerOne.transform;
           camera.LookAt = playerOne.transform;
             

    }

    private void Update()
    {
        if (timeLeft >= 0)
        {
            timeLeft -= Time.deltaTime;
        }
        else
        {
            ChangeTurn();

            timeLeft = 15f;
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
 
            if (pTwoHealth.IsDead())
            {
                Debug.Log("2 died");
                ChangeTurn();
            }
            else
            {
                camera.Follow = playerTwo.transform;
                camera.LookAt = playerTwo.transform;
            }

        }
        else if (currentPlayerIndex == 2)
        {
            currentPlayerIndex = 3;

            if (pThreeHealth.IsDead())
            {
                ChangeTurn();
            }
            else
            {
                camera.Follow = playerThree.transform;
                camera.LookAt = playerThree.transform;
            }

        }
        else if (currentPlayerIndex == 3)
        {
            currentPlayerIndex = 4;

            if (pFourHealth.IsDead())
            {
                ChangeTurn();
            }
            else
            {
                camera.Follow = playerFour.transform;
                camera.LookAt = playerFour.transform;
            }
;
        }
        else
        {
            currentPlayerIndex = 1;

            if (pOneHealth.IsDead())
            {
                ChangeTurn();
            }
            else 
            {
                camera.Follow = playerOne.transform;
                camera.LookAt = playerOne.transform;
            }

            
        }
            
    }



}
