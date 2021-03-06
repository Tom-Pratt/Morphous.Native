// This file has been autogenerated from a class added in the UI designer.

using System;

using Foundation;
using Morphous.Native.Models;
using UIKit;

namespace Morphous.Native.iOS
{
    public partial class MediaFieldView : ElementView<IMediaField>
	{
		public MediaFieldView (IntPtr handle) : base (handle)
		{
		}

        protected override void Bind()
        {
            base.Bind();
            var contentItemView = DisplayContext.ViewFactory.CreateContentItemView(Element.Media);

            AddSubview(contentItemView);
            AddConstraints(ContentConstraints(contentItemView, this));
        }

        private NSLayoutConstraint[] ContentConstraints(UIView contentItemView, UIView container)
        {
            return new NSLayoutConstraint[] {
                NSLayoutConstraint.Create (
                    contentItemView,
                    NSLayoutAttribute.Left,
                    NSLayoutRelation.Equal,
                    container,
                    NSLayoutAttribute.Left,
                    1, 0),

                NSLayoutConstraint.Create (
                    contentItemView,
                    NSLayoutAttribute.Right,
                    NSLayoutRelation.Equal,
                    container,
                    NSLayoutAttribute.Right,
                    1, 0),

                NSLayoutConstraint.Create (
                    contentItemView,
                    NSLayoutAttribute.Top,
                    NSLayoutRelation.Equal,
                    container,
                    NSLayoutAttribute.Top,
                    1, 0),

                NSLayoutConstraint.Create (
                    contentItemView,
                    NSLayoutAttribute.Bottom,
                    NSLayoutRelation.Equal,
                    container,
                    NSLayoutAttribute.Bottom,
                    1, 0)
            };
        }
	}
}
