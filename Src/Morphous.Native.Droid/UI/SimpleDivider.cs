using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Support.V7.Widget;
using Android.Graphics.Drawables;
using Android.Content.Res;

namespace Morphous.Native.Droid.UI
{
    public class SimpleDivider : RecyclerView.ItemDecoration
    {
        private Drawable divider;
        private int[] attributes = new int[] { Android.Resource.Attribute.ListDivider };

        public SimpleDivider(Context context)
        {
            TypedArray ta = context.ObtainStyledAttributes(attributes);
            divider = ta.GetDrawable(0);
            ta.Recycle();
        }

        public override void OnDraw(Android.Graphics.Canvas c, RecyclerView parent, RecyclerView.State state)
        {
            base.OnDraw(c, parent, state);

            int left = parent.PaddingLeft;
            int right = parent.Width - parent.PaddingRight;

            for (int i = 0; i < parent.ChildCount; i++)
            {
                View child = parent.GetChildAt(i);

                ViewGroup.MarginLayoutParams parameters = (ViewGroup.MarginLayoutParams)child.LayoutParameters;

                int top = child.Bottom + parameters.BottomMargin;
                int bottom = top + divider.IntrinsicHeight;

                divider.SetBounds(left, top, right, bottom);
                divider.Draw(c);
            }
        }
    }
}