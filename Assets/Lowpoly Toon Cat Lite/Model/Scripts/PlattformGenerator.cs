using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlattformGenerator : MonoBehaviour
{
    public GameObject objectPrefab; // Prefab des zu generierenden Gameobjects
    public Transform generationPoint; // Punkt, an dem das neue Gameobject generiert werden soll

    public float generationDistance; // Abstand zwischen den generierten Gameobjects

    private float platformWidth; // Breite des generierten Gameobjects

    private void Start()
    {
        platformWidth = objectPrefab.GetComponent<Renderer>().bounds.size.x; // Breite des generierten Gameobjects ermitteln
    }

    private void Update()
    {
        if (transform.position.x < generationPoint.position.x) // Überprüfen, ob der Generatorpunkt erreicht wurde
        {
            GenerateObject(); // Gameobject generieren
        }
    }

    private void GenerateObject()
    {
        Vector3 newPosition = transform.position;
        newPosition.x += platformWidth + generationDistance; // Neue Position des generierten Gameobjects berechnen

        Instantiate(objectPrefab, newPosition, Quaternion.identity); // Gameobject instanziieren

        transform.position = newPosition; // Generatorposition aktualisieren
    }
}
