﻿using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SR.Xam.Sample.Helpers
{
    public static class ObservableExtension
    {
        public static ObservableCollection<T> ToObservableCollection<T>(this IEnumerable<T> source)
        {
            try
            {
                ObservableCollection<T> collection = new ObservableCollection<T>();

                foreach (T item in source)
                {
                    collection.Add(item);
                }

                return collection;
            }
            catch (System.Exception)
            {
                return new ObservableCollection<T>();
            }

        }
    }
}