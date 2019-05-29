# iNormal
A collection of Xamarin.iOS library written in C# that help simplify iOS development.

## [Progress Bar](./iNormal.ProgressBar)
A really normal progress bar that function like a normal progress bar. A progress bar which can perform determinate progress and indeterminate progress.

![progress bar indeterminate](./iNormal.ProgressBar/ProgressBarIndeterminateDemo.gif)

## [Fluent Auto Layout](./iNormal.FluentAutoLayout)
Code auto layout using fluent interface and reduce many boilerplate code required for a simple layout.
```C#
NameView = new UIView()
{
    TranslatesAutoresizingMaskIntoConstraints = false
};
NameView.SetParentAndConstraints(View)
    .Left(NSLayoutRelation.Equal, View, NSLayoutAttribute.Left, 1f, 10f)
    .Right(NSLayoutRelation.Equal, View, NSLayoutAttribute.Right, 1f, 10f)
    .Top(NSLayoutRelation.Equal, View, NSLayoutAttribute.Top, 1f, 10f);
```