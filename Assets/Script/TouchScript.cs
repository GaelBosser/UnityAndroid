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

    private void Start()
    {
        System.Collections.Generic.List<GameObject> gameObjects = GameObject.FindGameObjectsWithTag("RotateElement").ToList();
        cube = gameObjects.SingleOrDefault(g => g.name == "Cube");
        sphere = gameObjects.SingleOrDefault(g => g.name == "Sphere");
        cylindre = gameObjects.SingleOrDefault(g => g.name == "Cylinder");

        middlePosition = new Vector3(497.88f, 1.97f, 41.11f);
        bigScale = new Vector3(1, 1, 1);
        minScale = new Vector3(0.25f, 0.25f, 0.25f);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100))
            {
                // whatever tag you are looking for on your game object
                if (hit.collider.gameObject.name == "Cube")
                {
                    Debug.Log("Cube");
                    sphere.SetActive(false);
                    cylindre.SetActive(false);

                    cube.transform.localScale = bigScale;
                    cube.transform.localPosition = middlePosition;

                    cube.GetComponent<RotateScript>().CanRotate = false;
                }
                else if (hit.collider.gameObject.name == "Sphere")
                {
                    Debug.Log("Sphere");
                    cube.SetActive(false);
                    cylindre.SetActive(false);
                    sphere.transform.localScale = new Vector3(1, 0.26f, 1);
                    sphere.GetComponent<RotateScript>().CanRotate = false;
                }
                else if (hit.collider.gameObject.name == "Cylinder")
                {
                    Debug.Log("Cylinder");
                    sphere.SetActive(false);
                    cube.SetActive(false);
                    cylindre.transform.localScale = bigScale;
                    cylindre.transform.localPosition = middlePosition;
                    cylindre.GetComponent<RotateScript>().CanRotate = false;
                }
                else
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

                }
            }
        }
    }



}
