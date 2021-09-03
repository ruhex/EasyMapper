using System.Linq;

namespace EasyMapper
{
    public static class EasyMap
    {
        public static TTarget Map<TTarget>(TTarget target, object source)
        {
            foreach (var prop1 in target.GetType().GetProperties())
            {
                var prop2 = source.GetType().GetProperties().FirstOrDefault(x => x.Name == prop1.Name && x.PropertyType == prop1.PropertyType);
                if (!(prop2 is null))
                    prop1.SetValue(target, prop2.GetValue(source));
            }
            return target;
        }
        public static TTarget Map<TTarget>(object source) where TTarget : new() => Map(new TTarget(), source);
        public static TTarget To<TTarget>(this object source) where TTarget : new() => Map(new TTarget(), source);
    }
}
