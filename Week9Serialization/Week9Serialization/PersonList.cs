using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Week9Serialization
{
    /// <summary>
    /// This class is a list of Persons (male and/or female).
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [Serializable]
    [KnownType(typeof(Male))]
    [KnownType(typeof(Female))]
    public class PersonList<T> : List<T> where T :Person
    {
    }
}
