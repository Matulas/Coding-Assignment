using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class TurnManager : MonoBehaviour
{
    private static TurnManager instance;
    private int currentPlayerIndex = 1;
    private float timeLeft = 3f;
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
 
            if (pTwoHealth.IsDead())
            {
                Debug.Log("2 died");
                ChangeTurn();
            }

            camera.Follow = playerTwo.transform;
            camera.LookAt = playerTwo.transform;
        }
            

        else if (currentPlayerIndex == 2)
        {
            currentPlayerIndex = 3;

            if (pThreeHealth.IsDead())
            {
                ChangeTurn();
            }
            
            camera.Follow = playerThree.transform; 
            camera.LookAt = playerThree.transform; 
        }
       

        else if (currentPlayerIndex == 3)
        {
           
            currentPlayerIndex = 4;

            if (pFourHealth.IsDead())
            {
                ChangeTurn();
            }

          camera.Follow = playerFour.transform;
            camera.LookAt = playerFour.transform;
        }
        else
        {
            if (pOneHealth.IsDead())
            {
                ChangeTurn();
            }
            currentPlayerIndex = 1;
           camera.Follow = playerOne.transform;
            camera.LookAt = playerOne.transform;
            
        }
            
    }



}
