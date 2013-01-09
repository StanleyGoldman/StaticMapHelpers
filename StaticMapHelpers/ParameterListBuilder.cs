using System;
using System.Collections.Generic;

namespace Molimentum.StaticMapHelpers
{
    /// <summary>
    /// Builder for creating and encoding nested parameter strings.
    /// </summary>
    public class ParameterListBuilder
    {
        private List<string> _parameters = new List<string>();
        private string _delimiter;
        private string _separator;

        public ParameterListBuilder(string delimiter, string separator)
        {
            _delimiter = delimiter;
            _separator = separator;
        }

        public void Add(string value)
        {
            _parameters.Add(Uri.EscapeDataString(value));
        }

        public void Add(string name, string value)
        {
            Add(name, value, true);
        }

        public void Add(string name, string value, bool encode)
        {
            _parameters.Add(name + _delimiter + (encode ? Uri.EscapeDataString(value) : value));
        }

        public override string ToString()
        {
            return String.Join(_separator, _parameters);
        }
    }
}
