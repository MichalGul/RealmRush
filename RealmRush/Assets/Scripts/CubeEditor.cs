using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Dzięki temu skrypt będzie się odpalał w edytorze 
[ExecuteInEditMode]
[SelectionBase]
public class CubeEditor : MonoBehaviour
{

    [SerializeField] [Range(1f, 20f)] public float gridSize;
    TextMesh textMesh;

    // Start is called before the first frame update
    void Start()
    {
       
        
    }

    // Update is called once per frame
    void Update()
    {
        // Snap block to 10/10/10 grid
        Vector3 snapPosition;
        snapPosition.x = Mathf.RoundToInt(transform.position.x / gridSize) *gridSize;
        snapPosition.z = Mathf.RoundToInt(transform.position.z / gridSize) * gridSize;

        textMesh = GetComponentInChildren<TextMesh>();
        textMesh.text = snapPosition.x /gridSize + "," + snapPosition.z / gridSize;

        transform.position = new Vector3(snapPosition.x, 0, snapPosition.z);
    }
}
