using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

namespace ShipMotorika
{
    /// <summary>
    /// Универсальная кнопка, меняющая свой вид и функционал в зависимости от игровой ситуации.
    /// </summary>
    public class ActionButton : Singleton<ActionButton>
    {
        public enum ActionType
        {
            None,
            FishingChallenge,
            CatchFish,
            Market
        }

        [SerializeField] private ActionType _type;

        [Header("Target components")]
        [SerializeField] private Button _button;
        [SerializeField] private Image _image;
        [SerializeField] private Text _text;

        [Header("Dependent components")]
        [SerializeField] private CaughtFishUI _caughtFishUI;
        [SerializeField] private MissedFishUI _missedFishUI;

        [Header("Action assets")]
        [SerializeField] private ActionButtonAsset _none;
        [SerializeField] private ActionButtonAsset _fishingChallenge;
        [SerializeField] private ActionButtonAsset _catchFish;
        [SerializeField] private ActionButtonAsset _market;

        #region UnityEvents
        private void Start()
        {
            SwitchAction(ActionType.None);

            _button.onClick.AddListener(DoAction);
            Player.Instance.FishingRod.OnFishingPlaceNearby += DoOnFishingPlaceNearby;
        }

        private void OnDestroy()
        {
            _button.onClick.RemoveListener(DoAction);         
            Player.Instance.FishingRod.OnFishingPlaceNearby -= DoOnFishingPlaceNearby;
        }
        #endregion

        private void Initialize(ActionButtonAsset asset)
        {
            _image.sprite = asset.Image;
            _image.color = asset.Color;
            _text.text = asset.Text;
            _image.raycastTarget = asset.RaycastTarget;
        }

        private void SwitchAction(ActionType type)
        {
            _type = type;
            
            switch (_type)
            {
                case ActionType.None:
                    Initialize(_none);
                    break;

                case ActionType.FishingChallenge:
                    Initialize(_fishingChallenge);
                    break;

                case ActionType.CatchFish:
                    Initialize(_catchFish);
                    break;

                case ActionType.Market:
                    Initialize(_market);
                    break;
            }
        }

        private void DoAction()
        {
            switch (_type)
            {
                case ActionType.None:

                    
                    break;


                case ActionType.FishingChallenge:

                    FishingChallenge.Instance.Activate();
                    SwitchAction(ActionType.CatchFish);

                    break;


                case ActionType.CatchFish:
                    
                    FishingChallenge.Instance.TryCatchFish();
                    SwitchAction(ActionType.None);

                    break;


                case ActionType.Market:
                    
                    break;
            }
        }

        private void DoOnFishingPlaceNearby(bool nearby)
        {
            if (nearby)
            {
                SwitchAction(ActionType.FishingChallenge);
            }
            else
            {
                SwitchAction(ActionType.None);
            }
        }

        private void DoOnMarketNearby(bool nearby)
        {
            if (nearby)
            {
                SwitchAction(ActionType.Market);
            }
            else
            {
                SwitchAction(ActionType.None);
            }
        }
    }
}