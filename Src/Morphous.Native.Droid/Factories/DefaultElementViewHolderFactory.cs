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
using Morphous.Native.Droid.UI.Elements;
using Morphous.Native.Models;

namespace Morphous.Native.Droid.Factories
{
    public class DefaultElementViewHolderFactory : IElementViewHolderFactory
    {
        private static IElementViewHolderFactory _instance;
        public static IElementViewHolderFactory Instance => _instance ?? (_instance = new DefaultElementViewHolderFactory());

        public ElementViewHolder Create(Context context, LayoutInflater inflater, ViewGroup zoneLayout, IContentElement element)
        {
            if (element is ICommonPart)
            {
                return new CommonPartViewHolder(context, inflater, zoneLayout, element as ICommonPart);
            }
            else if (element is ITitlePart)
            {
                return new TitlePartViewHolder(context, inflater, zoneLayout, element as ITitlePart);
            }
            else if (element is IBodyPart)
            {
                return new BodyPartViewHolder(context, inflater, zoneLayout, element as IBodyPart);
            }
            else if (element is ITermPart)
            {
                return new TermPartViewHolder(context, inflater, zoneLayout, element as ITermPart);
            }
            else if (element is ITaxonomyPart)
            {
                return new TaxonomyPartViewHolder(context, inflater, zoneLayout, element as ITaxonomyPart);
            }
            else if (element is IImagePart)
            {
                return new ImagePartViewHolder(context, inflater, zoneLayout, element as IImagePart);
            }
            else if (element is IBooleanField)
            {
                return new BooleanFieldViewHolder(context, inflater, zoneLayout, element as IBooleanField);
            }
            else if (element is IMediaField)
            {
                return new MediaFieldViewHolder(context, inflater, zoneLayout, element as IMediaField);
            }
            else
            {
                return new ElementViewHolder<IContentElement>(context, inflater, zoneLayout, element);
            }
        }
    }
}