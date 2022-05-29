using System;
using Scripts.Path;
using Scripts.Pool;
using UnityEngine;

namespace Scripts
{
    [Serializable]
    public class PathTypePool
    {
        [SerializeField] private PathPoolController _pool;
        [SerializeField] private PathBlockType _type;


        public PathPoolController Pool => _pool;
        public PathBlockType Type => _type;
    }
}