using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
   public float hp;

   public bool IsDead()
   {
        if (hp <= 0)
            return true;
        else
            return false;
   }
}
