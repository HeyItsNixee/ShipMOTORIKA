using UnityEngine;

namespace ShipMotorika
{
    /// <summary>
    /// ����� ���������� �� ������/������ ����� ������.
    /// </summary>
    public class Wallet : MonoBehaviour
    {
        [SerializeField] private int _currentMoney;
        public int CurrentMoney => _currentMoney;
    }
}