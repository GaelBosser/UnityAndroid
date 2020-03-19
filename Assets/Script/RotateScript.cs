using UnityEngine;

public class RotateScript : MonoBehaviour
{

    public bool CanRotate { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        CanRotate = true;   
    }

    // Update is called once per frame
    void Update()
    {
        if (CanRotate)
        {
            transform.Rotate(Vector3.forward * Time.deltaTime * 20);
        }
    }
}
