using System;
using System.Windows;

namespace Game
{
    public abstract class BaseAttachedProperty<Parent, Property>
        where Parent : BaseAttachedProperty<Parent, Property>, new()
    {
        #region Public Properties

        public static Parent Instance { set; private get; } = new Parent();

        #endregion

        #region Attached Property Definitions

        public static readonly DependencyProperty ValueProperty = DependencyProperty.RegisterAttached("Value", typeof(Property), typeof(BaseAttachedProperty<Parent, Property>), new PropertyMetadata(new PropertyChangedCallback(OnValuePropertyChanged)));
        
        private static void OnValuePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            Instance.OnValueChanged(d, e);

            Instance.ValueChanged(d, e);
        }

        public static Property GetValue(DependencyObject d)
        {
            return (Property)d.GetValue(ValueProperty);
        }

        public static void SetValue(DependencyObject d, Property value)
        {
            d.SetCurrentValue(ValueProperty, value);
        }

        #endregion

        #region Public Events

        public event Action<DependencyObject, DependencyPropertyChangedEventArgs> ValueChanged = (sender, e) => { };

        #endregion

        #region Event Methods

        public virtual void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {

        }

        #endregion


    }
}
