using Microsoft.CSharp;
using Ruaraidheulib.Interface.reulib64.Win64.Console;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Ruaraidheulib.Interface.reulib64.Win64.ACPU.CodeDom.Reflection
{
    public class CSPureCompiler
    {

        /// <exception cref="InvalidOperationException">Compiler Error</exception>
        public static CSCompiledAssembly CompileFromScratch(string code, params string[] refassemblies)
        {
            CSharpCodeProvider provider = new CSharpCodeProvider();
            CompilerParameters parameters = new CompilerParameters();
            parameters.ReferencedAssemblies.Add("System.dll");
            foreach (string sref in refassemblies)
            {
                parameters.ReferencedAssemblies.Add(sref);
            }
            parameters.GenerateInMemory = true;
            parameters.GenerateExecutable = false;
            CompilerResults results = provider.CompileAssemblyFromSource(parameters, code);
            if (results.Errors.HasErrors)
            {
                StringBuilder sb = new StringBuilder();

                foreach (CompilerError error in results.Errors)
                {
                    sb.AppendLine(System.String.Format("Error ({0}): {1}", error.ErrorNumber, error.ErrorText));
                }

                throw new InvalidOperationException(sb.ToString());
            }
            Assembly assembly = results.CompiledAssembly;
            return new CSCompiledAssembly(assembly, results, parameters, provider);
        }
        public static void RunFromScratch(string code, params string[] refassemblies)
        {
            CompileFromScratch(code, refassemblies).RunNP();
        }
        public static object RunFromScratch(string code, string _namespace, string _class, string _method, string[] refassemblies, params object[] parameters)
        {
            CSTargetAssembly cta = CompileFromScratch(code, refassemblies);
            cta.Namespace = _namespace;
            cta.Class = _class;
            cta.Method = _method;
            return cta.Run(parameters);
        }
    }

    public class CSStrictAssembly
    {
        Assembly targetassembly;
        public Assembly Assembly
        {
            get { return targetassembly; }
        }
        public CSStrictAssembly(Assembly assembly)
        {
            targetassembly = assembly;
        }
    }
    public class CSTargetAssembly : CSStrictAssembly
    {
        string name;
        string namesp;
        string cla;
        string meth;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Namespace
        {
            get { return namesp; }
            set { namesp = value; }
        }
        public string Class
        {
            get { return cla; }
            set { cla = value; }
        }
        public string Method
        {
            get { return meth; }
            set { meth = value; }
        }
        public CSTargetAssembly(Assembly assembly) : base(assembly)
        {
            namesp = "Generic";
            cla = "Program";
            meth = "Main";
        }
        public void RunNP()
        {
            Type program = Assembly.GetType(namesp + "." + cla);
            MethodInfo main = program.GetMethod(meth);
            main.Invoke(null, null);
        }
        public void RunNP(string method)
        {
            Type program = Assembly.GetType(namesp + "." + cla);
            MethodInfo main = program.GetMethod(method);
            bool match = false;
            foreach (MethodInfo mi in program.GetMethods())
            {
                if (mi.Name == method)
                {
                    match = true;
                    break;
                }
            }
            if (match)
            {
                main.Invoke(null, null);
            }
        }
        public void RunNP(string names, string cl, string method)
        {
            Type program = Assembly.GetType(names + "." + cl);
            MethodInfo main = program.GetMethod(method);
            bool match = false;
            foreach (MethodInfo mi in program.GetMethods())
            {
                if (mi.Name == method)
                {
                    match = true;
                    break;
                }
            }
            if (match)
            {
                main.Invoke(null, null);
            }
        }
        public object GetPropety(string property)
        {
            return GetPropety(namesp, cla, property);
        }
        public object GetPropety(string names, string cl, string property)
        {
            Type program = Assembly.GetType(names + "." + cl);
            PropertyInfo main = program.GetProperty(property);
            bool match = false;
            foreach (PropertyInfo mi in program.GetProperties())
            {
                if (mi.Name == property)
                {
                    match = true;
                    break;
                }
            }
            if (match)
            {
                return main.GetValue(null);
            }
            return null;
        }
        public object GetPropety(string property, object obj)
        {
            return GetPropety(namesp, cla, property, obj);
        }
        public object GetPropety(string names, string cl, string property, object obj)
        {
            Type program = Assembly.GetType(names + "." + cl);
            PropertyInfo main = program.GetProperty(property);
            bool match = false;
            foreach (PropertyInfo mi in program.GetProperties())
            {
                if (mi.Name == property)
                {
                    match = true;
                    break;
                }
            }
            if (match)
            {
                return main.GetValue(obj);
            }
            return null;
        }
        public PropertyInfo[] GetPropeties()
        {
            return GetPropeties(namesp, cla);
        }
        public PropertyInfo[] GetPropeties(string names, string cl)
        {
            Type program = Assembly.GetType(names + "." + cl);
            PropertyInfo[] main = program.GetProperties();
            return main;
        }
        public object GetField(string field)
        {
            return GetField(namesp, cla, field);
        }
        public object GetField(string names, string cl, string field)
        {
            Type program = Assembly.GetType(names + "." + cl);
            FieldInfo main = program.GetField(field);
            bool match = false;
            foreach (FieldInfo mi in program.GetFields())
            {
                if (mi.Name == field)
                {
                    match = true;
                    break;
                }
            }
            if (match)
            {
                return main.GetValue(null);
            }
            return null;
        }
        public object GetField(string field, object obj)
        {
            return GetField(namesp, cla, field, obj);
        }
        public object GetField(string names, string cl, string field, object obj)
        {
            Type program = Assembly.GetType(names + "." + cl);
            FieldInfo main = program.GetField(field);
            bool match = false;
            foreach (FieldInfo mi in program.GetFields())
            {
                if (mi.Name == field)
                {
                    match = true;
                    break;
                }
            }
            if (match)
            {
                return main.GetValue(obj);
            }
            return null;
        }
        public FieldInfo[] GetFields()
        {
            return GetFields(namesp, cla);
        }
        public FieldInfo[] GetFields(string names, string cl)
        {// TODO: Memberinfo too
            Type program = Assembly.GetType(names + "." + cl);
            FieldInfo[] main = program.GetFields();
            return main;
        }
        public object Run(object[] parameters)
        {
            Type program = Assembly.GetType(namesp + "." + cla);
            MethodInfo main = program.GetMethod(meth);
            return main.Invoke(null, parameters);
        }
        public object Run(string method, object[] parameters)
        {
            Type program = Assembly.GetType(namesp + "." + cla);
            MethodInfo main = program.GetMethod(method);
            bool match = false;
            foreach (MethodInfo mi in program.GetMethods())
            {
                if (mi.Name == method)
                {
                    match = true;
                    break;
                }
            }
            if (match)
            {
                return main.Invoke(null, parameters);
            }
            return null;
        }
        public object Run(string names, string cl, string method, object[] parameters)
        {
            Type program = Assembly.GetType(names + "." + cl);
            MethodInfo main = program.GetMethod(method);
            bool match = false;
            foreach (MethodInfo mi in program.GetMethods())
            {
                if (mi.Name == method)
                {
                    match = true;
                    break;
                }
            }
            if (match)
            {
                return main.Invoke(null, parameters);
            }
            return null;
        }
    }
    public class CSCompiledAssembly : CSTargetAssembly
    {
        CompilerResults results;
        CompilerParameters cparams;
        CSharpCodeProvider csprovider;
        public CSCompiledAssembly(Assembly assembly, CompilerResults cresults, CompilerParameters param, CSharpCodeProvider provider) : base(assembly)
        {
            results = cresults;
            cparams = param;
            csprovider = provider;
        }
    }

    public class CSTagCompiler
    {
        /// <exception cref="InvalidOperationException">Compiler Error</exception>
        public static CSCompiledAssembly CompileFromReferencePath(string path)
        {
            ThreeT<string> tt = Ruaraidheulib.Interface.reulib64.IO.FileHelper.SeparatePath(path);
            if (tt.Z == ".dll" || tt.Z == ".lib")
            {
                string text = "";
                if (File.Exists(tt.X + "\\" + tt.Y + ".meta"))
                {
                    text += File.ReadAllText(tt.X + "\\" + tt.Y + ".meta");
                }
                else if (File.Exists(tt.X + "\\" + tt.Y + ".csm"))
                {
                    text += File.ReadAllText(tt.X + "\\" + tt.Y + ".csm");
                }
                else if (File.Exists(tt.X + "\\" + tt.Y + ".csmeta"))
                {
                    text += File.ReadAllText(tt.X + "\\" + tt.Y + ".csmeta");
                }
                return LoadFromLib(path, text);
            }
            else
            {
                string text = File.ReadAllText(tt.X + "\\" + tt.Y + tt.Z);
                if (tt.Z == ".meta" || tt.Z == ".csm" || tt.Z == ".csmeta")
                {
                    return null;
                }
                else
                {
                    if (File.Exists(tt.X + "\\" + tt.Y + ".meta"))
                    {
                        string t2 = File.ReadAllText(tt.X + "\\" + tt.Y + ".meta");
                        text = t2 + text;
                    }
                    else if (File.Exists(tt.X + "\\" + tt.Y + ".csm"))
                    {
                        string t2 = File.ReadAllText(tt.X + "\\" + tt.Y + ".csm");
                        text = t2 + text;
                    }
                    else if (File.Exists(tt.X + "\\" + tt.Y + ".csmeta"))
                    {
                        string t2 = File.ReadAllText(tt.X + "\\" + tt.Y + ".csmeta");
                        text = t2 + text;
                    }
                    return CompileFromScratch(text, tt.Y + tt.Z);
                }
            }
        }
        /// <exception cref="InvalidOperationException">Compiler Error</exception>
        public static CSCompiledAssembly CompileFromScratch(string code)
        {
            return CompileFromScratch(code, "Generic", true);
        }
        public static CSCompiledAssembly CompileFromScratch(string code, string name)
        {
            return CompileFromScratch(code, name, false);
        }
        /// <exception cref="InvalidOperationException">Compiler Error</exception>
        public static CSCompiledAssembly CompileFromScratch(string code, string name, bool nameisnamespace)
        {
            List<string> refassemblies = new List<string>();
            if (TagDecoder.IsTag(code, "lib"))
            {//. Select version of lib, select latest useable version
                string[] data = TagDecoder.WTags(code, "lib", true).Split('|');
                foreach (string strd in data)
                {
                    refassemblies.Add(strd);
                }
                code = TagDecoder.StripTags(code, "lib");
            }

            string nam = name;
            string namesp = "Generic";
            string cla = "Program";
            string method = "Main";
            if (TagDecoder.IsTag(code, "detail"))
            {
                string[] data = TagDecoder.WTags(code, "detail", true).Split('|');
                if (data.Length >= 1)
                {
                    namesp = data[0];
                }
                if (data.Length >= 2)
                {
                    cla = data[1];
                }
                if (data.Length >= 3)
                {
                    method = data[2];
                }
                if (data.Length >= 4)
                {
                    nam = data[3];
                }
                code = TagDecoder.StripTags(code, "detail");
            }
            if (nameisnamespace)
            {
                nam = namesp;
            }

            CSharpCodeProvider provider = new CSharpCodeProvider();
            CompilerParameters parameters = new CompilerParameters();
            parameters.ReferencedAssemblies.Add("System.dll");
            foreach (string sref in refassemblies)
            {// TODO: add tags for reloadable and internal assemblies and meta files for tags .meta .csmeta .csm + run from mods + load dlls .lib + .csmod + .cs
                parameters.ReferencedAssemblies.Add(sref);
            }

            parameters.GenerateInMemory = true;
            parameters.GenerateExecutable = false;
            CompilerResults results = provider.CompileAssemblyFromSource(parameters, code);
            if (results.Errors.HasErrors)
            {
                StringBuilder sb = new StringBuilder();

                foreach (CompilerError error in results.Errors)
                {
                    sb.AppendLine(System.String.Format("Error ({0}): {1} on line {2} column {3}", error.ErrorNumber, error.ErrorText, error.Line, error.Column));
                }

                throw new InvalidOperationException(sb.ToString());
            }
            Assembly assembly = results.CompiledAssembly;

            CSCompiledAssembly csca = new CSCompiledAssembly(assembly, results, parameters, provider);
            csca.Name = nam;
            csca.Namespace = namesp;
            csca.Class = cla;
            csca.Method = method;
            return csca;
        }
        public static CSCompiledAssembly LoadFromLib(string path)
        {
            return LoadFromLib(path, "");
        }
        public static CSCompiledAssembly LoadFromLib(string path, string metafile)
        {
            List<string> refassemblies = new List<string>();
            if (TagDecoder.IsTag(metafile, "lib"))
            {
                string[] data = TagDecoder.WTags(metafile, "lib", true).Split('|');
                foreach (string strd in data)
                {
                    refassemblies.Add(strd);
                }
                metafile = TagDecoder.StripTags(metafile, "lib");
            }

            string namesp = "Generic";
            string cla = "Program";
            string method = "Main";
            if (TagDecoder.IsTag(metafile, "detail"))
            {
                string[] data = TagDecoder.WTags(metafile, "detail", true).Split('|');
                if (data.Length >= 1)
                {
                    namesp = data[0];
                }
                if (data.Length >= 2)
                {
                    cla = data[1];
                }
                if (data.Length >= 3)
                {
                    method = data[2];
                }
                metafile = TagDecoder.StripTags(metafile, "detail");
            }

            Assembly assembly = Assembly.LoadFrom(path);

            CSCompiledAssembly csca = new CSCompiledAssembly(assembly, null, null, null);
            csca.Namespace = namesp;
            csca.Class = cla;
            csca.Method = method;
            return csca;
        }
        public static void RunFromScratch(string code)
        {
            CompileFromScratch(code).RunNP();
        }
        public static object RunFromScratch(string code, params object[] parameters)
        {
            return CompileFromScratch(code).Run(parameters);
        }
        public static object RunFromRefPath(string path, params object[] parameters)
        {
            return CompileFromReferencePath(path).Run(parameters);
        }
    }

    public class REUSTagCompiler
    {
        public static void CompileFromScratch()
        {

        }
    }
}
