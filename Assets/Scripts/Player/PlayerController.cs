using UnityEngine;

public class PlayerController : Singleton<PlayerController>
{
    [Header("Settings")]
    [SerializeField] private float maxThrust;
    [SerializeField] private float maxLinearVelocity;
    [SerializeField] private float maxTorque;
    [SerializeField] private float maxAngularVelocity;
    [SerializeField] private Ship playerShip;

    private float m_Thrust = 0f;
    private float m_Torque = 0f;

    private bool movingBackwards = false;

    private void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            m_Thrust = 1f;
            movingBackwards = false;
        }

        if (Input.GetKey(KeyCode.S))
        {
            m_Thrust = -1f;
            movingBackwards = true;
        }


        if (!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S))
        {
            m_Thrust = 0f;
            movingBackwards = false;
        }

        if (Input.GetKey(KeyCode.D))
        {
            if (!movingBackwards)
                m_Torque = -1f;
            else
                m_Torque = 1f;
        }
        if (Input.GetKey(KeyCode.A))
        {
            if (!movingBackwards)
                m_Torque = 1f;
            else
                m_Torque = -1f;
        }
        if (!Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A))
            m_Torque = 0f;

        //Debug.Log("Thrust = " + m_Thrust + "; Torque = " + m_Torque);
    }

    private void FixedUpdate()
    {
        Move();
        Turn();
    }

    private void Move()
    {
        if (m_Thrust != 0f)
            playerShip.Rigidbody.AddForce(playerShip.transform.up * m_Thrust * maxThrust * Time.fixedDeltaTime, ForceMode2D.Force);
        else
            playerShip.Rigidbody.AddForce(-playerShip.Rigidbody.velocity * maxThrust / 2f * Time.fixedDeltaTime, ForceMode2D.Force);


        if (playerShip.Rigidbody.velocity.magnitude >= maxLinearVelocity)
            playerShip.Rigidbody.velocity = Vector2.ClampMagnitude(playerShip.Rigidbody.velocity, maxLinearVelocity);
    }
    private void Turn()
    {
        if (m_Torque != 0f)
        {
            playerShip.Rigidbody.AddForce(playerShip.transform.up * maxThrust / 2f * Time.fixedDeltaTime, ForceMode2D.Force);
            playerShip.Rigidbody.AddTorque(m_Torque * maxTorque * Time.fixedDeltaTime, ForceMode2D.Force);
        }
        else
            playerShip.Rigidbody.AddTorque(-playerShip.Rigidbody.angularVelocity * maxTorque / 2f * Time.fixedDeltaTime, ForceMode2D.Force);

        if (Mathf.Abs(playerShip.Rigidbody.angularVelocity) >= maxAngularVelocity)
            playerShip.Rigidbody.angularVelocity = maxAngularVelocity * Mathf.Sign(playerShip.Rigidbody.angularVelocity);
    }

    public void ProhibitMovement()
    {
        playerShip.Rigidbody.velocity = Vector2.zero;
        playerShip.Rigidbody.freezeRotation = true;
        playerShip.Rigidbody.constraints = RigidbodyConstraints2D.FreezeAll;
    }

    public void AllowMovement()
    {
        playerShip.Rigidbody.freezeRotation = false;
        playerShip.Rigidbody.constraints = RigidbodyConstraints2D.None;
    }
}