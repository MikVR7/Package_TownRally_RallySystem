using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TownRally.RallySystem
{
    //[ShowOdinSerializedPropertiesInInspector]
    [CreateAssetMenu/*Attribute*/(menuName = "Scriptable Objects/Letters")]
    internal class Letters : SerializedScriptableObject
    {
        [SerializeField] internal Dictionary<char, GameObject> LetterObjects { get; private set; } = new Dictionary<char, GameObject>();

        //internal bool ContainsKey(char key)
        //{
        //    return letters.ContainsKey(key);
        //}

        //internal GameObject GetObject(char key)
        //{
        //    return this.letters[key];
        //}
    }
}