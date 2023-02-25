using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyPlatformer
{
    [CreateAssetMenu(menuName = "EventChanel/Add Score")]
    public class AddScoreEventChanel : ScriptableObject
    {
        private event System.Action<int> _onAddScore = delegate { };

        public void RaiseEvent(int increment)
        {
            _onAddScore?.Invoke(increment);
        }

        public void AddListener(System.Action<int> callback)
        {
            _onAddScore += callback;
        }

        public void RemoveListener(System.Action<int> callback)
        {
            _onAddScore -= callback;
        }
    }
}
