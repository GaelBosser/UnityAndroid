using UnityEngine;

public class SwipeScript : MonoBehaviour
{
	private readonly float rotationSpeed = 10f;
	private Quaternion originalRotationValueCube;

    void Start()
    {
		originalRotationValueCube = transform.rotation;
	}

    void OnMouseDrag()
	{
		float YaxisRotation = Input.GetAxis("Mouse Y") * rotationSpeed;
		transform.Rotate(Vector3.right, YaxisRotation);
	}

    public void ResetPositionGameObject(GameObject gameObject)
    {
		gameObject.transform.rotation = Quaternion.Slerp(gameObject.transform.rotation, originalRotationValueCube, Time.time * 1.0f);
	}
}

