using UnityEngine;

public class SwipeScript : MonoBehaviour
{
	private readonly float rotationSpeed = 2f;

    void OnMouseDrag()
	{
		float XaxisRotation = Input.GetAxis("Mouse X") * rotationSpeed;
		transform.Rotate(Vector3.left, XaxisRotation);
	}
}

