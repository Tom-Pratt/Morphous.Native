// This file has been autogenerated from a class added in the UI designer.

using System;

using Foundation;
using Morphous.Native.Models;
using UIKit;

namespace Morphous.Native.iOS
{
    public partial class CommonPartView : ElementView<ICommonPart>
	{
		public CommonPartView (IntPtr handle) : base (handle)
		{
		}

        protected override void Bind()
        {
            base.Bind();
            IdLabel.Text = $"{Element.Id}";
            ResourceUrlLabel.Text = Element.ResourceUrl;
            PublishedDateLabel.Text = Element.PublishedDate.ToString("dd MMM yyyy");
            CreatedDateLabel.Text = Element.CreatedDate.ToString("dd MMM yyyy");
        }
	}
}
