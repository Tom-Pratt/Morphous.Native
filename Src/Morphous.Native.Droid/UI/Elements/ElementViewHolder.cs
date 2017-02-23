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
using Morphous.Native.Models;
using GalaSoft.MvvmLight.Helpers;

namespace Morphous.Native.Droid.UI.Elements
{
    public class ElementViewHolder<TElement> : ElementViewHolder where TElement : class, IContentElement
    {
        protected LayoutInflater Inflater { get; }
        protected ViewGroup Container { get; }
        protected TElement Element { get; }

        public ElementViewHolder(Context context, LayoutInflater inflater, ViewGroup container, TElement element) : base(context)
        {
            Inflater = inflater;
            Container = container;
            Element = element;
        }

        protected override View CreateView()
        {
            var layoutId = Context.Resources.GetIdentifier(Element.Type.ToLower(), "layout", Context.PackageName);
            if (layoutId > 0)
            {
                return Inflater.Inflate(layoutId, Container, false);
            }

            return new View(Context);
        }
    }

    public abstract class ElementViewHolder : IDisposable
    {
        protected Context Context { get; }
        protected IList<Binding> Bindings { get; } = new List<Binding>();

        public ElementViewHolder(Context context)
        {
            Context = context;
        }

        private View _view;
        public View View
        {
            get
            {
                if (_view == null)
                {
                    _view = CreateView();
                    BindView(_view);
                }

                return _view;
            }
        }

        protected abstract View CreateView();

        protected virtual void BindView(View view)
        {
        }

        public virtual void Dispose()
        {
            foreach (var binding in Bindings)
            {
                binding.Detach();
            }
        }
    }
}