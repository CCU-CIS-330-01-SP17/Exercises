﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
namespace Week9Serialization
{
    public class Car : Vehicle
    {
        public Car(string name = null)
            : base(name)
        { }
    }
}