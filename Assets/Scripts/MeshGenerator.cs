using UnityEngine;
[RequireComponent(typeof(MeshFilter))]
public class MeshGenerator : MonoBehaviour
{
    public Mesh mesh;

    Vector3[] vertices;
    int[] triangles;

    public int xsize = 20;
    public int zsize = 20;

    void Start()
    {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
        
        CreateShape();
        UpdateMesh();
    }

    void CreateShape()
    {
        vertices = new Vector3[(xsize + 1) * (zsize + 1)];

        for (int i = 0, z = 0; z <= zsize; z++)
        {
            for (int x = 0; x <= xsize; x++)
            {
                vertices[i] = new Vector3(x, 0, z);
                i++;
            }
        }

        triangles = new int[xsize * zsize * 6];

        int vert = 0;
        int tris = 0;

        for (int z = 0; z < zsize; z++)
        {
            for (int x = 0; x < xsize; x++)
            {
                triangles[tris + 0] = vert + 0;
                triangles[tris + 1] = vert + xsize + 1;
                triangles[tris + 2] = vert + 1;
                triangles[tris + 3] = vert + 1;
                triangles[tris + 4] = vert + xsize + 1;
                triangles[tris + 5] = vert + xsize + 2;

                vert++;
                tris += 6;
            }
            vert++;
        }


    }

    void UpdateMesh()
    {
        mesh.Clear();

        mesh.vertices = vertices;
        mesh.triangles = triangles;

        mesh.RecalculateNormals();
    }

    void OnDrawGizmos()
    {
        if (vertices == null)
        {
            return;
        }
        for (int i = 0; i < vertices.Length; i++)
        {
            Gizmos.DrawSphere(vertices[i], 0.1f);
        }
    }
}