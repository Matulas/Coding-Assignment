using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Camera : MonoBehaviour
{
    [SerializeField] public int cameraTurnNumber;
    [SerializeField] CinemachineFreeLook cameraOne;
    [SerializeField] CinemachineFreeLook cameraTwo;
    [SerializeField] CinemachineFreeLook cameraThree;
    [SerializeField] CinemachineFreeLook cameraFour;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
      if (TurnManager.GetInstance().IsItPlayerTurn(cameraTurnNumber))
      {
            
      }
      else
      {
           
      }
    } 

    void SwitchCamera()
    {

    }
}
