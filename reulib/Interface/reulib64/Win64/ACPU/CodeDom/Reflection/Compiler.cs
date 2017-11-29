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
        string namesp;
        string cla;
        string meth;
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
        public CSTargetAssembly(Assembly assembly) : base (assembly)
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
        public object Run(object[] parameters)
        {
            Type program = Assembly.GetType(namesp + "." + cla);
            MethodInfo main = program.GetMethod(meth);
            return main.Invoke(null, parameters);
        }
    }
    public class CSCompiledAssembly : CSTargetAssembly
    {
        CompilerResults results;
        CompilerParameters cparams;
        CSharpCodeProvider csprovider;
        public CSCompiledAssembly(Assembly assembly, CompilerResults cresults, CompilerParameters param, CSharpCodeProvider provider) : base (assembly)
        {
            results = cresults;
            cparams = param;
            csprovider = provider;
        }
    }

    public class CSTagCompiler
    {
        public static CSCompiledAssembly CompileFromReferencePath(string path)
        {
            ThreeT<string> tt = Ruaraidheulib.Interface.reulib64.IO.FileHelper.SeparatePath(path);
            return CompileFromScratch(File.ReadAllText(tt.X +"\\"+ tt.Y + tt.Z));
        }
        public static CSCompiledAssembly CompileFromScratch(string code)
        {
            List<string> refassemblies = new List<string>();
            if (TagDecoder.IsTag(code, "lib"))
            {
                string[] data = TagDecoder.WTags(code, "lib", true).Split('|');
                foreach (string strd in data)
                {
                    refassemblies.Add(strd);
                }
                code = TagDecoder.StripTags(code, "lib");
            }

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
                else if (data.Length >= 2)
                {
                    cla = data[1];
                }
                else if (data.Length >= 3)
                {
                    method = data[2];
                }
                code = TagDecoder.StripTags(code, "detail");
            }

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

            CSCompiledAssembly csca = new CSCompiledAssembly(assembly, results, parameters, provider);
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
