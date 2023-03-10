using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WavingObject : MonoBehaviour
{
    [SerializeField] private float amplitude = 0.3f;
    [SerializeField] private float frequency = 3f;

    Vector2 initPosition; //Starting position of our Portal's transform component

    private void Start()
    {
        initPosition = transform.position;//reference to Portal's transform component
    }

    private void Update()
    {
        //update Portal's position
        transform.position = new Vector2(initPosition.x, Mathf.Sin(Time.time * frequency) * amplitude + initPosition.y);
    }
}
