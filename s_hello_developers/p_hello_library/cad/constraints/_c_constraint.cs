using System.Collections.Generic;

namespace p_hello_library.cad.constraints
{
    /// <summary>
    /// Base class for constraints
    /// </summary>
    public abstract class _c_constraint
    {
        /// <summary>Constraints' values</summary>
        internal List<double> s_val_ = new List<double>();
    }
}