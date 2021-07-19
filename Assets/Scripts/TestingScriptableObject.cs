using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestingScriptableObject : MonoBehaviour
{
    [SerializeField] private TestScriptableObject testScriptableObject;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(testScriptableObject.myString);
    }

    // Update is called once per frame
    void Update()
    {
    }
}