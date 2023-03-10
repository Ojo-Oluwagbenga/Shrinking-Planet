using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float moveSpeed = 10f;
	public float rotationSpeed = 10f;

	public float rotation = 0f;
	public Rigidbody rb;
	public bool clickedActive = false;

	void Start (){
		rb = GetComponent<Rigidbody>();
	}


	void FixedUpdate ()
	{
		if (!clickedActive){
			rotation = Input.GetAxisRaw("Horizontal");
		}

		rb.MovePosition(rb.position + transform.forward * moveSpeed * Time.fixedDeltaTime);
		Vector3 yRotation = Vector3.up * rotation * rotationSpeed * Time.fixedDeltaTime;
		Quaternion deltaRotation = Quaternion.Euler(yRotation);
		Quaternion targetRotation = rb.rotation * deltaRotation;
		rb.MoveRotation(Quaternion.Slerp(rb.rotation, targetRotation, 50f * Time.deltaTime));

		//transform.Rotate(0f, rotation * rotationSpeed * Time.fixedDeltaTime, 0f, Space.Self);
	}

}
