using Foundation;
using UIKit;

namespace iNormal.FluentAutoLayout
{
    /// <summary>
    /// Class that hold both parent view and constraints together to allow fluent methods of adding constraints.
    /// </summary>
    public class ParentConstraint
    {
        /// <summary>
        /// View that marked as parent.
        /// </summary>
        public UIView Parent { get; set; }

        /// <summary>
        /// View that is added into sub view of parent view.
        /// </summary>
        public UIView View { get; set; }

        /// <summary>
        /// Constructor.
        /// </summary>
        public ParentConstraint()
        {
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        public ParentConstraint(UIView view, UIView parent)
        {
            View = view;
            Parent = parent;
        }

        /// <summary>
        /// A helper function that create a new constraint, add to parent view and return the parent constraint to continue the chain method.
        /// </summary>
        private ParentConstraint AddNewConstraint(UIView view, NSLayoutAttribute viewAttribute, NSLayoutRelation relation, NSObject target, NSLayoutAttribute targetAttribute, float multiplier, float constant, float priority)
        {
            // create a new constraint
            var constraint = NSLayoutConstraint.Create(view, viewAttribute, relation, target, targetAttribute, multiplier, constant);
            constraint.Priority = priority;

            // add the new constraint to parent
            Parent.AddConstraint(constraint);

            // continue the chain
            return this;
        }

        /// <summary>
        /// A helper function that create a new constraint, add to given view and return the parent constraint to continue the chain method.
        /// </summary>
        private ParentConstraint AddNewConstraintToParent(UIView view, NSLayoutAttribute viewAttribute, NSLayoutRelation relation, UIView target, NSLayoutAttribute targetAttribute, float multiplier, float constant, float priority)
        {
            // create a new constraint
            var constraint = NSLayoutConstraint.Create(view, viewAttribute, relation, target, targetAttribute, multiplier, constant);
            constraint.Priority = priority;

            // add the new constraint to parent
            target.AddConstraint(constraint);

            // continue the chain
            return this;
        }

        /// <summary>
        /// Create a new height constraint.
        /// </summary>
        public ParentConstraint Height(NSLayoutRelation relation, float multiplier = 1f, float constant = 0f, float priority = Priority.Required)
        {
            return AddNewConstraint(View, NSLayoutAttribute.Height, relation, null, NSLayoutAttribute.Height, multiplier, constant, priority);
        }

        /// <summary>
        /// Create a new height constraint.
        /// </summary>
        public ParentConstraint Height(NSLayoutRelation relation, NSObject target, NSLayoutAttribute attribute, float multiplier = 1f, float constant = 0f, float priority = Priority.Required)
        {
            return AddNewConstraint(View, NSLayoutAttribute.Height, relation, target, attribute, multiplier, constant, priority);
        }

        /// <summary>
        /// Create a new height constraint with given parent view where the contraint should be added.
        /// Use this only if the view is not under the same parent view.
        /// </summary>
        public ParentConstraint HeightToParent(NSLayoutRelation relation, UIView target, NSLayoutAttribute attribute, float multiplier = 1f, float constant = 0f, float priority = Priority.Required)
        {
            return AddNewConstraintToParent(View, NSLayoutAttribute.Height, relation, target, attribute, multiplier, constant, priority);
        }

        /// <summary>
        /// Create a new width constraint.
        /// </summary>
        public ParentConstraint Width(NSLayoutRelation relation, float multiplier = 1f, float constant = 0f, float priority = Priority.Required)
        {
            return AddNewConstraint(View, NSLayoutAttribute.Width, relation, null, NSLayoutAttribute.Width, multiplier, constant, priority);
        }

        /// <summary>
        /// Create a new width constraint.
        /// </summary>
        public ParentConstraint Width(NSLayoutRelation relation, NSObject target, NSLayoutAttribute attribute, float multiplier = 1f, float constant = 0f, float priority = Priority.Required)
        {
            return AddNewConstraint(View, NSLayoutAttribute.Width, relation, target, attribute, multiplier, constant, priority);
        }

        /// <summary>
        /// Create a new width constraint with given parent view where the contraint should be added.
        /// Use this only if the view is not under the same parent view.
        /// </summary>
        public ParentConstraint WidthToParent(NSLayoutRelation relation, UIView target, NSLayoutAttribute attribute, float multiplier = 1f, float constant = 0f, float priority = Priority.Required)
        {
            return AddNewConstraintToParent(View, NSLayoutAttribute.Width, relation, target, attribute, multiplier, constant, priority);
        }

        /// <summary>
        /// Create a new leading constraint.
        /// </summary>
        public ParentConstraint Leading(NSLayoutRelation relation, UIView target, NSLayoutAttribute attribute, float multiplier = 1f, float constant = 0f, float priority = Priority.Required)
        {
            return AddNewConstraint(View, NSLayoutAttribute.Leading, relation, target, attribute, multiplier, constant, priority);
        }

        /// <summary>
        /// Create a new trailing constraint.
        /// </summary>
        public ParentConstraint Trailing(NSLayoutRelation relation, UIView target, NSLayoutAttribute attribute, float multiplier = 1f, float constant = 0f, float priority = Priority.Required)
        {
            return AddNewConstraint(View, NSLayoutAttribute.Trailing, relation, target, attribute, multiplier, constant, priority);
        }

        /// <summary>
        /// Create a new left constraint.
        /// </summary>
        public ParentConstraint Left(NSLayoutRelation relation, NSObject target, NSLayoutAttribute attribute, float multiplier = 1f, float constant = 0f, float priority = Priority.Required)
        {
            return AddNewConstraint(View, NSLayoutAttribute.Left, relation, target, attribute, multiplier, constant, priority);
        }

        /// <summary>
        /// Create a new right constraint.
        /// </summary>
        public ParentConstraint Right(NSLayoutRelation relation, UIView target, NSLayoutAttribute attribute, float multiplier = 1f, float constant = 0f, float priority = Priority.Required)
        {
            return AddNewConstraint(View, NSLayoutAttribute.Right, relation, target, attribute, multiplier, constant, priority);
        }

        /// <summary>
        /// Create a new top constraint.
        /// </summary>
        public ParentConstraint Top(NSLayoutRelation relation, UIView target, NSLayoutAttribute attribute, float multiplier = 1f, float constant = 0f, float priority = Priority.Required)
        {
            return AddNewConstraint(View, NSLayoutAttribute.Top, relation, target, attribute, multiplier, constant, priority);
        }

        /// <summary>
        /// Create a new bottom constraint.
        /// </summary>
        public ParentConstraint Bottom(NSLayoutRelation relation, UIView target, NSLayoutAttribute attribute, float multiplier = 1f, float constant = 0f, float priority = Priority.Required)
        {
            return AddNewConstraint(View, NSLayoutAttribute.Bottom, relation, target, attribute, multiplier, constant, priority);
        }

        /// <summary>
        /// Create a new center x constraint.
        /// </summary>
        public ParentConstraint CenterX(NSLayoutRelation relation, UIView target, NSLayoutAttribute attribute, float multiplier = 1f, float constant = 0f, float priority = Priority.Required)
        {
            return AddNewConstraint(View, NSLayoutAttribute.CenterX, relation, target, attribute, multiplier, constant, priority);
        }

        /// <summary>
        /// Create a new center y constraint.
        /// </summary>
        public ParentConstraint CenterY(NSLayoutRelation relation, UIView target, NSLayoutAttribute attribute, float multiplier = 1f, float constant = 0f, float priority = Priority.Required)
        {
            return AddNewConstraint(View, NSLayoutAttribute.CenterY, relation, target, attribute, multiplier, constant, priority);
        }

        /// <summary>
        /// Set content compression resistance priority.
        /// </summary>
        public ParentConstraint CompressionResistance(float priority, UILayoutConstraintAxis axis)
        {
            View.SetContentCompressionResistancePriority(priority, axis);
            return this;
        }

        /// <summary>
        /// Set content hugging priority.
        /// </summary>
        public ParentConstraint ContentHugging(float priority, UILayoutConstraintAxis axis)
        {
            View.SetContentHuggingPriority(priority, axis);
            return this;
        }

        /// <summary>
        /// Set content hugging priority.
        /// </summary>
        public ParentConstraint Hugging(float priority, UILayoutConstraintAxis axis)
        {
            View.SetContentHuggingPriority(priority, axis);
            return this;
        }
    }
}