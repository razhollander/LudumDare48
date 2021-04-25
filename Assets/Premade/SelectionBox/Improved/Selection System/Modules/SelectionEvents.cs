﻿using UnityEngine.Events;

namespace SelectionSystem.Modules
{
    /// <summary>
    /// Holds the extra events for the selection / deselection operation.
    /// </summary>
    [System.Serializable]
    public sealed class SelectionEvents
    {
        /// <summary>
        /// Must be invoked when the selectable is selected.
        /// </summary>
        public UnityEvent onSelection;

        /// <summary>
        /// Must be invoked when the selectable is deselected.
        /// </summary>
        public UnityEvent onDeselection;
    }
}