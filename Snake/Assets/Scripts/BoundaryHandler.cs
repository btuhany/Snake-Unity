using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundaryHandler : MonoBehaviour
{
    public static BoundaryHandler Instance;
    public Vector2Int MaxBoundaryPointVector;  //max boundary values
    public Vector2Int MinBoundaryPointVector;  //min boundary values


    private void Awake()
    {
        Instance = this;    
        foreach (Transform boundaryTransform in GetComponentsInChildren<Transform>())
        {
            if (boundaryTransform.position.x > MaxBoundaryPointVector.x)
                MaxBoundaryPointVector.x = Mathf.RoundToInt(boundaryTransform.position.x);
            if (boundaryTransform.position.y > MaxBoundaryPointVector.y)
                MaxBoundaryPointVector.y = Mathf.RoundToInt(boundaryTransform.position.y);
            if (boundaryTransform.position.x < MinBoundaryPointVector.x)
                MinBoundaryPointVector.x = Mathf.RoundToInt(boundaryTransform.position.x);
            if (boundaryTransform.position.y < MinBoundaryPointVector.y)
                MinBoundaryPointVector.y = Mathf.RoundToInt(boundaryTransform.position.y);
        }
    }
}
