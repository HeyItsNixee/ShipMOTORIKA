using ShipMotorika;
using UnityEngine;

public class WaterFlow : MonoBehaviour
{
    [SerializeField] private BoxCollider2D trigger;
    [SerializeField] private ShipAsset assetToGoThrough;
    [SerializeField] private float force;

    private Player playerObj;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        playerObj = collision.transform.root.GetComponent<Player>();
        if (playerObj && playerObj.Ship.Asset != assetToGoThrough)
        {
            playerObj.Ship.Rigidbody.AddForce(-playerObj.Ship.transform.up * PlayerController.Instance.MaxThrust * force, ForceMode2D.Force);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (playerObj && playerObj.Ship.Asset != assetToGoThrough)
        {
            playerObj.Ship.Rigidbody.AddForce(-playerObj.Ship.transform.up * PlayerController.Instance.MaxThrust * force, ForceMode2D.Force);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (playerObj && playerObj.Ship.Asset != assetToGoThrough)
        {
            playerObj.Ship.Rigidbody.velocity = Vector2.zero;
        }
    }
}
