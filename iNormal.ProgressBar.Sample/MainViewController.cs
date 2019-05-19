using System.Threading;
using UIKit;

namespace iNormal.ProgressBar.Sample
{
    /// <summary>
    /// View controller to demo the normal progress bar.
    /// </summary>
    public partial class MainViewController : UIViewController
    {
        public ProgressBar ProgressBar { get; private set; }

        public UILabel TextLabel { get; private set; }

        public UIStackView ButtonsStackView { get; private set; }
        public UIButton IndeterminateButton { get; private set; }
        public UIButton DeterminateButton { get; private set; }

        private Timer _DeterminateTimer;

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
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            // set the view title and background color
            Title = "Normal Progress Bar Sample";
            View.BackgroundColor = UIColor.White;

            // make sure our view is render below navigation bar
            EdgesForExtendedLayout = UIRectEdge.None;
            
            // create the user interface from code behind with auto layout
            ProgressBar = new ProgressBar()
            {
                TranslatesAutoresizingMaskIntoConstraints = false,
                TrackTintColor = UIColor.LightGray,
                ProgressTintColor = UIColor.Red
            };
            View.AddSubview(ProgressBar);
            View.AddConstraint(NSLayoutConstraint.Create(ProgressBar, NSLayoutAttribute.Left, NSLayoutRelation.Equal, View, NSLayoutAttribute.Left, 1f, 0f));
            View.AddConstraint(NSLayoutConstraint.Create(ProgressBar, NSLayoutAttribute.Right, NSLayoutRelation.Equal, View, NSLayoutAttribute.Right, 1f, 0f));
            View.AddConstraint(NSLayoutConstraint.Create(ProgressBar, NSLayoutAttribute.Top, NSLayoutRelation.Equal, View, NSLayoutAttribute.Top, 1f, 0f));
            View.AddConstraint(NSLayoutConstraint.Create(ProgressBar, NSLayoutAttribute.Height, NSLayoutRelation.Equal, null, NSLayoutAttribute.Height, 1f, 5f));

            TextLabel = new UILabel()
            {
                TranslatesAutoresizingMaskIntoConstraints = false,
                Text = "A demo showing a really normal progress bar that function like a normal progress bar. A progress bar which can perform determinate progress and indeterminate progress.",
                TextAlignment = UITextAlignment.Center,
                Lines = -1
            };
            View.AddSubview(TextLabel);
            View.AddConstraint(NSLayoutConstraint.Create(TextLabel, NSLayoutAttribute.Left, NSLayoutRelation.Equal, View, NSLayoutAttribute.Left, 1f, 40f));
            View.AddConstraint(NSLayoutConstraint.Create(TextLabel, NSLayoutAttribute.Right, NSLayoutRelation.Equal, View, NSLayoutAttribute.Right, 1f, -40f));
            View.AddConstraint(NSLayoutConstraint.Create(TextLabel, NSLayoutAttribute.CenterY, NSLayoutRelation.Equal, View, NSLayoutAttribute.CenterY, 1f, 0f));

            ButtonsStackView = new UIStackView()
            {
                TranslatesAutoresizingMaskIntoConstraints = false,
                Axis = UILayoutConstraintAxis.Vertical,
                Alignment = UIStackViewAlignment.Top,
                Distribution = UIStackViewDistribution.Fill,
                Spacing = 10f
            };
            View.AddSubview(ButtonsStackView);
            View.AddConstraint(NSLayoutConstraint.Create(ButtonsStackView, NSLayoutAttribute.Left, NSLayoutRelation.Equal, View, NSLayoutAttribute.LeftMargin, 1f, 0f));
            View.AddConstraint(NSLayoutConstraint.Create(ButtonsStackView, NSLayoutAttribute.Right, NSLayoutRelation.Equal, View, NSLayoutAttribute.RightMargin, 1f, 0f));
            View.AddConstraint(NSLayoutConstraint.Create(ButtonsStackView, NSLayoutAttribute.Top, NSLayoutRelation.GreaterThanOrEqual, View, NSLayoutAttribute.TopMargin, 1f, 0f));
            View.AddConstraint(NSLayoutConstraint.Create(ButtonsStackView, NSLayoutAttribute.Bottom, NSLayoutRelation.Equal, View, NSLayoutAttribute.BottomMargin, 1f, 0f));

