using UnityEditor;
using UnityEngine;
 
[ExecuteInEditMode]
// [RequireComponent(typeof(MeshFilter))]
public class GraphicsTest : MonoBehaviour {
 
    public Mesh mesh;
    public Material material;

    Vector3[] vertices;
    int[] triangles;

    public int xSize;
    public int zSize;

    void Start() {
        mesh = new Mesh();
        // GetComponent<MeshFilter>().mesh = mesh;

        CreateMesh();
        UpdateMesh();
    }    

    void Update() {
        Graphics.DrawMesh(mesh, Vector3.zero, Quaternion.identity, material, 0);
    }

    void CreateMesh() {
        vertices = new Vector3[(xSize + 1) * (zSize + 1)];

        for (int i = 0, z = 0; z <= zSize; ++z) {
            for (int x = 0; x <= xSize; ++x) {
                vertices[i] = new Vector3(x, 0, z);
                i++;
            }
        }       

        triangles = new int[xSize * zSize * 6];

        int vert = 0;
        int tris = 0;

        for (int z = 0; z < zSize; ++z) {
            for (int x = 0; x < xSize; ++x) {
                triangles[tris + 0] = vert + 0;
                triangles[tris + 1] = vert + xSize + 1;
                triangles[tris + 2] = vert + 1;
                triangles[tris + 3] = vert + 1;
                triangles[tris + 4] = vert + xSize + 1;
                triangles[tris + 5] = vert + xSize + 2;

                vert++;
                tris += 6;
            }
            vert++;
        }
    }

    void UpdateMesh() {
        mesh.Clear();

        mesh.vertices = vertices;
        mesh.triangles = triangles;

        mesh.RecalculateNormals();
    }


    private void OnDrawGizmos() {
        if (vertices == null) return;

        for (int i = 0; i < vertices.Length; ++i) {
            Gizmos.DrawSphere(vertices[i], .1f);
        }
    }
}