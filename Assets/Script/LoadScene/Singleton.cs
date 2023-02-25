using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyPlatformer
{
    public abstract class Singleton<T> : MonoBehaviour where T:Singleton<T>
    {
        private static T _instance;
        public static T intsance => _instance;

        protected void Awake()
        {
            _instance = this as T;
        }
    }
}
