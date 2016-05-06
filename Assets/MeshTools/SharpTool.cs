using UnityEngine;
using System.Collections;
[ExecuteInEditMode]
public class SharpTool : MonoBehaviour {

    Mesh mesh;
    Vector3[] vertices;
    Vector2[] uv;
    int[] triangles;


    void OnEnable()
    {
        SharpEdgesFunction();
    }

    // Use this for initialization
    public void SharpEdgesFunction()
    {

        mesh = GetComponent<MeshFilter>().sharedMesh;
        vertices = mesh.vertices;
        uv = mesh.uv;
        triangles = mesh.triangles;

        Vector3[] newVertices = new Vector3[triangles.Length];
        Vector2[] newUV = new Vector2[triangles.Length];

        for (int i = 0; i < triangles.Length; i++)
        {
            newVertices[i] = vertices[triangles[i]];
            newUV[i] = uv[triangles[i]];
            triangles[i] = i;
        }

        mesh.vertices = newVertices;
        mesh.uv = newUV;
        mesh.triangles = triangles;
        mesh.RecalculateNormals();




    }

}
