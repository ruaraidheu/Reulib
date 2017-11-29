using W32 = Microsoft.Win32;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ruaraidheulib.Interface.Win32
{
    public class Registry
    {
        public static void SetStartup(string applicationname, string applicationexecutable)
        {
            RegistryKey key = W32.Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            key.SetValue(applicationname, applicationexecutable);
        }
        public static void UnsetStartup(string applicationname)
        {
            RegistryKey key = W32.Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            key.DeleteValue(applicationname);
        }
        public static RegistryKey CreateHKEY_CURRENT_USER(string appname)
        {
            return W32.Registry.CurrentUser.CreateSubKey("SOFTWARE\\"+appname);
        }
        public static RegistryKey CreateHKEY_CURRENT_USER(string group, string appname)
        {
            return W32.Registry.CurrentUser.CreateSubKey("SOFTWARE\\" + group +"\\"+ appname);
        }
        public static RegistryKey CreateHKEY_CURRENT_USER(string enforcedtree, params string[] tree)
        {
            string s = "";
            List <string> ls = tree.To1DList();
            ls.Insert(0, enforcedtree);
            for (int i = 0; i < ls.Count; i++)
            {
                s += "\\" + ls[i];
            }
            return W32.Registry.CurrentUser.CreateSubKey("SOFTWARE" + s);
        }
        public static void CreateOrSetKeyValue(RegistryKey rk, string value, object data, RegistryValueKind kind)
        {
            rk.SetValue(value, data, kind);
        }
        public static void CreateOrSetKeyValue(RegistryKey rk, string value, object data)
        {
            rk.SetValue(value, data);
        }
        public static void RemoveKeyValue(RegistryKey rk, string value)
        {
            rk.DeleteValue(value);
        }
        public static object GetKeyValue(RegistryKey rk, string value)
        {
            return rk.GetValue(value, new NoValue());
        }
        public static void GetKeyValue(RegistryKey rk, string value, Action novalue, Action<object> valueexists)
        {
            object o = rk.GetValue(value, new NoValue());
            if (o is NoValue)
            {
                novalue();
            }
            else
            {
                valueexists(o);
            }
        }
    }
    public class NoValue
    {

    }
}
