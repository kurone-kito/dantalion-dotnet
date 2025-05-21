using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace black.kit.dantalion
{
    /// <summary>The index of personality information.</summary>
    public enum PersonalityIndex : int
    {
        /// <summary>The change of auxiliary qualities.</summary>
        Cycle,

        /// <summary>The inner qualities.</summary>
        Inner,

        /// <summary>The underlying worldview.</summary>
        LifeBase,

        /// <summary>The outer qualities.</summary>
        Outer,

        /// <summary>The potential A when taking action.</summary>
        PotentialA,

        /// <summary>The potential B when taking action.</summary>
        PotentialB,

        /// <summary>The qualities during emergencies or concentration.</summary>
        WorkStyle,

        /// <summary>The maximum value of the enumeration.</summary>
        /// <remarks>This value is not valid as an index.</remarks>
        MAX_VALUE,
    }
}
