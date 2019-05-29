using Foundation;
using System;
using UIKit;

namespace iNormal.FluentAutoLayout.Sample
{
    /// <summary>
    /// View controller to demo create auto layout view using fluent auto layout.
    /// </summary>
    public partial class MainViewController : UIViewController
    {
        public UIView NameView { get; private set; }
        public UILabel NameLabel { get; private set; }
        public UITextField FirstNameTextField { get; private set; }
        public UITextField LastNameTextField { get; private set; }

        /// <summary>
        /// View controller constructor.
        /// </summary>
        public MainViewController()
            : base()
        {
        }

        /// <summary>
        /// Views loaded where we can add our view.
        /// </summary>
        public override void ViewDidLoad ()
        {
            base.ViewDidLoad ();

            // set the view title and background color
            Title = "Fluent Auto Layout Sample";
            View.BackgroundColor = UIColor.White;

            // make sure our view is render below navigation bar
            EdgesForExtendedLayout = UIRectEdge.None;

            NameView = new UIView()
            {
                TranslatesAutoresizingMaskIntoConstraints = false
            };
            NameView.SetParentAndConstraints(View)
                .Left(NSLayoutRelation.Equal, View, NSLayoutAttribute.Left, 1f, 10f)
                .Right(NSLayoutRelation.Equal, View, NSLayoutAttribute.Right, 1f, 10f)
                .Top(NSLayoutRelation.Equal, View, NSLayoutAttribute.Top, 1f, 10f);
            {
                NameLabel = new UILabel()
                {
                    TranslatesAutoresizingMaskIntoConstraints = false,
                    Text = "Name"
                };
                NameLabel.SetParentAndConstraints(NameView)
                    .Left(NSLayoutRelation.Equal, NameView, NSLayoutAttribute.Left)
                    .Right(NSLayoutRelation.Equal, NameView, NSLayoutAttribute.Right)
                    .Top(NSLayoutRelation.Equal, NameView, NSLayoutAttribute.Top);

                FirstNameTextField = new UITextField()
                {
                    TranslatesAutoresizingMaskIntoConstraints = false,
                    Placeholder = "first"
                };
                FirstNameTextField.SetParentAndConstraints(NameView)
                    .Left(NSLayoutRelation.Equal, NameView, NSLayoutAttribute.Left)
                    .Top(NSLayoutRelation.Equal, NameLabel, NSLayoutAttribute.Bottom)
                    .Bottom(NSLayoutRelation.Equal, NameView, NSLayoutAttribute.Bottom)
                    .Width(NSLayoutRelation.Equal, NameView, NSLayoutAttribute.Width, 0.5f);

                LastNameTextField = new UITextField()
                {
                    TranslatesAutoresizingMaskIntoConstraints = false,
                    Placeholder = "last"
                };
                LastNameTextField.SetParentAndConstraints(NameView)
                    .Leading(NSLayoutRelation.Equal, FirstNameTextField, NSLayoutAttribute.Trailing)
                    .Right(NSLayoutRelation.Equal, NameView, NSLayoutAttribute.Right)
                    .Top(NSLayoutRelation.Equal, NameLabel, NSLayoutAttribute.Bottom)
                    .Bottom(NSLayoutRelation.Equal, NameView, NSLayoutAttribute.Bottom)
                    .Width(NSLayoutRelation.Equal, NameView, NSLayoutAttribute.Width, 0.5f);
            }


        }
    }
}