﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestEase
{
    /// <summary>
    /// Type of serialization that should be applied to the body
    /// </summary>
    public enum BodySerializationMethod
    {
        /// <summary>
        /// Serialized using the configured IRequestBodySerializer (uses Json.NET by default)
        /// </summary>
        Serialized,

        /// <summary>
        /// Serialized using Form URL Encoding. The body must implement IDictionary
        /// </summary>
        UrlEncoded,
    }

    /// <summary>
    /// Attribute specifying that this parameter should be interpreted as the request body
    /// </summary>
    [AttributeUsage(AttributeTargets.Parameter, Inherited = false, AllowMultiple = false)]
    public sealed class BodyAttribute : Attribute
    {
        /// <summary>
        /// Serialization method to use. Defaults to BodySerializationMethod.Serialized
        /// </summary>
        public BodySerializationMethod SerializationMethod { get; private set; }

        public BodyAttribute()
        {
            this.SerializationMethod = BodySerializationMethod.Serialized;
        }

        public BodyAttribute(BodySerializationMethod serializationMethod)
        {
            this.SerializationMethod = serializationMethod;
        }
    }
}
