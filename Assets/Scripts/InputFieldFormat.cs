using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputFieldFormat : MonoBehaviour
{    
    private CubeSpawner spawner = null;
    private InputField inputFieldProperties = null;
    private void Start()
    {
        spawner = GameObject.FindGameObjectWithTag("Spawner").GetComponent<CubeSpawner>();
        inputFieldProperties = GetComponent<InputField>();
        GetDefaultValue();
    }

    private float Value = 0.0f;


    public enum ListOfCubeProperties
    {
        Speed = 0,
        Distance = 1,
        SpawningDelay = 2
    };

    public ListOfCubeProperties PropertyOfCube = ListOfCubeProperties.Speed;
    private void GetDefaultValue()
    {
        if (spawner != null)
        {
            switch (PropertyOfCube)
            {
                case ListOfCubeProperties.Speed:
                    Value = spawner.cubeSpeed;
                    break;
                case ListOfCubeProperties.Distance:
                    Value = spawner.cubeDistance;
                    break;
                case ListOfCubeProperties.SpawningDelay:
                    Value = spawner.spawningDelayInSeconds;
                    break;
            }
            inputFieldProperties.text = Value.ToString();
        }
    }

    [SerializeField] private float minValueLimit = 1.0f;
    [SerializeField] private float maxValueLimit = 100.0f;
    public void LimitValue(string newValue)
    {
        newValue = newValue.Replace(".", ",");

        Value = System.Convert.ToSingle(newValue);

        if (Value < minValueLimit)
        {
            Value = minValueLimit;
        }
        else if (Value > maxValueLimit)
        {
            Value = maxValueLimit;
        }

        inputFieldProperties.text = Value.ToString();
    }

    public void ApplyValue()
    {
        if (spawner != null)
        { 
            switch(PropertyOfCube)
            {
                case ListOfCubeProperties.Speed:
                    spawner.cubeSpeed = Value;
                    break;
                case ListOfCubeProperties.Distance:
                    spawner.cubeDistance = Value;
                    break;
                case ListOfCubeProperties.SpawningDelay:
                    spawner.spawningDelayInSeconds = Value;
                    break;
            }
        }
    }
}
