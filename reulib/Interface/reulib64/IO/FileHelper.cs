using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ruaraidheulib.Interface.reulib64.IO
{
    class FileHelper
    {
        public static ThreeT<string> SeparatePath(string path, int referencedepth, string defaultfilename, string defaultextention, string defaultpath, bool supresserror, params string[] referenceextentions)
        {
            bool foundcode = false;

            int depth = referencedepth;
            string loadname = defaultfilename;
            string exten = defaultextention;
            string pth = defaultpath;


            while (!foundcode)
            {
                if (path.IsStartAndRemove(out path, "::"))
                {
                    path = path.Replace("/", "\\");
                    string[] fp = path.Split(".");
                    if (fp.Length >= 2)
                    {
                        exten = "." + fp.Last();
                        path = path.IfEndAndRemove(exten);
                        fp = new string[0];
                        fp = path.Split("\\");
                        if (fp.Length >= 2)
                        {
                            loadname = fp.Last();
                            path = path.IfEndAndRemove("\\" + loadname);
                            pth += "\\" + path;
                        }
                        else
                        {
                            loadname = path;
                        }
                    }
                    else
                    {
                        fp = new string[0];
                        fp = path.Split("\\");
                        if (fp.Length >= 2)
                        {
                            loadname = fp.Last();
                            path = path.IfEndAndRemove("\\" + loadname);
                            pth += "\\" + path;
                        }
                        else
                        {
                            loadname = path;
                        }
                    }
                }
                else
                {
                    path = path.Replace("/", "\\");
                    string[] fp = path.Split(".");
                    if (fp.Length >= 2)
                    {
                        exten = "." + fp.Last();
                        path = path.IfEndAndRemove(exten);
                        fp = new string[0];
                        fp = path.Split("\\");
                        if (fp.Length >= 2)
                        {
                            loadname = fp.Last();
                            path = path.IfEndAndRemove("\\" + loadname);
                            pth = path;
                        }
                        else
                        {
                            loadname = path;
                        }
                    }
                    else
                    {
                        fp = new string[0];
                        fp = path.Split("\\");
                        if (fp.Length >= 2)
                        {
                            loadname = fp.Last();
                            path = path.IfEndAndRemove("\\" + loadname);
                            pth = path;
                        }
                        else
                        {
                            loadname = path;
                        }
                    }
                }

                bool isexten = false;
                for (int i = 0; i < referenceextentions.Length; i++)
                {
                    if (exten == referenceextentions[i])
                    {
                        isexten = true;
                        break;
                    }
                }
                if (!isexten)
                {
                    foundcode = true;
                }
                else
                {
                    try
                    {
                        string[] tmpl = File.ReadAllLines(pth + "\\" + loadname + exten);
                        if (tmpl.Length >= 1)
                        {
                            path = tmpl[0];
                        }
                    }
                    catch (Exception e)
                    {
                        if (supresserror)
                        {
                            foundcode = true;
                            return new ThreeT<string>(pth + "\\", loadname, exten);
                        }
                        else
                        {
                            foundcode = true;
                            throw e;
                        }
                    }
                }
                if (depth == -2)
                {
                    foundcode = true;
                    return new ThreeT<string>(pth + "\\", loadname, exten);
                }
                else if (depth == -1)
                { /*Do Nothing*/}
                else if (depth < 1)
                {
                    if (supresserror)
                    {
                        foundcode = true;
                        return new ThreeT<string>(pth + "\\", loadname, exten);
                    }
                    else
                    {
                        foundcode = true;
                        throw new LoopLengthException();
                    }
                }
                else
                {
                    depth--;
                }
            }

            ThreeT<string> ret = new ThreeT<string>(pth + "\\", loadname, exten);
            return ret;
        }
        public static ThreeT<string> SeparatePath(string path, int referencedepth, params string[] referenceextentions)
        {
            return SeparatePath(path, referencedepth, "", "", "", true, referenceextentions);
        }
        public static ThreeT<string> SeparatePath(string path)
        {
            return SeparatePath(path, 100, ".ovr", ".reuref");
        }
        public static ThreeT<string> SeparatePath(string path, string defaultfilename, string defaultextention, string defaultpath, bool supresserror)
        {
            return SeparatePath(path, 100 , defaultfilename, defaultextention, defaultpath, supresserror, ".ovr", ".reuref");
        }
    }
}
