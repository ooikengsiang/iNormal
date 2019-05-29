using UIKit;

namespace iNormal.FluentAutoLayout
{
    /// <summary>
    /// Make a shorter naming and float type version of layout priority.
    /// </summary>
    public static class Priority
    {
        /// <summary>
        /// Required layout priority in float type.
        /// </summary>
        public const float Required = (float)UILayoutPriority.Required;

        /// <summary>
        /// Default high layout priority in float type.
        /// </summary>
        public const float High = (float)UILayoutPriority.DefaultHigh;

        /// <summary>
        /// Default low layout priority in float type.
        /// </summary>
        public const float Low = (float)UILayoutPriority.DefaultLow;

        /// <summary>
        /// Fitting Size level layout priority in float type.
        /// </summary>
        public const float Fitting = (float)UILayoutPriority.FittingSizeLevel;
    }
}