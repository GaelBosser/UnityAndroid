using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class TouchScript : MonoBehaviour
{
    private Button btnReset;
    private GameObject buttonReset;

    private Vector3 middlePosition;
    private Vector3 bigScale;
    private Vector3 bigScaleSphere;

    private bool allowedInteractionWithObjects;

    private readonly List<(GameObject gameObject, Vector3 scaleGameObject, Vector3 positionGameObject)> originalElements = new List<(GameObject, Vector3, Vector3)>();
    private List<GameObject> rotateElements;

    private bool elementIsFocused;
    public bool ElementIsFocused
    {
        get => elementIsFocused;
        set
        {
            elementIsFocused = value;
            buttonReset.SetActive(value);
        }
    }

    private void Start()
    {
        rotateElements = GameObject.FindGameObjectsWithTag("RotateElement").ToList();

        rotateElements.ForEach(element => originalElements.Add((element, element.transform.localScale, element.transform.localPosition)));

        btnReset = GameObject.Find("BtnReset").GetComponent<Button>();
        buttonReset = GameObject.Find("BtnReset");

        if (btnReset != null && buttonReset != null)
        {
            allowedInteractionWithObjects = true;
            btnReset.onClick.AddListener(ResetAllRotateElements);
            buttonReset.SetActive(false);
        }

        middlePosition = new Vector3(497.88f, 1.97f, 41.11f);
        bigScale = new Vector3(1, 1, 1);
        bigScaleSphere = new Vector3(1, 0.26f, 1);
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
        if(rotateElements.Any() && !ElementIsFocused)
        {
            bool isPresentInRotateElement = rotateElements.SingleOrDefault(element => element.Equals(hit.collider.gameObject));

            if (isPresentInRotateElement)
            {
                IEnumerable<GameObject> otherRotateElements = rotateElements.Where(element => !element.Equals(hit.collider.gameObject));

                foreach(GameObject rotateElement in otherRotateElements)
                {
                    rotateElement.SetActive(false);
                }

                hit.collider.gameObject.transform.localScale = hit.collider.gameObject.name.Equals("Sphere") ? bigScaleSphere : bigScale;
                hit.collider.gameObject.transform.localPosition = middlePosition;

                ElementIsFocused = true;
                hit.collider.gameObject.GetComponent<RotateScript>().CanRotate = false;
            }
        }
    }

    /// <summary>
    /// Reset les positions et rotations de tous les objets ayant pour tag : RotateElements
    /// </summary>
    private void ResetAllRotateElements()
    {
        foreach (GameObject rotateElement in rotateElements)
        {
            if (rotateElement.activeSelf)
            {
                (GameObject gameObject, Vector3 scaleGameObject, Vector3 positionGameObject) originalElement = originalElements.SingleOrDefault(element => element.gameObject.Equals(rotateElement));

                rotateElement.transform.localScale = originalElement.scaleGameObject;
                rotateElement.transform.localPosition = originalElement.positionGameObject;
            }
            else
            {
                rotateElement.SetActive(true);
            }

            rotateElement.GetComponent<RotateScript>().CanRotate = true;
        }

        ElementIsFocused = false;
    }
}