using System;
namespace Simple.Entity.Base
{
    public static class ServiceProviderServiceExtensions
    {
        public static object GetService<T>(this IServiceProvider provider) => provider.GetService(typeof(T));

        internal static void GetService<T>()
        {
            throw new NotImplementedException();
        }
    }
}
