//Made by kyki (neskajju@mail.ru) in August 2020
//Last update on 26 August 2020

using UnityEngine;

public class FieldOfView : MonoBehaviour
{
    public float fovDegrees;
    public float viewDist;

    private Mesh mesh;
    private int rayCount;
    private const int angleForRay = 1;
    private LayerMask objectsLayer;
    private Vector3 origin;

    Vector3[] newVertices;
    Vector2[] newUV;
    int[] newTriangles;

    private void Start()
    {
        mesh = new Mesh();
        gameObject.GetComponent<MeshFilter>().mesh = mesh;
        objectsLayer = LayerMask.GetMask("Objects");
    }

    private void LateUpdate()
    {
        RaycastHit2D hit;

        rayCount = (int)fovDegrees / angleForRay + 1;

        newVertices = new Vector3[rayCount + 1];
        newUV = new Vector2[newVertices.Length];
        newTriangles = new int[(rayCount - 1) * 3];

        mesh.vertices = newVertices;
        mesh.uv = newUV;
        mesh.triangles = newTriangles;

        rayCount = (int)fovDegrees / angleForRay + 1;
        origin = Quaternion.AngleAxis(fovDegrees / -2, Vector3.forward) * (transform.rotation * Vector3.right);
        for (int i = 0; i < rayCount; i++)
        {
            if (hit = Physics2D.Raycast(transform.position, Quaternion.AngleAxis(i * angleForRay, Vector3.forward) * origin, viewDist, objectsLayer)) //Если столкнулся с объектом
            {
                newVertices[i] = hit.point;
                Debug.DrawLine(transform.position, hit.point);
            }
            else
            {
                newVertices[i] = transform.position + Quaternion.Euler(0, 0, i * angleForRay) * origin * viewDist;
                Debug.DrawLine(transform.position, transform.position + Quaternion.Euler(0, 0, i * angleForRay) * origin * viewDist);
            }
        }
    }
}
