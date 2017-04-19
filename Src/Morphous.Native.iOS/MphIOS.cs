﻿using System;
using System.Collections.Generic;
using Foundation;
using Morphous.Native.iOS.UI;
using Morphous.Native.Models;
using UIKit;

namespace Morphous.Native.iOS
{
    public enum ContentItemViewControllerType
    {
        Stacked,
        Table
    }

    public static class MphIOS
    {
        private static readonly IDictionary<string, Func<int, UIViewController>> _typesDictionary = new Dictionary<string, Func<int, UIViewController>>();


        public static void AddViewControllerSelector(string contentType, ContentItemViewControllerType contentItemViewControllerType)
        {
            switch (contentItemViewControllerType)
            {
                case ContentItemViewControllerType.Stacked:
                    AddViewControllerSelector(contentType, (id) => StackedContentItemViewController(id));
                    break;
                case ContentItemViewControllerType.Table:
                    AddViewControllerSelector(contentType, (id) => TableContentItemViewController(id));
                    break;
            }
        }

        public static void AddViewControllerSelector(string contentType, Func<int, UIViewController> factory)
        {
             _typesDictionary[contentType] = factory;
        }


        public static UIViewController ContentItemViewController(IContentItem contentItem)
        {
            if (_typesDictionary.ContainsKey(contentItem.ContentType))
            {
                return _typesDictionary[contentItem.ContentType](contentItem.Id);
            }
            else
            {
                return StackedContentItemViewController(contentItem.Id);
            }
        }



        public static UIStoryboard ContentStoryboard => UIStoryboard.FromName("Content", NSBundle.MainBundle);

        public static StackedContentItemViewController StackedContentItemViewController()
        {
            return (StackedContentItemViewController)ContentStoryboard.InstantiateViewController("StackedContentItemViewController");
        }

        public static StackedContentItemViewController StackedContentItemViewController(int contentItemId)
        {
            var viewController = StackedContentItemViewController();
            viewController.ContentItemId = contentItemId;
            return viewController;
        }

        public static TableContentItemViewController TableContentItemViewController()
        {
            return (TableContentItemViewController)ContentStoryboard.InstantiateViewController("TableContentItemViewController");
        }

        public static TableContentItemViewController TableContentItemViewController(int contentItemId)
        {
        	var viewController = TableContentItemViewController();
        	viewController.ContentItemId = contentItemId;
        	return viewController;
        }
    }
}
