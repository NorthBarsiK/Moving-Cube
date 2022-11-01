using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    private float speed = 0;
    private float distance = 0.0f;
    public void SetCubeParameters(float cubeSpeed, float cubeDistance)
    {
        speed = cubeSpeed;
        distance = cubeDistance;
    }

    void Update()
    {
        Movement();

        if(transform.position.x >= distance)
        {
            Destroy(this.gameObject);
        }
    }

    private void Movement()
    {
        Vector3 velocity = Vector3.right * speed * Time.fixedDeltaTime;
        transform.Translate(velocity);
    }
}
