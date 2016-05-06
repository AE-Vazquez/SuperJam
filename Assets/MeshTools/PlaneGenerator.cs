using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer), typeof(MeshCollider))] // Definimos los atributos de esta Clase
[ExecuteInEditMode]
public class PlaneGenerator : MonoBehaviour 
{

    public enum PlaneType { RandomHeight, HeightMap, PerlinNoise };
    public PlaneType ActiveState = PlaneType.RandomHeight;

    public float m_Length = 1.0f; // Longitud del plano básico
    public float m_Width = 1.0f; // Ancho del plano basico
    public float m_Height = 1.0f; // altura de la malla
    public static GameObject mygame;

    public Texture2D m_HeightMap;

    MeshBuilder meshBuilder = new MeshBuilder(); // Creamos un objeto del tipo MeshBuilder
    
    public int m_SegmentCount; // Numero de segmentos 

    public float PlaneLength; // Con esto calcularemos luego la longitud del plano
    public float PlaneWidth; // Con esto calcularemos luego la anchura del plano

    float y;
    

    
    Vector3[] vertices = new Vector3[4]; // Creamos cuatro vectores, los necesarios para crear un plano


    void BuildQuadForGrid(MeshBuilder meshBuilder, Vector3 position, Vector2 uv, bool buildTriangles, int vertsPerRow) // Método para formar los planos con dos triángulos
    {
        meshBuilder.Vertices.Add(position); // Añadimos a la lista de vértices el vector posicion, el cual es el offset declarado anteriormente
        meshBuilder.UVs.Add(uv); // Añadimos las coordenadas UV

        if (buildTriangles) // Creamos el triángulo si es posible
        {
            int baseIndex = meshBuilder.Vertices.Count - 1; // Obtenemos la base inicial

            int index0 = baseIndex; // Definimos el primer vértice del triángulo
            int index1 = baseIndex - 1; // Vertice de al lado
            int index2 = baseIndex - vertsPerRow; // vertice superior derecha
            int index3 = baseIndex - vertsPerRow - 1; // Vertice superior izquierda

            meshBuilder.AddTriangle(index0, index2, index1); // Creamos los triángulos 1
            meshBuilder.AddTriangle(index2, index3, index1); // 2
        }

    }


   

    public void GeneratePLane(MeshBuilder meshBuilder, float m_Length, float m_Width, int m_SegmentCount, float m_Height) // Con esta funcion generaremos el plano
    {


        for (int i = 0; i < m_SegmentCount; i++) // Repite el proceso para cada proceso, Avanza en Z
        {
            float z = m_Length * i; // Avanzamos de plano en plano en la dirección Z
            float v = (1.0f / m_SegmentCount) * i; // Cordenada V siempre menor de 1

            for (int j = 0; j < m_SegmentCount; j++)
            {
                float x = m_Width * j; // Avanzamos en el plano en la dirección X 
                float u = (1.0f / m_SegmentCount) * j; // Coordenada U

                Vector3 offset = new Vector3(x, GetY(x,z) * m_Height, z); // Definimos el offset del elemento de la malla que estamos creando, junto con la altura 
                
                Vector2 uv = new Vector2(u, v); // Creamos el vector Uv del elemento creado
                bool buildTriangles = i > 0 && j > 0;

                BuildQuadForGrid(meshBuilder, offset, uv, buildTriangles, m_SegmentCount); // Creamos el elemento
            }
        }

        GetComponent<MeshFilter>().mesh = meshBuilder.CreateMesh();// Con los planos generados creamos una malla
        
       // GetComponent<MeshCollider>().sharedMesh = GetComponent<MeshFilter>().mesh;
        //GetComponent<MeshFilter>().mesh.RecalculateNormals();
    }

  
    float RandomHeight(float x, float z)
    {

        y = Random.Range(0, 3);

        return y;
    }

    float HeightMap(float x,float z)
    {
        if (m_HeightMap != null)
        {
            
            Color mapColour = m_HeightMap.GetPixelBilinear(x / m_SegmentCount, z / m_SegmentCount);
            return mapColour.grayscale * m_Height;

        }


        return 0.0f;
    }


    float GetY(float x, float z)
    {

        switch (ActiveState)
        {
            case PlaneType.RandomHeight:
                {

                    y = RandomHeight(x, z);
                    return y;
                }
                   


            case PlaneType.HeightMap:
                {
                    y = HeightMap(x, z);
                   

                    return y;

                }
            case PlaneType.PerlinNoise:
                {

                    
                    y = Mathf.PerlinNoise(x/m_SegmentCount, z/m_SegmentCount);
                 
                    return y;
                }     


            default:

                return 0;




        }









    }

    
}
