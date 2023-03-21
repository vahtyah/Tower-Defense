using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityInput = UnityEngine.Input;


public class RotateObject : MonoBehaviour
{
    public float speedRotation = 2f;
    private void Update()
    {
        Vector3 mousePosition = Input.mousePosition;
        if (mousePosition.x > Screen.width/2)
            transform.Rotate(new Vector3(0, speedRotation * Time.deltaTime, 0));
        else transform.Rotate(new Vector3(0, -speedRotation * Time.deltaTime, 0));
    }
}
