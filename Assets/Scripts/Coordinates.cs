using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Coordinates : MonoBehaviour
{
    TextMeshPro label;

    private void Start()
    {
        label = GetComponent<TextMeshPro>();
        Vector2Int coordinates = new Vector2Int(Mathf.RoundToInt(transform.position.x), Mathf.RoundToInt(transform.position.z));
        label.text = coordinates.x + "," + coordinates.y;
    }
}
