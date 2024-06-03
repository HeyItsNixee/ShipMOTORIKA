using UnityEngine;

public class Ship : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb2d;
    public Rigidbody2D Rigidbody => rb2d;
}
