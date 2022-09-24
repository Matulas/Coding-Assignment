using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
   public float hp;

   public bool IsDead()
   {
     return hp <= 0;
      
   }
    public void TakeDamage(float amount)
    {
        hp -= amount;
    }
}
