using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kalip_yerlestir : MonoBehaviour
{
    public GameObject[] kaliplar;
    public float kalipsayisi;

    public float uzaklik = 2f;

    private List<GameObject> instantiatedObjects = new List<GameObject>();
    public float movementSpeed = 2f;

    void Start()
    {
        for (int i = 0; i < kalipsayisi; i++)
        {
            int rastgelegetir = Random.Range(0, 5);
            GameObject instantiatedObject = Instantiate(kaliplar[rastgelegetir], new Vector3(transform.position.x, uzaklik, transform.position.z), Quaternion.Euler(90, 0, 0));

            // E�er objenin bir Collider'� yoksa, bir tane ekleyin
            Collider objCollider = instantiatedObject.GetComponent<Collider>();
            if (objCollider == null)
            {
                objCollider = instantiatedObject.AddComponent<BoxCollider>();
            }

            // Collider'� tetikleyici olarak ayarla
            objCollider.isTrigger = true;

            // E�er objenin bir Rigidbody'� yoksa, bir tane ekleyin
            Rigidbody objRigidbody = instantiatedObject.GetComponent<Rigidbody>();
            if (objRigidbody == null)
            {
                objRigidbody = instantiatedObject.AddComponent<Rigidbody>();
            }

            // Rigidbody'�n kinematik olmas�n� sa�layarak fizik etkile�imini devre d��� b�rak�n
            objRigidbody.isKinematic = true;

            instantiatedObjects.Add(instantiatedObject);
            uzaklik -= 2;
        }
    }

    void Update()
    {
        MoveObjectsUpward();
    }

    void MoveObjectsUpward()
    {
        foreach (GameObject obj in instantiatedObjects)
        {
            obj.transform.Translate(Vector3.back * Time.deltaTime * movementSpeed);
        }
    }
}