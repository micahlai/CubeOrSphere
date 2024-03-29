using System;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Ball
{
    public class Ball : MonoBehaviour
    {
        [SerializeField] private float m_MovePower = 5; // The force added to the ball to move it.
        [SerializeField] private bool m_UseTorque = true; // Whether or not to use torque to move the ball.
        [SerializeField] private float m_MaxAngularVelocity = 25; // The maximum velocity the ball can rotate at.
        [SerializeField] private float m_JumpPower = 2; // The force added to the ball when it jumps.
        [SerializeField] private float jumpPadPower = 20;

        private const float k_GroundRayLength = 1f; // The length of the ray to check if the ball is grounded.
        
        [Space]
        public float forceMultiplier = 100;
        public float multiplier;
        [HideInInspector]
        public Rigidbody m_Rigidbody;
        public bool isGrounded = false;


        private void Start()
        {
            m_Rigidbody = GetComponent<Rigidbody>();
            // Set the maximum angular velocity.
            GetComponent<Rigidbody>().maxAngularVelocity = m_MaxAngularVelocity;
        }
        private void Update()
        {
            isGrounded = Physics.Raycast(transform.position, -Vector3.up, k_GroundRayLength);
        }


        public void Move(Vector3 moveDirection, bool jump)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                multiplier = forceMultiplier;
                m_Rigidbody.mass = forceMultiplier * 0.75f;
            }
            else
            {

                multiplier = 1;
                m_Rigidbody.mass = 1;
            }
            
            // If using torque to rotate the ball...
            if (m_UseTorque)
            {
                // ... add torque around the axis defined by the move direction.
                m_Rigidbody.AddTorque(new Vector3(moveDirection.z, 0, -moveDirection.x)*m_MovePower * multiplier);
            }
            else
            {
                // Otherwise add force in the move direction.
                m_Rigidbody.AddForce(moveDirection*m_MovePower * multiplier);
            }

            // If on the ground and jump is pressed...
            if (isGrounded && jump)
            {
                // ... add force in upwards.
                m_Rigidbody.AddForce(Vector3.up*m_JumpPower, ForceMode.Impulse);
            }
            
        }
        private void OnCollisionEnter(Collision other)
        {
            if(other.gameObject.CompareTag("Jump Pad"))
            {
                m_Rigidbody.AddForce(Vector3.up * jumpPadPower, ForceMode.Impulse);
            }
        }
    }
}
