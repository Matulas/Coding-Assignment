using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{

    float hp = 3;
    public bool IsDead()
    {
     return hp <= 0;

    }
    public void TakeDamage(float amount)
    {
        hp -= amount;
    }

    private void Update()
    {
        if (hp == 2)
        {
          var color =  GetComponent<MeshRenderer>();
          color.material.color = Color.gray;
        }
        else if ( hp == 1)
        {
            var color = GetComponent<MeshRenderer>();
            color.material.color = Color.black;
        }


        if (IsDead())
        {
            Destroy(this.gameObject);
        }
            
    }
}
