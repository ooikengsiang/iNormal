using CoreGraphics;
using Foundation;
using System;
using UIKit;

namespace iNormal.ProgressBar
{
    /// <summary>
    /// A really normal progress bar that function like a normal progress bar.
    /// A progress bar which can perform determinate progress and indeterminate progress.
    /// </summary>
    public class ProgressBar : UIProgressView
    {
        /// <summary>
        /// Is the progress bar in indeterminate loading.
        /// </summary>
        public bool IsIndeterminate
        {
            get { return _IsIndeterminate; }
            set
            {
                if (_IsIndeterminate != value)
                {
                    IndeterminateAnimation(value);
                }
            }
        }
        private bool _IsIndeterminate;

        /// <summary>
        /// Current progress value.
        /// </summary>
        public float Value
        {
            get { return _Value; }
            set
            {
                if (_Value != value)
                {
                    _Value = value;
                    CalculateProgress();
                }
            }
        }
        private float _Value;

        /// <summary>
        /// Minimum value of the progress.
        /// </summary>
        public float Minimum
        {
            get { return _Minimum; }
            set
            {
                if (_Minimum != value)
                {
                    _Minimum = value;
                    CalculateProgress();
                }
            }
        }
        private float _Minimum = 0f;

        /// <summary>
        /// Maximum value of the progress.
        /// </summary>
        public float Maximum
        {
            get { return _Maximum; }
            set
            {
                if (_Maximum != value)
                {
                    _Maximum = value;
                    CalculateProgress();
                }
            }
        }
        private float _Maximum = 100f;

        /// <summary>
        /// Progress tiny color / progress bar indicator color.
        /// </summary>
        public override UIColor ProgressTintColor
        {
            get => base.ProgressTintColor;
            set
            {
                base.ProgressTintColor = value;
                if (_IndicatorView != null)
                {
                    _IndicatorView.BackgroundColor = value;
                }
            }
        }

        private bool _IsIndeterminateAnimationRunning;
        private UIView _IndicatorView;
        private NSLayoutConstraint _IndicatorViewLeftLayoutConstraint;
        private NSLayoutConstraint _IndicatorViewWidthLayoutConstraint;

        /// <summary>
        /// Just a constructor for a very normal progress bar.
        /// </summary>
        public ProgressBar()
            : base()
        {
            InitView();
        }

        /// <summary>
        /// Just a constructor for a very normal progress bar.
        /// </summary>
        public ProgressBar(CGRect frame)
            : base(frame)
        {
            InitView();
        }

        /// <summary>
        /// Just a constructor for a very normal progress bar.
        /// </summary>
        public ProgressBar(IntPtr handle)
            : base(handle)
        {
            InitView();
        }

        /// <summary>
        /// Just a constructor for a very normal progress bar.
        /// </summary>
        public ProgressBar(NSCoder coder)
            : base(coder)
        {
            InitView();
        }

        /// <summary>
        /// Just a constructor for a very normal progress bar.
        /// </summary>
        public ProgressBar(NSObjectFlag t)
            : base(t)
        {
            InitView();
        }

        /// <summary>
        /// Just a constructor for a very normal progress bar.
        /// </summary>
        public ProgressBar(UIProgressViewStyle style)
            : base(style)
        {
            InitView();
        }

        /// <summary>
        /// Add the additional view into the progress view.
        /// </summary>
        private void InitView()
        {
            // need additional view to animate as indeterminate
            // create one and add into view
            _IndicatorView = new UIView()
            {
                // we will use auto constraint
                TranslatesAutoresizingMaskIntoConstraints = false,
                BackgroundColor = ProgressTintColor
            };
            AddSubview(_IndicatorView);

            var topLayoutConstraint = NSLayoutConstraint.Create(_IndicatorView, NSLayoutAttribute.Top, NSLayoutRelation.Equal, this, NSLayoutAttribute.Top, 1f, 0f);
            topLayoutConstraint.Priority = 1000f;
            AddConstraint(topLayoutConstraint);

            var bottomLayoutConstraint = NSLayoutConstraint.Create(_IndicatorView, NSLayoutAttribute.Bottom, NSLayoutRelation.Equal, this, NSLayoutAttribute.Bottom, 1f, 0f);
            bottomLayoutConstraint.Priority = 1000f;
            AddConstraint(bottomLayoutConstraint);

            _IndicatorViewLeftLayoutConstraint = NSLayoutConstraint.Create(_IndicatorView, NSLayoutAttribute.Left, NSLayoutRelation.Equal, this, NSLayoutAttribute.Left, 1f, 0f);
            _IndicatorViewLeftLayoutConstraint.Priority = 1000f;
            AddConstraint(_IndicatorViewLeftLayoutConstraint);

            _IndicatorViewWidthLayoutConstraint = NSLayoutConstraint.Create(_IndicatorView, NSLayoutAttribute.Width, NSLayoutRelation.Equal, null, NSLayoutAttribute.Width, 1f, 0f);
            _IndicatorViewWidthLayoutConstraint.Priority = 1000f;
            AddConstraint(_IndicatorViewWidthLayoutConstraint);
        }

        /// <summary>
        /// Start / stop the indeterminate progress bar animation.
        /// </summary>
        private void IndeterminateAnimation(bool isStart)
        {
            if (isStart)
            {
                // reset the progress so that the progress indicator won't block the view
                base.Progress = 0f;

                // start the animation
                _IsIndeterminate = true;
                if (!_IsIndeterminateAnimationRunning)
                {
                    IndeterminateAnimationLoop();
                }
            }
            else
            {
                // stop the animation
                _IsIndeterminate = false;

                // restore the progress if any
                CalculateProgress();
            }
        }

        /// <summary>
        /// Indeterminate progress bar animation.
        /// </summary>
        private void IndeterminateAnimationLoop()
        {
            // mark that the animation is already running
            _IsIndeterminateAnimationRunning = true;

            _IndicatorViewLeftLayoutConstraint.Constant = 0f;
            _IndicatorViewWidthLayoutConstraint.Constant = 0f;

            // update the layout
            LayoutIfNeeded();

            Animate(0.5d, 0d, UIViewAnimationOptions.TransitionNone, () =>
            {
                _IndicatorViewLeftLayoutConstraint.Constant = 0f;

                _IndicatorViewWidthLayoutConstraint.Constant = Frame.Width * 0.7f;

                // update the layout
                LayoutIfNeeded();
            }, null);

            Animate(0.4d, 0.4d, UIViewAnimationOptions.TransitionNone, () =>
            {
                _IndicatorViewLeftLayoutConstraint.Constant = Frame.Width;

                _IndicatorViewWidthLayoutConstraint.Constant = 0f;

                // update the layout
                LayoutIfNeeded();
            }, () =>
            {
                if (IsIndeterminate)
                {
                    // continue the animation
                    IndeterminateAnimationLoop();
                }
                else
                {
                    // mark that the animation has already stopped
                    _IsIndeterminateAnimationRunning = false;
                }
            });
        }

        /// <summary>
        /// Translate the value, minimum and maximum into progress view's progress.
        /// </summary>
        private void CalculateProgress()
        {
            var total = Maximum - Minimum;
            base.Progress = Value / total;
        }
    }
}
