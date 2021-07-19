using UnityEngine;
using UnityEngine.Events;

namespace ScriptableObjects.GameEvents
{
    public class GameEventListener : MonoBehaviour
    {
        [Tooltip("Event to register with.")] public GameEvent GameEvent;

        [Tooltip("Response to invoke when Event is raised.")]
        public UnityEvent Response;

        private void OnEnable()
        {
            GameEvent.SubscribeListener(this);
        }

        private void OnDisable()
        {
            GameEvent.UnsubscribeListener(this);
        }

        public void OnEventRaised()
        {
            Response.Invoke();
        }
    }
}