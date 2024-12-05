using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    public GameObject whole;
    public GameObject sliced;
    public float force;

    private void Start()
    {
        
    }

    public void Slice()
    {
        whole.SetActive(false);
        sliced.SetActive(true);
        
        var slices = sliced.GetComponentsInChildren<Rigidbody>();

        foreach (var slice in slices)
        {
            slice.velocity = GetComponent<Rigidbody>().velocity;
            slice.AddForce(Random.insideUnitCircle * force, ForceMode.Impulse);
        }
    }
}
