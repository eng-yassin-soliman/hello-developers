using System.Collections.Generic;

namespace p_ArabiCAD.constraints
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