using System.Reflection;

namespace EasyMapper
{
    public static class EasyMap<TTarget> where TTarget : new()
    {
        public static TTarget Map(object target, object source)
        {
            foreach (PropertyInfo pro1 in target.GetType().GetProperties())
                foreach (PropertyInfo pro2 in source.GetType().GetProperties())
                    if (pro1.PropertyType == pro2.PropertyType)
                        if (pro1.Name == pro2.Name)
                            pro1.SetValue(target, pro2.GetValue(source));
            return (TTarget)target;
        }
        public static TTarget Map(object source) => Map(new TTarget(), source);
    } 
}
