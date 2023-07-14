using System;

namespace Pagination_Project.API.Domain.Attributes
{
    /// <summary>
    /// Display String Attribute class
    /// </summary>
    [AttributeUsage(AttributeTargets.Field)]
    public sealed class DisplayStringAttribute : Attribute
    {
        private readonly string _value;

        /// <summary>
        /// DisplayStringAttribute Default constructor
        /// </summary>
        public DisplayStringAttribute()
        {

        }

        /// <summary>
        /// DisplayStringAttribute constructor
        /// </summary>
        /// <param name="v">String Value initialiser</param>
        public DisplayStringAttribute(string v)
        {
            _value = v;
        }

        /// <summary>
        /// Get the Value
        /// </summary>
        public string Value
        {
            get { return _value; }
        }

        /// <summary>
        /// Get/Set the ResourceKey
        /// </summary>
        public string ResourceKey
        {
            get;
            set;
        }

        /// <summary>
        /// Get/Set the ResourceName
        /// </summary>
        public string ResourceName
        {
            get;
            set;
        }
    }
}