            IndeterminateButton = new UIButton(UIButtonType.System)
            {
                TranslatesAutoresizingMaskIntoConstraints = false,
                BackgroundColor = UIColor.DarkGray
            };
            IndeterminateButton.SetTitle("Indeterminate", UIControlState.Normal);
            IndeterminateButton.SetTitleColor(UIColor.White, UIControlState.Normal);
            IndeterminateButton.TouchUpInside += (sender, e) =>
            {
                ProgressBar.IsIndeterminate = !ProgressBar.IsIndeterminate;
                DeterminateProgressBar(false);
            };
            ButtonsStackView.AddArrangedSubview(IndeterminateButton);
            View.AddConstraint(NSLayoutConstraint.Create(IndeterminateButton, NSLayoutAttribute.Left, NSLayoutRelation.Equal, ButtonsStackView, NSLayoutAttribute.Left, 1f, 0f));
            View.AddConstraint(NSLayoutConstraint.Create(IndeterminateButton, NSLayoutAttribute.Right, NSLayoutRelation.Equal, ButtonsStackView, NSLayoutAttribute.Right, 1f, 0f));
            View.AddConstraint(NSLayoutConstraint.Create(IndeterminateButton, NSLayoutAttribute.Height, NSLayoutRelation.Equal, null, NSLayoutAttribute.Height, 1f, 40f));

            DeterminateButton = new UIButton(UIButtonType.System)
            {
                TranslatesAutoresizingMaskIntoConstraints = false,
                BackgroundColor = UIColor.DarkGray
            };
            DeterminateButton.SetTitle("Determinate", UIControlState.Normal);
            DeterminateButton.SetTitleColor(UIColor.White, UIControlState.Normal);
            DeterminateButton.TouchUpInside += (sender, e) =>
            {
                ProgressBar.IsIndeterminate = false;
                DeterminateProgressBar(true);
            };
            ButtonsStackView.AddArrangedSubview(DeterminateButton);
            View.AddConstraint(NSLayoutConstraint.Create(DeterminateButton, NSLayoutAttribute.Left, NSLayoutRelation.Equal, ButtonsStackView, NSLayoutAttribute.Left, 1f, 0f));
            View.AddConstraint(NSLayoutConstraint.Create(DeterminateButton, NSLayoutAttribute.Right, NSLayoutRelation.Equal, ButtonsStackView, NSLayoutAttribute.Right, 1f, 0f));
            View.AddConstraint(NSLayoutConstraint.Create(DeterminateButton, NSLayoutAttribute.Height, NSLayoutRelation.Equal, null, NSLayoutAttribute.Height, 1f, 40f));
        }

        /// <summary>
        /// Enable the progress bar to show determined progress.
        /// </summary>
        private void DeterminateProgressBar(bool isOn)
        {
            if (isOn)
            {
                if (_DeterminateTimer == null)
                {
                    _DeterminateTimer = new Timer(UpdateDeterminateProgressBar, null, 0, 50);
                }
            }
            else
            {
                if (_DeterminateTimer != null)
                {
                    _DeterminateTimer.Dispose();
                    _DeterminateTimer = null;
                }
            }
        }

        /// <summary>
        /// Loop that keep on updating the progress bar's progress for demo purpose.
        /// </summary>
        private void UpdateDeterminateProgressBar(object state)
        {
            // timer always run in background thread,
            // make sure we invoke the user interface changes on main thread
            InvokeOnMainThread(() =>
            {
                if (_DeterminateTimer != null)
                {
                    if (ProgressBar.Value >= ProgressBar.Maximum)
                    {
                        ProgressBar.Value = 0;
                    }
                    else
                    {
                        ProgressBar.Value += 1;
                    }
                }
            });
        }
    }
}