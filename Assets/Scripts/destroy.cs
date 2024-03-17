using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroy : MonoBehaviour
{
    public GameObject cube;
    public Transform planeTransform;

    private Vector3[] possiblePositions;


    private void Start()
    {
        possiblePositions = new Vector3[]
        {
            new Vector3(-5,3.5f,0),
            new Vector3(-3,3.5f,0),
            new Vector3(-7,3.5f,0),
            new Vector3(-5,3.5f,2),
            new Vector3(-5,3.5f,-2)
        };
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            cube.SetActive(false); //Küp etkisiz hale gelir
            Invoke("ReactivateCube", Random.Range(4f,5f)); //4-5 sn arası küp tekrar etkin hale gelir
        }
    }

    private void ReactivateCube()
    {
        //Rastgele pozisyon seçimi
        //Vector3 newPosition = possiblePositions[Random.Range(0, possiblePositions.Length)];

        int randomIndex = Random.Range(0, possiblePositions.Length);
        //Küpün pozisyonu seçilen pozisyona ayarlama
        //cube.transform.position = newosition;

        cube.transform.position = possiblePositions[randomIndex];
        cube.SetActive(true); // küp tekrar etkin hale gelir
    }

}
