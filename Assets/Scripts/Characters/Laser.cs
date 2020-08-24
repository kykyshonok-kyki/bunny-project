//Made by kyki (neskajju@mail.ru) in August 2020

using UnityEngine;

public class Laser : MonoBehaviour
{
    private LineRenderer lineRenderer;
    private LayerMask ignoreLayer;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        ignoreLayer = LayerMask.GetMask("LaserIgnore");
    }

    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right, 100, ~ignoreLayer);
        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, hit.point);
    }
}
