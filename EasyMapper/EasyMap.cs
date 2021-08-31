namespace EasyMapper
{
    public static class EasyMap
    {
        public static TTarget Map<TTarget>(TTarget target, object source)
        {
            foreach (var pro1 in target.GetType().GetProperties())
                foreach (var pro2 in source.GetType().GetProperties())
                    if (pro1.Name == pro2.Name)
                        if (pro1.PropertyType == pro2.PropertyType)
                            pro1.SetValue(target, pro2.GetValue(source));
            return target;
        }
        public static TTarget Map<TTarget>(object source) where TTarget : new() => Map(new TTarget(), source);
    } 
}
