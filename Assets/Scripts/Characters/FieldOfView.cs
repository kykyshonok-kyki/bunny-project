//Made by kyki (neskajju@mail.ru) in August 2020
//Last update on 26 August 2020

using UnityEngine;

public class FieldOfView : MonoBehaviour
{
    public float fovDegrees;
    public float viewDist;

    private Mesh mesh;
    private int rayCount;
    private const float angleForRay = 0.2f;
    private LayerMask objectsLayer;
    private Vector3 origin;

    Vector3[] newVertices;
    Vector2[] newUV;
    int[] newTriangles;

    private void Start()
    {
        mesh = new Mesh();
        objectsLayer = LayerMask.GetMask("Objects");
    }

    private void LateUpdate()
    {
        RaycastHit2D hit;
        int trianglesCount;

        rayCount = (int) (fovDegrees / angleForRay + 1);

        newVertices = new Vector3[rayCount + 1];
        newUV = new Vector2[newVertices.Length];
        trianglesCount = (rayCount - 1) * 3;
        newTriangles = new int[trianglesCount];

        newVertices[0] = Vector3.zero;
        newUV[0] = Vector2.zero;

        origin = Quaternion.AngleAxis(fovDegrees / -2, Vector3.forward) * (transform.rotation * Vector3.right);
        for (int i = 1; i <= rayCount; i++)
        {
            if (hit = Physics2D.Raycast(transform.position, Quaternion.AngleAxis(i * angleForRay, Vector3.forward) * origin, viewDist, objectsLayer)) //Если столкнулся с объектом
            {
                newVertices[i] = Quaternion.Inverse(transform.rotation) * (hit.point - (Vector2) transform.position);
                newUV[i] = hit.point.normalized;
            }
            else
            {
                newVertices[i] = Quaternion.Inverse(transform.rotation) * Quaternion.Euler(0, 0, i * angleForRay) * origin * viewDist;
                newUV[i] = newVertices[i].normalized;
            }
        }
        for (int i = 0; i < rayCount - 1; i++)
        {
            newTriangles[i * 3] = 0;
            newTriangles[i * 3 + 1] = i + 1;
            newTriangles[i * 3 + 2] = i + 2;
        }
        mesh.vertices = newVertices;
        mesh.uv = newUV;
        mesh.triangles = newTriangles;

        gameObject.GetComponent<MeshFilter>().mesh = mesh;
    }
}
