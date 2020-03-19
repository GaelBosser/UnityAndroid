using UnityEngine;

public class SwipeScript : MonoBehaviour
{
	private readonly float rotationSpeed = 2f;

    void OnMouseDrag()
	{
		float YaxisRotation = Input.GetAxis("Mouse Y") * rotationSpeed;
		transform.Rotate(Vector3.right, YaxisRotation);
	}
}

