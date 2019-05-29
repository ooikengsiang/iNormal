using System.Linq;
using UIKit;

namespace iNormal.FluentAutoLayout
{
    public static class ViewExtension
    {
        /// <summary>
        /// Add view to parent's sub view and return a parent constraint object that can use to chain method / make fluent method call.
        /// </summary>
        public static ParentConstraint SetParentAndConstraints(this UIView view, UIView parent)
        {
            // make sure this is off to allow auto layout work correctly
            view.TranslatesAutoresizingMaskIntoConstraints = false;

            // add the view as sub view first
            if (parent != null)
            {
                if (parent is UIStackView parentStackView)
                {
                    parentStackView.AddArrangedSubview(view);
                }
                else
                {
                    parent.AddSubview(view);
                }
            }

            // return a parent constraint object that can use to chain method / make fluent method call.
            return new ParentConstraint(view, parent);
        }

        /// <summary>
        /// Add view to table view's header and return a parent constraint object that can use to chain method / make fluent method call.
        /// </summary>
        public static ParentConstraint SetTableHeaderAndConstraints(this UIView view, UITableView parent)
        {
            // make sure this is off to allow auto layout work correctly
            view.TranslatesAutoresizingMaskIntoConstraints = false;

            // add the view as header view
            if (parent != null)
            {
                parent.TableHeaderView = view;
            }

            // return a parent constraint object that can use to chain method / make fluent method call.
            return new ParentConstraint(view, parent);
        }

        /// <summary>
        /// Add view to table view's footer and return a parent constraint object that can use to chain method / make fluent method call.
        /// </summary>
        public static ParentConstraint SetTableFooterAndConstraints(this UIView view, UITableView parent)
        {
            // auto layout for table view footer is broken
            // don't automatically disable TranslatesAutoresizingMaskIntoConstraints

            // add the view as header view
            if (parent != null)
            {
                parent.TableFooterView = view;
            }

            // return a parent constraint object that can use to chain method / make fluent method call.
            return new ParentConstraint(view, parent);
        }

        /// <summary>
        /// Retrieve the target constraint related with this view from it's parent.
        /// </summary>
        public static NSLayoutConstraint GetConstraint(this UIView view, NSLayoutAttribute attribute)
        {
            return view.Superview.Constraints.FirstOrDefault(x =>
                x.FirstItem == view &&
                x.FirstAttribute == attribute);
        }
    }
}
