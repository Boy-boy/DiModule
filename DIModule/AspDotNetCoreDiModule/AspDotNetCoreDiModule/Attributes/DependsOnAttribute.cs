﻿using System;

namespace AspDotNetCoreDiModule.Attributes
{

    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class DependsOnAttribute : Attribute
    {

        public Type[] DependedModuleTypes { get; private set; }


        public DependsOnAttribute(params Type[] dependedModuleTypes)
        {
            DependedModuleTypes = dependedModuleTypes;
        }
    }
}
