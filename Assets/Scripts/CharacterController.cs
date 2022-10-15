using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float gravityAmount;

    private float moveInputX;
    private float moveInputZ;
    private Vector3 movedirection;

    public float _speed = 10;
    public float _rotationSpeed = 180;
    public float dashSpeed;

    private Vector3 rotation;

    //  MOVE INPUTS FUNCTION (don't touch)
    private float GetInputX() => moveInputX = Input.GetAxis("Horizontal");
    private float GetInputZ() => moveInputZ = Input.GetAxis("Vertical");
    public Vector3 MoveInputs() => movedirection = new Vector3(GetInputX(), 0, GetInputZ());
    //
    
    // MOVEMENT FUNCTIONS
    public void CharactereRotation()
    {
        this.rotation = new Vector3(0, (Input.GetAxisRaw("Horizontal")) * _rotationSpeed * Time.deltaTime, 0);
        this.transform.Rotate(this.rotation);
    }

    public void Dash()
    {
        transform.Translate(Vector3.forward * dashSpeed * Time.deltaTime);
        print("dashed");
    }

    private void CharacterMovements() => transform.Translate(new Vector3(MoveInputs().x, gravityAmount, MoveInputs().z).normalized * speed * Time.deltaTime);

    private void Update()
    {
        CharacterMovements();
        CharactereRotation();
    }
}