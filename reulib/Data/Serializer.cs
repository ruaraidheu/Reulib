using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Ruaraidheulib.Data
{
    public class Serializer
    {
        public string Path { get; set; } = Environment.CurrentDirectory;
        public string Name { get; set; } = "save.xml";
        public bool ReadOnly { get; set; } = false;
        public void SerializeItemUI<T>(T t)
        {
            SerializeItemUI<T>(t, Path, Name, ReadOnly);
        }
        public static void SerializeItemUI<T>(T t, string _path, string _name, bool backup = true, bool readOnly = false)
        {
            if (!readOnly)
            {
                bool? exit = true;
                while (exit == true)
                {
                    exit = null;
                    try
                    {
                        Directory.CreateDirectory(_path);
                        exit = false;
                    }
                    catch (UnauthorizedAccessException)
                    {
                        string dr = Ruaraidheulib.Winforms.MessageBox.Show("Don't have permission to write file to " + _path + _name, "Can't save file", Ruaraidheulib.Winforms.MessageBox.ButtonLayout.Two, Ruaraidheulib.Winforms.MessageBox.ButtonLayout.Two, "Retry", "Ignore");
                        if (dr == "Retry")
                        {
                            exit = true;
                        }
                        else if (dr == "Ignore")
                        {
                            exit = null;
                        }
                    }
                }

                if (exit == false)
                {
                    try
                    {
                        if (backup)
                        {
                            if (File.Exists(_path + _name + ".bak2"))
                            {
                                File.Copy(_path + _name + ".bak2", _path + _name + ".bak3", true);
                            }
                            if (File.Exists(_path + _name + ".bak1"))
                            {
                                File.Copy(_path + _name + ".bak1", _path + _name + ".bak2", true);
                            }
                            if (File.Exists(_path + _name))
                            {
                                File.Copy(_path + _name, _path + _name + ".bak1", true);
                            }
                        }
                        using (FileStream s = new FileStream(_path + _name, FileMode.Create))
                        {
                            bool retry = true;
                            while (retry)
                            {
                                retry = false;
                                try
                                {
                                    new System.Xml.Serialization.XmlSerializer(typeof(T)).Serialize(s, t);
                                }
                                catch (Exception e)
                                {
                                    string dr = "";
                                    if (e.InnerException != null)
                                    {
                                        dr = Ruaraidheulib.Winforms.MessageBox.Show("Can't save file: " + _path + _name + Environment.NewLine + e.Message + Environment.NewLine + e.InnerException.Message + Environment.NewLine + "Retry will try to save file again. Cancel will exit without saving.", "Error", Ruaraidheulib.Winforms.MessageBox.ButtonLayout.Two, Ruaraidheulib.Winforms.MessageBox.ButtonLayout.Two, "Retry", "Don't Save");
                                    }
                                    else
                                    {
                                        dr = Ruaraidheulib.Winforms.MessageBox.Show("Can't save file: " + _path + _name + Environment.NewLine + e.Message, "Error", Ruaraidheulib.Winforms.MessageBox.ButtonLayout.Two, Ruaraidheulib.Winforms.MessageBox.ButtonLayout.Two, "Retry", "Don't Save");
                                    }
                                    if (dr == "Retry")
                                    {
                                        retry = true;
                                    }
                                    else
                                    {
                                        retry = false;
                                    }
                                }
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        Ruaraidheulib.Winforms.MessageBox.Show(Ruaraidheulib.Winforms.MessageBox.ErrorWrite(e));
                    }
                }
            }
        }
        public T DeserializeItemUI<T>()
        {
            return DeserializeItemUI<T>(Path, Name);
        }
        public static T DeserializeItemUI<T>(string _path, string _name, int backup = 1, bool filesexist = false)
        {
            if (File.Exists(_path + _name))
            {
                filesexist = true;
                T t = default;
                try
                {
                    using (FileStream s = new FileStream(_path + _name, FileMode.Open))
                    {
                        t = (T)new System.Xml.Serialization.XmlSerializer(typeof(T)).Deserialize(s);
                    }
                }
                catch (Exception e)
                {
                    string dr;
                    if (e.InnerException != null)
                    {
                        dr = Ruaraidheulib.Winforms.MessageBox.Show("Can't load save file: " + _path + _name + Environment.NewLine + e.Message + Environment.NewLine + e.InnerException.Message + Environment.NewLine, "Error", Ruaraidheulib.Winforms.MessageBox.ButtonLayout.Three, Ruaraidheulib.Winforms.MessageBox.ButtonLayout.Three, "Abort", "Retry", "Load Backup", "Use Defaults");
                    }
                    else
                    {
                        dr = Ruaraidheulib.Winforms.MessageBox.Show("Can't load save file: " + _path + _name + Environment.NewLine + e.Message + Environment.NewLine, "Error", Ruaraidheulib.Winforms.MessageBox.ButtonLayout.Three, Ruaraidheulib.Winforms.MessageBox.ButtonLayout.Three, "Abort", "Retry", "Load Backup", "Use Defaults");
                    }
                    if (dr == "Abort")
                    {
                        //t.ReadOnly = true;
                        //Application.Exit();
                        return default;
                    }
                    else if (dr == "Retry")
                    {
                        t = DeserializeItemUI<T>(_path, _name, backup, filesexist);
                    }
                    else if (dr == "Load Backup")
                    {
                        if (backup > 3)
                        {
                            Ruaraidheulib.Winforms.MessageBox.Show("No valid backup files.");
                        }
                        else
                        {
                            t = DeserializeItemUI<T>(_path, _name + ".bak" + backup.ToString(), backup + 1, filesexist);
                        }
                    }
                }
                return t;
            }
            else
            {
                if (backup > 3)
                {
                    if (filesexist)
                        Ruaraidheulib.Winforms.MessageBox.Show("No valid backup files.");
                }
                else
                {
                    return DeserializeItemUI<T>(_path, _name + ".bak" + backup.ToString(), backup + 1, filesexist);
                }
                return default;
            }
        }

        public void SerializeItemCrypto<T>(T t, string key)
        {
            SerializeItemCrypto<T>(t, key, Path, Name, ReadOnly);
        }
        public static void SerializeItemCrypto<T>(T t, string key, string _path, string _name, bool backup = true, bool readOnly = false)
        {
            if (!readOnly)
            {
                bool? exit = true;
                while (exit == true)
                {
                    exit = null;
                    try
                    {
                        Directory.CreateDirectory(_path);
                        exit = false;
                    }
                    catch (UnauthorizedAccessException)
                    {
                        string dr = Ruaraidheulib.Winforms.MessageBox.Show("Don't have permission to write file to " + _path + System.IO.Path.DirectorySeparatorChar + _name, "Can't save file", Ruaraidheulib.Winforms.MessageBox.ButtonLayout.Two, Ruaraidheulib.Winforms.MessageBox.ButtonLayout.Two, "Retry", "Ignore");
                        if (dr == "Retry")
                        {
                            exit = true;
                        }
                        else if (dr == "Ignore")
                        {
                            exit = null;
                        }
                    }
                }

                if (exit == false)
                {
                    try
                    {
                        if (backup)
                        {
                            if (File.Exists(_path + System.IO.Path.DirectorySeparatorChar + _name + ".bak2"))
                            {
                                File.Copy(_path + System.IO.Path.DirectorySeparatorChar + _name + ".bak2", _path + System.IO.Path.DirectorySeparatorChar + _name + ".bak3", true);
                            }
                            if (File.Exists(_path + System.IO.Path.DirectorySeparatorChar + _name + ".bak1"))
                            {
                                File.Copy(_path + System.IO.Path.DirectorySeparatorChar + _name + ".bak1", _path + System.IO.Path.DirectorySeparatorChar + _name + ".bak2", true);
                            }
                            if (File.Exists(_path + System.IO.Path.DirectorySeparatorChar + _name))
                            {
                                File.Copy(_path + System.IO.Path.DirectorySeparatorChar + _name, _path + System.IO.Path.DirectorySeparatorChar + _name + ".bak1", true);
                            }
                        }
                        using (FileStream s = new FileStream(_path + System.IO.Path.DirectorySeparatorChar + _name, FileMode.Create))
                        {
                            bool retry = true;
                            while (retry)
                            {
                                retry = false;
                                try
                                {
                                    DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                                    des.Key = ASCIIEncoding.ASCII.GetBytes(key);
                                    des.IV = ASCIIEncoding.ASCII.GetBytes(key);
                                    using (CryptoStream cs = new CryptoStream(s, des.CreateEncryptor(), CryptoStreamMode.Write))
                                    {
                                        new System.Xml.Serialization.XmlSerializer(typeof(T)).Serialize(cs, t);
                                    }
                                }
                                catch (Exception e)
                                {
                                    string dr = "";
                                    if (e.InnerException != null)
                                    {
                                        dr = Ruaraidheulib.Winforms.MessageBox.Show("Can't save file: " + _path + System.IO.Path.DirectorySeparatorChar + _name + Environment.NewLine + e.Message + Environment.NewLine + e.InnerException.Message + Environment.NewLine + "Retry will try to save file again. Cancel will exit without saving.", "Error", Ruaraidheulib.Winforms.MessageBox.ButtonLayout.Two, Ruaraidheulib.Winforms.MessageBox.ButtonLayout.Two, "Retry", "Don't Save");
                                    }
                                    else
                                    {
                                        dr = Ruaraidheulib.Winforms.MessageBox.Show("Can't save file: " + _path + System.IO.Path.DirectorySeparatorChar + _name + Environment.NewLine + e.Message, "Error", Ruaraidheulib.Winforms.MessageBox.ButtonLayout.Two, Ruaraidheulib.Winforms.MessageBox.ButtonLayout.Two, "Retry", "Don't Save");
                                    }
                                    if (dr == "Retry")
                                    {
                                        retry = true;
                                    }
                                    else
                                    {
                                        retry = false;
                                    }
                                }
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        Ruaraidheulib.Winforms.MessageBox.Show(Ruaraidheulib.Winforms.MessageBox.ErrorWrite(e));
                    }
                }
            }
        }
        public T DeserializeItemCrypto<T>(string key)
        {
            return DeserializeItemCrypto<T>(key, Path, Name);
        }
        public static T DeserializeItemCrypto<T>(string key, string _path, string _name, int backup = 1, bool filesexist = false)
        {
            if (File.Exists(_path + System.IO.Path.DirectorySeparatorChar + _name))
            {
                filesexist = true;
                T t = default;
                try
                {
                    using (FileStream s = new FileStream(_path + System.IO.Path.DirectorySeparatorChar + _name, FileMode.Open))
                    {
                        DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                        des.Key = ASCIIEncoding.ASCII.GetBytes(key);
                        des.IV = ASCIIEncoding.ASCII.GetBytes(key);
                        using (CryptoStream cs = new CryptoStream(s, des.CreateDecryptor(), CryptoStreamMode.Read))
                        {
                            t = (T)new System.Xml.Serialization.XmlSerializer(typeof(T)).Deserialize(cs);
                        }
                    }
                }
                catch (Exception e)
                {
                    string dr;
                    if (e.InnerException != null)
                    {
                        dr = Ruaraidheulib.Winforms.MessageBox.Show("Can't load save file: " + _path + System.IO.Path.DirectorySeparatorChar + _name + Environment.NewLine+"Is the encryption key correct"+Environment.NewLine + e.Message + Environment.NewLine + e.InnerException.Message + Environment.NewLine, "Error", Ruaraidheulib.Winforms.MessageBox.ButtonLayout.Three, Ruaraidheulib.Winforms.MessageBox.ButtonLayout.Three, "Abort", "Retry", "Load Backup", "Use Defaults");
                    }
                    else
                    {
                        dr = Ruaraidheulib.Winforms.MessageBox.Show("Can't load save file: " + _path + System.IO.Path.DirectorySeparatorChar + _name + Environment.NewLine + e.Message + Environment.NewLine, "Error", Ruaraidheulib.Winforms.MessageBox.ButtonLayout.Three, Ruaraidheulib.Winforms.MessageBox.ButtonLayout.Three, "Abort", "Retry", "Load Backup", "Use Defaults");
                    }
                    if (dr == "Abort")
                    {
                        //t.ReadOnly = true;
                        //Application.Exit();
                        return default;
                    }
                    else if (dr == "Retry")
                    {
                        t = DeserializeItemCrypto<T>(key, _path, System.IO.Path.DirectorySeparatorChar + _name, backup, filesexist);
                    }
                    else if (dr == "Load Backup")
                    {
                        if (backup > 3)
                        {
                            Ruaraidheulib.Winforms.MessageBox.Show("No valid backup files.");
                        }
                        else
                        {
                            t = DeserializeItemCrypto<T>(key, _path, System.IO.Path.DirectorySeparatorChar + _name + ".bak" + backup.ToString(), backup + 1, filesexist);
                        }
                    }
                }
                return t;
            }
            else
            {
                if (backup > 3)
                {
                    if (filesexist)
                        Ruaraidheulib.Winforms.MessageBox.Show("No valid backup files.");
                }
                else
                {
                    return DeserializeItemCrypto<T>(key, _path, System.IO.Path.DirectorySeparatorChar + _name + ".bak" + backup.ToString(), backup + 1, filesexist);
                }
                return default;
            }
        }

    }
}
