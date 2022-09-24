using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    private float damage = 10;
    private LineRenderer lr;
   [SerializeField] private Transform startPoint;
    public GameObject laser;
    // Start is called before the first frame update
    void Start()
    {
        lr = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("k"))
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
            Debug.Log(Vector3.Distance(this.gameObject.transform.position, hit.point));
            laser.transform.position = new Vector3(0f, 0f, Vector3.Distance(this.gameObject.transform.position, hit.point) / 2);
            Health target = hit.collider.GetComponent<Health>();

            if (target != null)
            {
                target.TakeDamage(damage);
            }
        }
        else
        {
            Instantiate(laser, this.gameObject.transform);
            laser.transform.localScale = new Vector3(0.01f, 0.01f, 10000f); //10000f infinity length
            Debug.Log(Vector3.Distance(this.gameObject.transform.position, hit.point));
            laser.transform.position = new Vector3(0f, 0f, 10000f/2f);
        }

    }
}
