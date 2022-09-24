using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserDecay : MonoBehaviour
{

    [SerializeField] private float timeToDie;
    // Start is called before the first frame update
    void Start()
    {
        Object.Destroy(this.gameObject, timeToDie);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
