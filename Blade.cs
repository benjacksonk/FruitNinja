using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blade : MonoBehaviour
{
    bool slicing;
    Collider areaCollider;
    Rigidbody body;
    Vector3 newPosition;

    // Start is called before the first frame update
    void Start()
    {
        areaCollider = GetComponent<Collider>();
        body = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (slicing)
        {
            if (Input.GetMouseButton(0) == false)
            {
                slicing = false;
                areaCollider.enabled = false;
            }
            else
            {
                newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                newPosition.z = 0;
            }
        }
        else if (Input.GetMouseButton(0))
        {
            slicing = true;
            areaCollider.enabled = true;
        }
    }

    void FixedUpdate()
    {
        if (slicing)
        {
            body.MovePosition(newPosition);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<Fruit>(out var fruit))
        {
            fruit.Slice();
        }
    }
}
