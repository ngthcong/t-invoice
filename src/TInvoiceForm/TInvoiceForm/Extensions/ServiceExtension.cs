using System;
using System.Collections.Generic;
using System.Text;

namespace TInvoiceForm.Extensions
{
    public static class ServiceExtension
    {
        public static T GetService<T>(this IServiceProvider provider) => (T)provider.GetService(typeof(T));
    }
}
