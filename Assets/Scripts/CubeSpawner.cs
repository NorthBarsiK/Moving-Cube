using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    private GameObject TargetObj = null;
    void Start()
    {
        TargetObj = GameObject.FindGameObjectWithTag("Target");
        StartCoroutine(CubeSpawningDelay());
    }


    public float spawningDelayInSeconds = 2.0f;
    private IEnumerator CubeSpawningDelay()
    {
        yield return new WaitForSeconds(spawningDelayInSeconds);
        SpawnCube();
    }


    [SerializeField] private GameObject cubePrefab = null;
    public float cubeSpeed = 1.0f;
    public float cubeDistance = 10.0f;
    private void SpawnCube()
    {
        GameObject newCube = Instantiate(cubePrefab, Vector3.zero, Quaternion.Euler(Vector3.zero));
        newCube.GetComponent<Cube>().SetCubeParameters(cubeSpeed, cubeDistance);

        if (TargetObj != null)
        {
            TargetObj.transform.position = Vector3.right * cubeDistance;
        }

        StartCoroutine(CubeSpawningDelay());
    }
}
