using UnityEngine;
using System.Collections;
using System.Collections.Generic;
[ExecuteInEditMode]
public class MeshModifer : MonoBehaviour
{

    Mesh mesh;
    Vector3[] verts;
    Vector3 vertPos;
    GameObject[] handles;

    // public GameObject meshObject;
    public bool editInRealTime;
    public bool drawGizmos;

    Dictionary<Vector3, List<GameObject>> elementList = new Dictionary<Vector3, List<GameObject>>();

    void OnEnable()
    {
        mesh = GetComponent<MeshFilter>().sharedMesh; // llamamos al componente
        verts = mesh.vertices; // Guardo todos los vértices de la malla en una variable
        int index = 0;
        foreach (Vector3 vert in verts) // Leo todos los vectores  de la malla en orden
        {
            vertPos = transform.TransformPoint(vert); // asigno la posiscion a un vertice
            GameObject handle = new GameObject("vertex" + index); // Creamos un handle para cada vertice de la malla
            index++;
            handle.transform.position = vertPos; // Le asignamos la posicion dle vértice
            handle.transform.parent = transform; // Convierte los handles en hijos de la malla
            handle.tag = "handle"; // asignamos el tag de handles

        }
        //AgruparHandles();


    }

    public void OnDisable()
    {
        GameObject[] handles = GameObject.FindGameObjectsWithTag("handle");
        foreach (GameObject handle in handles)
        {
            DestroyImmediate(handle);
        }

        elementList.Clear();
    }


    void Update()
    {
        if (editInRealTime == true)
        {
            RecalculateMesh();
            GetComponent<MeshFilter>().sharedMesh.RecalculateBounds();

        }
    }

    void OnDrawGizmos()
    {
       if (drawGizmos == true)
        {
            Gizmos.color = Color.yellow;
            foreach (Vector3 vert in verts)
            {
                vertPos = transform.TransformPoint(vert);

              try {
                    Gizmos.DrawSphere(vertPos, 0.1f);
                }
               catch (System.NullReferenceException e)
              {
              }

           }
        }

    }

    public void RecalculateMesh()
    {
        handles = GameObject.FindGameObjectsWithTag("handle");
       // AgruparHandles();
        for (int i = 0; i < verts.Length; i++)
        {

            verts[i] = handles[i].transform.localPosition;
         
            
        }
       
        mesh.vertices = verts;


    }


  public void AgruparHandles()
   {
        GameObject[] handles = GameObject.FindGameObjectsWithTag("handle");

     foreach(GameObject handle in handles)
      {
            List<GameObject> existing;

            if (!elementList.TryGetValue(handle.transform.localPosition, out existing))
            {
                existing = new List<GameObject>();
                elementList[handle.transform.localPosition] = existing;
            }
            // At this point we know that "existing" refers to the relevant list in the 
            // dictionary, one way or another.
            existing.Add(handle);

            

        }

        foreach (GameObject handle in handles)
        {
            List<GameObject> existing;

            if (!elementList.TryGetValue(handle.transform.localPosition, out existing))
            {
                int index = 0;
                foreach(GameObject vertex in existing)
                {
                    
                    existing[index].transform.parent = existing[0].transform.parent;
                    index += 1;

                }


            
            }


        }
   }
}
