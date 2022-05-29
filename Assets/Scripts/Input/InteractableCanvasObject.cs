using UnityEngine;
using UnityEngine.EventSystems;

namespace Scripts.Input
{
    /// <summary>
    /// Used for Implementing Canvas based controls
    /// </summary>
    public class InteractableCanvasObject : GameplayInput, IBeginDragHandler, IEndDragHandler, IDragHandler,
        IPointerDownHandler, IPointerUpHandler
    {
        public delegate void OnBeginDragDelegate(Vector3 position);

        public event OnBeginDragDelegate OnBeginDragEvent;

        public delegate void OnMouseDragDelegate(Vector3 position);

        public event OnMouseDragDelegate OnMouseDragEvent;

        public delegate void OnEndDragDelegate(Vector3 position);

        public event OnEndDragDelegate OnEndDragEvent;

        public delegate void OnPointerDownDelegate(Vector3 position);

        public event OnPointerDownDelegate OnPointerDownEvent;

        public delegate void OnPointerUpDelegate(Vector3 position);

        public event OnPointerUpDelegate OnPointerUpEvent;

        private bool _isGameplayInputOn = true;


        public void OnBeginDrag(PointerEventData eventData)
        {
            if (!_isGameplayInputOn) return;

            OnBeginDragEvent?.Invoke(eventData.pointerCurrentRaycast.worldPosition);
        }

        public void OnDrag(PointerEventData eventData)
        {
            if (!_isGameplayInputOn) return;
            OnMouseDragEvent?.Invoke(eventData.pointerCurrentRaycast.worldPosition);
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            if (!_isGameplayInputOn) return;
            OnEndDragEvent?.Invoke(eventData.pointerCurrentRaycast.worldPosition);
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            if (!_isGameplayInputOn) return;
            OnPointerDownEvent?.Invoke(eventData.pointerCurrentRaycast.worldPosition);
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            if (!_isGameplayInputOn) return;
            OnPointerUpEvent?.Invoke(eventData.pointerCurrentRaycast.worldPosition);
        }

        public override void GameplayInputOn()
        {
            _isGameplayInputOn = true;
        }

        public override void GameplayInputOff()
        {
            _isGameplayInputOn = false;
        }
    }
}