# Fluent Auto Layout
Code auto layout in Xamarin iOS using fluent interface and reduce many boilerplate code required for a simple layout.

Knowledge on how auto layout work in iOS is still required. Fluent auto layout just help developer to write a shorter and cleaner code that accomplish the same thing.

## Sample
Without fluent auto layout
```C#
NameView = new UIView()
{
    TranslatesAutoresizingMaskIntoConstraints = false
};
View.AddSubview(NameView);
    View.AddConstraint(NSLayoutConstraint.Create(NameView, NSLayoutAttribute.Left, NSLayoutRelation.Equal, View, NSLayoutAttribute.Left, 1f, 10f));
    View.AddConstraint(NSLayoutConstraint.Create(NameView, NSLayoutAttribute.Right, NSLayoutRelation.Equal, View, NSLayoutAttribute.Right, 1f, 10f));
    View.AddConstraint(NSLayoutConstraint.Create(NameView, NSLayoutAttribute.Top, NSLayoutRelation.Equal, View, NSLayoutAttribute.Top, 1f, 10f));
```
With fluent auto layout
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