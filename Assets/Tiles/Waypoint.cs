using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] bool isPlaceable;
    [SerializeField] GameObject tankPrefab;

    public bool IsPlaceable { get { return isPlaceable; } }

    void OnMouseDown() {
        if (isPlaceable) {
            Instantiate(tankPrefab, transform.position, Quaternion.identity);
            isPlaceable = false;
        }
    }
}
