using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    Vector3 prevPosition;
    [SerializeField]
    float rotationForce = 1f;
    // Start is called before the first frame update
    void Start()
    {
        prevPosition = Input.mousePosition;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetAxis("Fire1") > 0)
            Rotate();
        prevPosition = Input.mousePosition;
    }
    void Rotate()
    {
        Vector3 newPosition = Input.mousePosition;
        newPosition = (prevPosition - newPosition) * rotationForce;
        newPosition = new Vector3(-newPosition.y, newPosition.x, 0);
        if(this.transform.childCount == 0) return;
        this.transform.GetChild(0).Rotate(newPosition, Space.World);
    }
}
