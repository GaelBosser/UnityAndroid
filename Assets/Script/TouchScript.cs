﻿using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TouchScript : MonoBehaviour
{
    private GameObject cube;
    private GameObject sphere;
    private GameObject cylindre;
    private Vector3 middlePosition;
    private Vector3 bigScale;
    private Vector3 minScale;
    private bool elementIsFocused;
    private bool allowedInteractionWithObjects;

    private void Start()
    {
        List<GameObject> gameObjects = GameObject.FindGameObjectsWithTag("RotateElement").ToList();
        cube = gameObjects.SingleOrDefault(g => g.name == "Cube");
        sphere = gameObjects.SingleOrDefault(g => g.name == "Sphere");
        cylindre = gameObjects.SingleOrDefault(g => g.name == "Cylinder");

        if (cube != null && sphere != null && cylindre != null)
        {
            allowedInteractionWithObjects = true;
        }

        middlePosition = new Vector3(497.88f, 1.97f, 41.11f);
        bigScale = new Vector3(1, 1, 1);
        minScale = new Vector3(0.25f, 0.25f, 0.25f);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit, 100))
            {
                if (allowedInteractionWithObjects)
                {
                    ManageHitCollider(hit);
                }
            }
        }
    }

    /// <summary>
    /// Gere les objets à afficher et à masquer en fonction de l'objet selectionne
    /// </summary>
    /// <param name="hit">Element touché par l'utilisateur</param>
    private void ManageHitCollider(RaycastHit hit)
    {
        if (hit.collider.gameObject.name == "Cube")
        {
            sphere.SetActive(false);
            cylindre.SetActive(false);

            cube.transform.localScale = bigScale;
            cube.transform.localPosition = middlePosition;

            if (!elementIsFocused)
            {
                elementIsFocused = true;
                cube.GetComponent<RotateScript>().CanRotate = false;
            }
        }
        else if (hit.collider.gameObject.name == "Sphere")
        {
            cube.SetActive(false);
            cylindre.SetActive(false);

            sphere.transform.localScale = new Vector3(1, 0.26f, 1);

            if (!elementIsFocused)
            {
                elementIsFocused = true;
                sphere.GetComponent<RotateScript>().CanRotate = false;
            }
        }
        else if (hit.collider.gameObject.name == "Cylinder")
        {
            sphere.SetActive(false);
            cube.SetActive(false);

            cylindre.transform.localScale = bigScale;
            cylindre.transform.localPosition = middlePosition;

            if (!elementIsFocused)
            {
                elementIsFocused = true;
                cylindre.GetComponent<RotateScript>().CanRotate = false;
            }
        }
        else
        {
            ResetAllRotateElements();
        }
    }

    /// <summary>
    /// Reset les positions et rotations de tous les objets ayant pour tag : RotateElements
    /// </summary>
    private void ResetAllRotateElements()
    {
        sphere.SetActive(true);
        sphere.transform.localScale = new Vector3(0.25f, 0.07f, 0.25f);
        sphere.GetComponent<RotateScript>().CanRotate = true;

        cube.SetActive(true);
        cube.transform.localScale = minScale;
        cube.transform.localPosition = new Vector3(496.83f, 1.97f, 41.11f);
        cube.GetComponent<RotateScript>().CanRotate = true;

        cylindre.SetActive(true);
        cylindre.transform.localScale = minScale;
        cylindre.transform.localPosition = new Vector3(498.93f, 1.97f, 41.11f);
        cylindre.GetComponent<RotateScript>().CanRotate = true;

        elementIsFocused = false;
    }
}