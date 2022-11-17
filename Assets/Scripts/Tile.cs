using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] Node node;
    Path path;

    private void Start()
    {
        path = FindObjectOfType<Path>();
        
    }


}
