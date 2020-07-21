﻿using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class squareSwitch : MonoBehaviour
{
    
    public bool issphere;
    public GameObject player;

    [Space]
    public GameObject cube;
    public CharacterController cubeRigid;
    [Space]
    public GameObject sphere;
    public Rigidbody sphereRigid;
    public CinemachineFreeLook cam;
    [Space]
    
    public Transform trail;
    public Transform pickup;

    [HideInInspector]
    public bool canSwitch = true;

    
    // Start is called before the first frame update
    void Start()
    {
        cube.SetActive(true);
        cube.transform.position = sphere.transform.position;
        cam.Follow = cube.transform;
        cam.LookAt = cube.transform;
        sphere.SetActive(false);
        issphere = false;

       
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1) && canSwitch)
        {
            
            if (!issphere)
            {
                sphere.SetActive(true);
                sphere.transform.position = cube.transform.position;
                sphereRigid.velocity = new Vector3(cubeRigid.velocity.x, cubeRigid.velocity.y, cubeRigid.velocity.z);
                cam.Follow = sphere.transform;
                cam.LookAt = sphere.transform;
                cube.SetActive(false);
                issphere = true;
            }
            else
            {
                cube.SetActive(true);
                cube.transform.position = sphere.transform.position;
                cam.Follow = cube.transform;
                cam.LookAt = cube.transform;
                sphere.SetActive(false);
                issphere = false;
            }
        }
        if (issphere)
        {
            sphere.SetActive(true);
            cube.SetActive(false);
            cube.transform.position = sphere.transform.position;
            trail.position = sphere.transform.position;
        }
        else
        {
            cube.SetActive(true);
            sphere.SetActive(false);
            sphereRigid.velocity = new Vector3(cubeRigid.velocity.x, cubeRigid.velocity.y, cubeRigid.velocity.z);
            trail.position = cube.transform.position;
        }
        
        
    }
    
}
