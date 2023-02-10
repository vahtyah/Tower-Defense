using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityInput = UnityEngine.Input;


public class RotateObject : MonoBehaviour
{
    //[SerializeField] float rotationSpeed = 50;

    //[System.Obsolete]
    //private void FixedUpdate()
    //{
    //    Vector3 mousePosition = UnityInput.mousePosition;
    //    float x = Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;
    //    transform.RotateAround(Vector3.down,x);
    //}

    public bool clampScroll = true;
    public float scrollXBuffer;

    public float scrollYBuffer;
    private void Update()
    {
        Vector3 mousePosition = Input.mousePosition;
        float angle = (mousePosition.x / Screen.width) * 360;
        transform.rotation = Quaternion.Euler(new Vector3(0, angle, 0));
    }
}
