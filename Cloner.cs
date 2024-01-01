namespace Raven.Util {
    public static class Cloner {
        public static TTarget? Clone<TSource, TTarget> (TSource source) where TSource : class where TTarget : class, new() {
            var sourceType = typeof (TSource);
            var targetType = typeof (TTarget);

            // Add a check for inheritance here
            if (!typeof (TSource).IsAssignableFrom (targetType)) {
                throw new InvalidOperationException ($"Source {typeof (TTarget).FullName} must must be a derived type of {typeof (TSource).FullName}.");
            }

            var targetInstance = Activator.CreateInstance (targetType);

            var properties = sourceType.GetProperties ();

            foreach (var property in properties) {
                var targetProperty = targetType.GetProperty (property.Name);
                if (targetProperty != null) {
                    var value = property.GetValue (source);
                    targetProperty.SetValue (targetInstance, value);
                }
            }

            return targetInstance as TTarget;
        }
    }
}
