using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Weapon : MonoBehaviour
{
    private float damage = 1;
   [SerializeField] private Transform startPoint;
    public GameObject laser;
    [SerializeField] public int playerTurnNumber;
    float pokeForce = 300f;



    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("f") && TurnManager.GetInstance().IsItPlayerTurn(playerTurnNumber) && TurnManager.GetInstance().isNotTurn == false)
        {
            Shoot();
        }

    }

    void Shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, Mathf.Infinity))
        {

            Instantiate(laser, this.gameObject.transform);
            laser.transform.localScale = new Vector3(0.01f, 0.01f, Vector3.Distance(this.gameObject.transform.position, hit.point));
            laser.transform.position = new Vector3(0f, 0f, Vector3.Distance(this.gameObject.transform.position, hit.point) / 2);
            Health target = hit.collider.GetComponent<Health>();
            if (target != null) //if target has hp it takes dmg
            {
                target.TakeDamage(damage);
                hit.rigidbody.AddForce(Vector3.up * pokeForce);

            }
        }
        else
        {
            Instantiate(laser, this.gameObject.transform);
            laser.transform.localScale = new Vector3(0.01f, 0.01f, 10000f); //10000f infinity length
            laser.transform.position = new Vector3(0f, 0f, 10000f/2f);
        }

    }
}
