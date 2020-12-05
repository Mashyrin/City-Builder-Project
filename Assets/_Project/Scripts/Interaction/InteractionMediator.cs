﻿using UnityEngine;

using _Project.Scripts.City;
using _Project.Scripts.Interaction.UI;
using _Project.Scripts.Interaction.Input;

namespace _Project.Scripts.Interaction
{
    public class InteractionMediator : MonoBehaviour
    {
        [Header("Input")]
        [SerializeField]
        private AInputController _inputController;

        [SerializeField]
        private UiController _uiController;

        [Header("Listeners")]
        [SerializeField]
        private CityFacade _cityFacade;

        [SerializeField]
        private CameraMover _cameraMover;

        private void OnEnable()
        {
            _uiController.SubscribeBuildCalling(OnBuildingStarted);

            _inputController.SubscribeMoveUp(_cameraMover.OnMoveUp);
            _inputController.SubscribeMoveDown(_cameraMover.OnMoveDown);
            _inputController.SubscribeMoveRight(_cameraMover.OnMoveRight);
            _inputController.SubscribeMoveLeft(_cameraMover.OnMoveLeft);

            _inputController.SubscribeZoomIn(_cameraMover.OnZoomIn);
            _inputController.SubscribeZoomOut(_cameraMover.OnZoomOut);
        }

        private void OnDisable()
        {
            _uiController.UnsubscribeBuildCalling(OnBuildingStarted);

            _inputController.UnsubscribeMoveUp(_cameraMover.OnMoveUp);
            _inputController.UnsubscribeMoveDown(_cameraMover.OnMoveDown);
            _inputController.UnsubscribeMoveRight(_cameraMover.OnMoveRight);
            _inputController.UnsubscribeMoveLeft(_cameraMover.OnMoveLeft);

            _inputController.SubscribeZoomIn(_cameraMover.OnZoomIn);
            _inputController.SubscribeZoomOut(_cameraMover.OnZoomOut);
        }

        private void OnBuildingStarted()
        {
            _inputController.SubscribeClickDown(_cityFacade.OnPlaceBuilding);
            _inputController.SubscribeCancelClick(OnBuildingStopped);
        }

        private void OnBuildingStopped() // TODO : Complete
        {
            _inputController.UnsubscribeClickDown(_cityFacade.OnPlaceBuilding);
            _inputController.UnsubscribeCancelClick(OnBuildingStopped);
        }
    }
}