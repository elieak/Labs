using System;
using System.Diagnostics;
using System.Linq;

namespace LINQToObjects.Extensions
{
    public static class ExtensionClass
    {
        public static bool CanAccess(this Process p)
        {
            try
            {
                return p.Handle != IntPtr.Zero;
            }
            catch
            {
                return false;
            }
        }
        public static void CopyTo(this object obj, object obj2)
        {
            var properties = from process in obj.GetType().GetProperties()
                        from process2 in obj2.GetType().GetProperties()
                        where process.Name == process2.Name && 
                              process.CanRead && 
                              process2.CanWrite &&
                              process.PropertyType == process2.PropertyType
                        select new
                        {
                            ObjProperties = process,
                            Obj2Properties = process2
                        };
            foreach (var property in properties)
            {
                property.Obj2Properties.SetValue(obj2, property.ObjProperties.GetValue(obj, null), null);
            }

        }

    }
}
