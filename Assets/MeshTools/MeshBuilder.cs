using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[ExecuteInEditMode]
public class MeshBuilder : MonoBehaviour
{

    private List<Vector3> m_Vertices = new List<Vector3>(); // Creamos una lista de elementos del tipo Vector3
    public List<Vector3> Vertices // Vertices de la malla
    {
        get
        {
            return m_Vertices; // Definimos la propiedad para la llamada
        }
    }

    private List<Vector3> m_Normals = new List<Vector3>();
    public List<Vector3> Normals 
    {
        get
        {
            return m_Normals;
        }
    }

    private List<Vector2> m_UVs = new List<Vector2>(); // Creamos una lista de elementos del tipo Vector 2
    public List<Vector2> UVs // Cordenadas 2D de la textura entre (0,1) para evitar el tiling
    {
        get
        {
            return m_UVs;
        }
    }

    private List<int> m_Indices = new List<int>(); // Indices de los triángulos

    public void AddTriangle(int index0, int index1, int index2) // Método para añadir los indices de los triéngulos a la lista de indices
    {
        m_Indices.Add(index0); // añadimos los índices a la lista de enteros 
        m_Indices.Add(index1);
        m_Indices.Add(index2);
    }

    public Mesh CreateMesh() // Metodo para crear la malla
    {
        Mesh mesh = new Mesh(); // Creamos un objeto de tipo Mesh, usamos un contructor -> new Mesh();

        mesh.vertices = m_Vertices.ToArray(); // Copia los elementos de la lista de vértices a los vértices de la malla
        mesh.triangles = m_Indices.ToArray(); // copia los índices de la lista de indice de los triangulos a los triángulos 
        if (m_Normals.Count == m_Vertices.Count) mesh.normals = m_Normals.ToArray(); // Si coinciden las normales 
        if (m_UVs.Count == m_Vertices.Count) mesh.uv = m_UVs.ToArray();  // Si coinciden las normales

        mesh.RecalculateBounds(); // Recalcula el tamaño de la malla a partir de la disposición de los vértices

        return mesh; // Devuelve la malla creada

    }

   

   
}
