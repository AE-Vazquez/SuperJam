using UnityEngine;
using System.Collections;
using UnityEditor;


[ExecuteInEditMode] // Con esto podemos editar el objeto sin tener que ejecutar el juego
[CustomEditor(typeof(PlaneGenerator))] // Con este atributo definimos el script como un custom editor
public class PlaneProceduralTool : Editor { // Importante EDITOR NO MONODEVELOP

    public Texture2D m_HeightMap;

    // Use this for initialization
    public override void OnInspectorGUI () { // Con esta función actualizamos el inspector

       // DrawDefaultInspector();

        PlaneGenerator myPlaneScriptd = (PlaneGenerator)target; // Creamos un objeto plano
        if (myPlaneScriptd.ActiveState == PlaneGenerator.PlaneType.RandomHeight)
        {
            myPlaneScriptd.m_Height = EditorGUILayout.FloatField("Quad Height", myPlaneScriptd.m_Height); // Definimos la altura media
        }
        else if (myPlaneScriptd.ActiveState == PlaneGenerator.PlaneType.HeightMap)
        {
            myPlaneScriptd.m_Height = EditorGUILayout.FloatField("Height scale", myPlaneScriptd.m_Height); // Definimos la altura media
        }
        else
        {
            myPlaneScriptd.m_Height = EditorGUILayout.FloatField("Noise", myPlaneScriptd.m_Height); // Definimos la altura media
        }
        myPlaneScriptd.m_Length = EditorGUILayout.FloatField("Quad Length", myPlaneScriptd.m_Length); // Definimos la longitud del Quad Basico
        myPlaneScriptd.m_Width = EditorGUILayout.FloatField("Quad Width", myPlaneScriptd.m_Width); // Definimos la anchura del Quad básico
        myPlaneScriptd.m_SegmentCount = EditorGUILayout.IntField("SegmentCount", myPlaneScriptd.m_SegmentCount); // Definimos el número de Segmentos
        myPlaneScriptd.PlaneLength = myPlaneScriptd.m_Length * myPlaneScriptd.m_SegmentCount; // Calculamos la Longitud del plano
        myPlaneScriptd.PlaneWidth = myPlaneScriptd.m_Width * myPlaneScriptd.m_SegmentCount; // Calculamos la anchura del plano
        EditorGUILayout.LabelField("Plane Length",myPlaneScriptd.PlaneLength.ToString()); // Escribimos la longitud
        EditorGUILayout.LabelField("Plane Width", myPlaneScriptd.PlaneWidth.ToString()); // Escribimos la anchura
        myPlaneScriptd.ActiveState = (PlaneGenerator.PlaneType) EditorGUILayout.EnumPopup("Algorithm", myPlaneScriptd.ActiveState);

        if (GUILayout.Button("Create Plane"))
        {
          
            MeshBuilder meshBuilder = new MeshBuilder(); // Cada vez que generamos el plano debemos crear una malla nueva, si no creamos y se van solapando
            myPlaneScriptd.GeneratePLane(meshBuilder,myPlaneScriptd.m_Length, myPlaneScriptd.m_Width, myPlaneScriptd.m_SegmentCount, myPlaneScriptd.m_Height); // Generamos el plano
           
            myPlaneScriptd.GetComponent<MeshCollider>().sharedMesh = myPlaneScriptd.GetComponent<MeshFilter>().sharedMesh;

           // myPlaneScriptd.GetComponent<MeshFilter>().sharedMesh.RecalculateNormals();
        }

        if (GUILayout.Button("Rebuild plane"))
        {
           
            myPlaneScriptd.GetComponent<MeshModifer>().RecalculateMesh();
            myPlaneScriptd.GetComponent<MeshFilter>().sharedMesh.RecalculateBounds();
            //myPlaneScriptd.GetComponent<MeshFilter>().sharedMesh.RecalculateNormals();
            myPlaneScriptd.GetComponent<MeshCollider>().sharedMesh = myPlaneScriptd.GetComponent<MeshFilter>().sharedMesh;
        }

        if (GUILayout.Button("SharpEdges"))
        {
            myPlaneScriptd.GetComponent<SharpEdges>().SharpEdgesFunction();

        }
        if (myPlaneScriptd.ActiveState == PlaneGenerator.PlaneType.HeightMap)
        {
          myPlaneScriptd.m_HeightMap = (Texture2D)EditorGUILayout.ObjectField(myPlaneScriptd.m_HeightMap, typeof(Texture2D), true);
          EditorGUILayout.ObjectField("HeightMap", myPlaneScriptd.m_HeightMap, typeof(Texture2D), false);
        }


    }
	
	
}
