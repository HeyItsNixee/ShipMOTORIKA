using UnityEngine;

namespace ShipMotorika
{
    public enum InputType
    {
        Idle,
        Forward,
        ForwardLeft,
        ForwardRight,
        Backwards,
        BackwardsLeft,
        BackwardsRight,
        Left,
        Right,
    }

    public class PlayerController : Singleton<PlayerController>
    {
        [Header("Settings")]
        [SerializeField] private float maxThrust;
        [SerializeField] private float maxLinearVelocity;
        [SerializeField] private float maxTorque;
        [SerializeField] private float maxAngularVelocity;
        [SerializeField] private Ship playerShip;
        [Header("Links")]
        [SerializeField] private GameObject leftScreenButton;
        [SerializeField] private GameObject rightScreenButton;

        private InputType currentInput;
        public InputType CurrentInput => currentInput;

        private bool sideButtonControlEnabled = true;
        public bool SideButtonControlEnabled => sideButtonControlEnabled;

        private float m_Thrust = 0f;
        private float m_Torque = 0f;

        private bool canControl = true;
        private bool holdingLeft;
        private bool holdingRight;

        private void Update()
        {
            if (!canControl)
                return;

            var movement = UI_ForwardInputController.Instance.Value;
            m_Thrust = movement.y;

            if (m_Thrust > 0f)
                currentInput = InputType.Forward;
            if (m_Thrust < 0f)
                currentInput = InputType.Backwards;
            if (m_Thrust == 0f)
                currentInput = InputType.Idle;


            if (sideButtonControlEnabled)
            {
                if (holdingLeft)
                    HandleLeftButton();

                if (holdingRight)
                    HandleRightButton();

                if ((holdingLeft && holdingRight) || (!holdingLeft && !holdingRight))
                    m_Torque = 0f;
            }
            else
            {
                //Left Button
                if (Input.GetKey(KeyCode.D))
                    HandleRightButton();

                //RightButton
                if (Input.GetKey(KeyCode.A))
                    HandleLeftButton();

                //Both Left and Right
                if (!Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A))
                    m_Torque = 0f;
            }

            //Debug.Log("Thrust = " + m_Thrust + "; Torque = " + m_Torque);
        }

        private void FixedUpdate()
        {
            Move();
            Turn();
        }

        private void HandleLeftButton()
        {
            if (Mathf.Sign(m_Thrust) == Mathf.Sign(-1f))
                m_Torque = -1f;
            else
                m_Torque = 1f;

            switch (currentInput)
            {
                case InputType.Idle:
                    currentInput = InputType.Left;
                    break;

                case InputType.Forward:
                    currentInput = InputType.ForwardLeft;
                    break;

                case InputType.Backwards:
                    currentInput = InputType.BackwardsLeft;
                    break;
            }
        }

        private void HandleRightButton()
        {
            if (Mathf.Sign(m_Thrust) == Mathf.Sign(-1f))
                m_Torque = 1f;
            else
                m_Torque = -1f;

            switch (currentInput)
            {
                case InputType.Idle:
                    currentInput = InputType.Right;
                    break;

                case InputType.Forward:
                    currentInput = InputType.ForwardRight;
                    break;

                case InputType.Backwards:
                    currentInput = InputType.BackwardsRight;
                    break;
            }
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

        public void SetMaxLinearVelocity(float value)
        {
            maxLinearVelocity = value;
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

        public void EnableControl()
        {
            canControl = true;
            UI_ForwardInputController.Instance.gameObject.SetActive(true);

            if (sideButtonControlEnabled)
            {
                leftScreenButton.SetActive(true);
                rightScreenButton.SetActive(true);
            }
            else
            {
                leftScreenButton.SetActive(false);
                rightScreenButton.SetActive(false);
            }
        }

        public void DisableControl()
        {
            canControl = false;
            UI_ForwardInputController.Instance.gameObject.SetActive(false);
            leftScreenButton.SetActive(false);
            rightScreenButton.SetActive(false);
            Stop();
        }

        public void Stop()
        {
            //playerShip.Rigidbody.velocity = Vector3.zero;
            m_Thrust = 0f;
            m_Torque = 0f;
            UI_ForwardInputController.Instance.ResetStick();
        }

        public void SideButtonControlEnable(bool value)
        {
            sideButtonControlEnabled = value;
            if (sideButtonControlEnabled)
            {
                leftScreenButton.SetActive(true);
                rightScreenButton.SetActive(true);
            }
            else
            {
                leftScreenButton.SetActive(false);
                rightScreenButton.SetActive(false);
            }
        }

        public void TurnLeft()
        {
            holdingLeft = true;
            Debug.Log("velocity " + playerShip.Rigidbody.velocity);
            Debug.Log("m_Torque " + m_Torque);
            Debug.Log("CurrentInput " + currentInput);
        }

        public void TurnRight()
        {
            holdingRight = true;   
        }

        public void StopTurningLeft()
        {
            holdingLeft = false;
        }

        public void StopTurningRight()
        {
            holdingRight = false;
        }
    }
}