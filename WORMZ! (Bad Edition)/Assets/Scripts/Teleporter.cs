using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    public Transform destination;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        other.transform.position = new Vector3(destination.position.x, destination.position.y + 5, destination.position.z);
    }
}
