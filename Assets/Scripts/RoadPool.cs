using System;
using Scripts.Path;
using UnityEngine;

namespace Scripts
{
    [Serializable]
    public class PathTypePool
    {
        [SerializeField] private ObjectPoolController _pool;
        [SerializeField] private PathBlockType _type;


        public ObjectPoolController Pool => _pool;
        public PathBlockType Type => _type;
    }
}