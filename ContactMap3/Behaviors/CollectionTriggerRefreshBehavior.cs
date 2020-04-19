using System;
using Xamarin.Forms;

namespace ContactMap3.Behaviors
{
        /// <summary>
        /// Behavior that sets a CollectionView refresh, on Focus 1time?.
        /// </summary>
        public class CollectionTriggerRefreshBehavior : Behavior<CollectionView>
        {
            CollectionView collectionView;

            protected override void OnAttachedTo(CollectionView bindable)
            {
                base.OnAttachedTo(bindable);
                collectionView  = bindable;
                collectionView.Unfocused += OnFocusedBehavior;
            }

            protected override void OnDetachingFrom(CollectionView bindable)
            {
                base.OnDetachingFrom(bindable);
            //ListView listView;
                collectionView.Unfocused -= OnFocusedBehavior;
                collectionView = null;
            }

            void OnFocusedBehavior (object sender, FocusEventArgs e)
            {
                Console.WriteLine($"Event triggered behavior:{sender}, with arguments{e}");
            }
        }
    }
