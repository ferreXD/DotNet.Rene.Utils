﻿using System;
using System.Collections.Generic;


// ReSharper disable once CheckNamespace
namespace System.Collections.Generic
{
    public static class EnumerableExtensions
    {
        /// <summary>
        /// Extend internal ForEach Method add item index to action callback
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="action"></param>
        public static void ForEach<T>(this IEnumerable<T> source, Action<T, int> action)
        {
            var i = 0;
            foreach (var item in source)
            {
                action(item,i);
                i++;
            }
        }


        /// <summary>
        /// Get ListItems after apply action to each item
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        public static IEnumerable<T> SelectEach<T>(this IEnumerable<T> source, Action<T> action)
        {
            foreach (var item in source)
            {
                action(item);

                yield return item;
            }
        }

        /// <summary>
        /// Add element at first position
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="item"></param>
        /// <returns></returns>
        public static IEnumerable<T> Prepend<T>(this IEnumerable<T> source, T item)
        {
            yield return item;
            foreach (T l in source)
            {
                yield return l;
            }
        }


        /// <summary>
        /// Add element at last position
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="item"></param>
        /// <returns></returns>
        public static IEnumerable<T> Append<T>(this IEnumerable<T> list, T item)
        {
        
            foreach (T l in list)
            {
                yield return l;
            }

            yield return item;
        }
    }
}