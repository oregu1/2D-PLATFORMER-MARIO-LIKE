using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraController : MonoBehaviour
{   
    [SerializeField] private CinemachineVirtualCamera VirtualCamera;
    public GameObject targetToFollow;
    private void Awake()
    {
        VirtualCamera = GetComponent<CinemachineVirtualCamera>();
        
    }
    void Update()
    {
        targetToFollow = GameObject.FindWithTag("Player");
        VirtualCamera.Follow = targetToFollow.transform;
    }
}
