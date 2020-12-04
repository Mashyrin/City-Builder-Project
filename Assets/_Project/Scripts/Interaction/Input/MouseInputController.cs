﻿using UnityEngine;
using UnityEngine.EventSystems;

namespace _Project.Scripts.Interaction.Input
{
    public class MouseInputController : AInputController
    {
        [SerializeField]
        private Camera _camera;

        [SerializeField]
        private LayerMask _groundMask;

        private void Update()
        {
            CheckClickDownEvent();
        }

        private void CheckClickDownEvent()
        {
            if (UnityEngine.Input.GetMouseButtonDown(0)
                && EventSystem.current.IsPointerOverGameObject() == false) // TODO
            {
                TryInvokeClickDown();
            }
        }

        protected override Vector3Int? RaycastGround()
        {
            var ray = _camera.ScreenPointToRay(UnityEngine.Input.mousePosition);

            if (Physics.Raycast(ray, out var hit, Mathf.Infinity, _groundMask))
            {
                return Vector3Int.RoundToInt(hit.point);
            }

            return null;
        }
    }
}