using UnityEngine;

public class RotateScript : MonoBehaviour
{
    private Quaternion originalRotationValue;

    private bool _canRotate;
    public bool CanRotate
    {
        get => _canRotate;
        set
        {
            _canRotate = value;
            transform.rotation = Quaternion.Slerp(transform.rotation, originalRotationValue, Time.time * 1.0f);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        CanRotate = true;
        originalRotationValue = transform.rotation;
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
