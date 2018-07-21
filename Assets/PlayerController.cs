using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour {
    [SerializeField]
    private float speed = 5f;

    [SerializeField]
    private float lookSens = 3f;

    private PlayerMotor motor;

    private void Start()
    {
        motor = GetComponent<PlayerMotor>();
    }

    private void Update()
    {
        // Calculate velocity as a 3D Vector
        float _xMove = Input.GetAxisRaw("Horizontal");
        float _zMove = Input.GetAxisRaw("Vertical");

        Vector3 _moveHorizontal = transform.right * _xMove;
        Vector3 _moveVertical = transform.forward * _zMove;

        // Final movement Vector
        Vector3 _velocity = (_moveHorizontal + _moveVertical).normalized * speed;

        //Apply Movement
        motor.Move(_velocity);

        //Calculate Rotation as a 3D Vector (Turning Around)
        float _yRot = Input.GetAxisRaw("Mouse X");

        Vector3 _rotation = new Vector3(0f, _yRot, 0f) * lookSens;

        // Apply rotation
        motor.Rotate(_rotation);

        //Calculate camera Rotation as a 3D Vector (Turning Around)
        float _xRot = Input.GetAxisRaw("Mouse Y");

        Vector3 _cameraRotation = new Vector3(_xRot, 0f, 0f) * lookSens;

        // Apply camera rotation
        motor.RotateCamera(_cameraRotation);
    }
}
