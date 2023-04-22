using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodController : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        TeleportToRandomPoint();
    }
    void TeleportToRandomPoint()
    {
        transform.position = new Vector3(
            Mathf.RoundToInt(Random.Range(BoundaryHandler.Instance.MinBoundaryPointVector.x + 1, BoundaryHandler.Instance.MaxBoundaryPointVector.x)),
            Mathf.RoundToInt(Random.Range(BoundaryHandler.Instance.MinBoundaryPointVector.y + 1, BoundaryHandler.Instance.MaxBoundaryPointVector.y)), 
            0f
        );
    }
}
