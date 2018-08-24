using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Schema;

namespace Ruaraidheulib.Interface.reulib64.Win64.Version
{
    public struct VersionInfo
    {
        public static VersionInformation Get()
        {
            return new VersionInformation(Assembly.GetCallingAssembly(), Assembly.GetExecutingAssembly());
        }
    }
    public class VersionInformation
    {
        private Assembly calling;
        private Assembly executing;
        private string versionnumber;
        private string specifier;
        private string assemblyversion;
        private string libraryversion;
        private string productversion;
        private string productname;
        private string suitename;
        private string version;
        private string fullversion;
        public static VersionInformation Get()
        {
            return new VersionInformation(Assembly.GetCallingAssembly(), Assembly.GetExecutingAssembly());
        }
        public VersionInformation()
        {
            Constructor(Assembly.GetCallingAssembly(), Assembly.GetExecutingAssembly());
        }
        internal VersionInformation(Assembly callingassembly, Assembly executingassembly)
        {
            Constructor(callingassembly, executingassembly);
        }
        internal void Constructor(Assembly callingassembly, Assembly executingassembly)
        {
            calling = callingassembly;
            executing = executingassembly;
            versionnumber = calling.GetCustomAttribute(typeof(TargetVersionAttribute)).ToString();
            specifier = calling.GetCustomAttribute(typeof(VersionSpecifierAttribute)).ToString();
            assemblyversion = calling.GetName().Version.ToString();
            libraryversion = executing.GetName().Version.ToString();
            productversion = Application.ProductVersion;
            productname = Application.ProductName;
            suitename = "";
            version = "V" + versionnumber + " " + specifier;
            if (VersionNumber != ProductVersion)
            {
                fullversion = "V" + ProductVersion + "   Release: " + Version;
            }
            else
            {
                fullversion = "V" + VersionNumber;
            }
        }
        public string VersionNumber { get { return versionnumber; } }
        public string Specifier { get { return specifier; } }
        public string AssemblyVersion { get { return assemblyversion; } }
        public string LibraryVersion { get { return libraryversion; } }
        public string ProductVersion { get { return productversion; } }
        public string ProductName { get { return productname; } }
        public string SuiteName { get { return suitename; } }
        public string Version { get { return version; } }
        public string FullVersion { get { return fullversion; } }
    }
    [AttributeUsage(AttributeTargets.Assembly)]
    public class TargetVersionAttribute : Attribute
    {
        string text;
        public TargetVersionAttribute() : this(string.Empty) { }
        public TargetVersionAttribute(string txt) { text = txt; }

        public string Text { get => text; set => text = value; }

        public override string ToString()
        {
            return Text;
        }
    }
    [AttributeUsage(AttributeTargets.Assembly)]
    public class VersionSpecifierAttribute : Attribute
    {
        string text;
        public VersionSpecifierAttribute() : this(string.Empty) { }
        public VersionSpecifierAttribute(string txt) { text = txt; }

        public string Text { get => text; set => text = value; }

        public override string ToString()
        {
            return Text;
        }
    }
    [Serializable]
    public class Version : ICloneable, IComparable
    {
        private int major;
        private int minor;
        private int build;
        private int revision;
        /// <summary>
        /// Gets the major.
        /// </summary>
        /// <value></value>
        public int Major
        {
            get
            {
                return major;
            }
            set
            {
                major = value;
            }
        }
        /// <summary>
        /// Gets the minor.
        /// </summary>
        /// <value></value>
        public int Minor
        {
            get
            {
                return minor;
            }
            set
            {
                minor = value;
            }
        }
        /// <summary>
        /// Gets the build.
        /// </summary>
        /// <value></value>
        public int Build
        {
            get
            {
                return build;
            }
            set
            {
                build = value;
            }
        }
        /// <summary>
        /// Gets the revision.
        /// </summary>
        /// <value></value>
        public int Revision
        {
            get
            {
                return revision;
            }
            set
            {
                revision = value;
            }
        }

        public bool XmlObject => false;

        /// <summary>
        /// Creates a new <see cref="ModuleVersion"/> instance.
        /// </summary>
        public Version()
        {
            this.build = -1;
            this.revision = -1;
            this.major = 0;
            this.minor = 0;
        }
        /// <summary>
        /// Creates a new <see cref="ModuleVersion"/> instance.
        /// </summary>
        /// <param name="version">Version.</param>
        public Version(string version)
        {
            this.build = -1;
            this.revision = -1;
            if (version == null)
            {
                throw new ArgumentNullException("version");
            }
            char[] chArray1 = new char[1] { '.' };
            string[] textArray1 = version.Split(chArray1);
            int num1 = textArray1.Length;
            if ((num1 < 2) || (num1 > 4))
            {
                throw new ArgumentException("Arg_VersionString");
            }
            this.major = int.Parse(textArray1[0], CultureInfo.InvariantCulture);
            if (this.major < 0)
            {
                throw new ArgumentOutOfRangeException("version", "ArgumentOutOfRange_Version");
            }
            this.minor = int.Parse(textArray1[1], CultureInfo.InvariantCulture);
            if (this.minor < 0)
            {
                throw new ArgumentOutOfRangeException("version", "ArgumentOutOfRange_Version");
            }
            num1 -= 2;
            if (num1 > 0)
            {
                this.build = int.Parse(textArray1[2], CultureInfo.InvariantCulture);
                if (this.build < 0)
                {
                    throw new ArgumentOutOfRangeException("build", "ArgumentOutOfRange_Version");
                }
                num1--;
                if (num1 > 0)
                {
                    this.revision = int.Parse(textArray1[3], CultureInfo.InvariantCulture);
                    if (this.revision < 0)
                    {
                        throw new ArgumentOutOfRangeException("revision", "ArgumentOutOfRange_Version");
                    }
                }
            }
        }
        public static Version GetCurrentVersion()
        {
            return Application.ProductVersion;
        }
        /// <summary>
        /// Creates a new <see cref="ModuleVersion"/> instance.
        /// </summary>
        /// <param name="major">Major.</param>
        /// <param name="minor">Minor.</param>
        public Version(int major, int minor)
        {
            this.build = -1;
            this.revision = -1;
            if (major < 0)
            {
                throw new ArgumentOutOfRangeException("major", "ArgumentOutOfRange_Version");
            }
            if (minor < 0)
            {
                throw new ArgumentOutOfRangeException("minor", "ArgumentOutOfRange_Version");
            }
            this.major = major;
            this.minor = minor;
            this.major = major;
        }
        /// <summary>
        /// Creates a new <see cref="ModuleVersion"/> instance.
        /// </summary>
        /// <param name="major">Major.</param>
        /// <param name="minor">Minor.</param>
        /// <param name="build">Build.</param>
        public Version(int major, int minor, int build)
        {
            this.build = -1;
            this.revision = -1;
            if (major < 0)
            {
                throw new ArgumentOutOfRangeException("major", "ArgumentOutOfRange_Version");
            }
            if (minor < 0)
            {
                throw new ArgumentOutOfRangeException("minor", "ArgumentOutOfRange_Version");
            }
            if (build < 0)
            {
                throw new ArgumentOutOfRangeException("build", "ArgumentOutOfRange_Version");
            }
            this.major = major;
            this.minor = minor;
            this.build = build;
        }
        /// <summary>
        /// Creates a new <see cref="ModuleVersion"/> instance.
        /// </summary>
        /// <param name="major">Major.</param>
        /// <param name="minor">Minor.</param>
        /// <param name="build">Build.</param>
        /// <param name="revision">Revision.</param>
        public Version(int major, int minor, int build, int revision)
        {
            this.build = -1;
            this.revision = -1;
            if (major < 0)
            {
                throw new ArgumentOutOfRangeException("major", "ArgumentOutOfRange_Version");
            }
            if (minor < 0)
            {
                throw new ArgumentOutOfRangeException("minor", "ArgumentOutOfRange_Version");
            }
            if (build < 0)
            {
                throw new ArgumentOutOfRangeException("build", "ArgumentOutOfRange_Version");
            }
            if (revision < 0)
            {
                throw new ArgumentOutOfRangeException("revision", "ArgumentOutOfRange_Version");
            }
            this.major = major;
            this.minor = minor;
            this.build = build;
            this.revision = revision;
        }
        #region ICloneable Members
        /// <summary>
        /// Clones this instance.
        /// </summary>
        /// <returns></returns>
        public object Clone()
        {
            Version version1 = new Version();
            version1.major = this.major;
            version1.minor = this.minor;
            version1.build = this.build;
            version1.revision = this.revision;
            return version1;
        }
        #endregion
        #region IComparable Members
        /// <summary>
        /// Compares to.
        /// </summary>
        /// <param name="obj">Obj.</param>
        /// <returns></returns>
        public int CompareTo(object version)
        {
            if (version == null)
            {
                return 1;
            }
            if (!(version is Version))
            {
                throw new ArgumentException("Arg_MustBeVersion");
            }
            Version version1 = (Version)version;
            if (this.major != version1.Major)
            {
                if (this.major > version1.Major)
                {
                    return 1;
                }
                return -1;
            }
            if (this.minor != version1.Minor)
            {
                if (this.minor > version1.Minor)
                {
                    return 1;
                }
                return -1;
            }
            if (this.build != version1.Build)
            {
                if (this.build > version1.Build)
                {
                    return 1;
                }
                return -1;
            }
            if (this.revision == version1.Revision)
            {
                return 0;
            }
            if (this.revision > version1.Revision)
            {
                return 1;
            }
            return -1;
        }
        #endregion
        /// <summary>
        /// Equalss the specified obj.
        /// </summary>
        /// <param name="obj">Obj.</param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if ((obj == null) || !(obj is Version))
            {
                return false;
            }
            Version version1 = (Version)obj;
            if (((this.major == version1.Major) && (this.minor == version1.Minor)) && (this.build == version1.Build) && (this.revision == version1.Revision))
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// Gets the hash code.
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            int num1 = 0;
            num1 |= ((this.major & 15) << 0x1c);
            num1 |= ((this.minor & 0xff) << 20);
            num1 |= ((this.build & 0xff) << 12);
            return (num1 | this.revision & 0xfff);
        }
        /// <summary>
        /// Operator ==s the specified v1.
        /// </summary>
        /// <param name="v1">V1.</param>
        /// <param name="v2">V2.</param>
        /// <returns></returns>
        public static bool operator ==(Version v1, Version v2)
        {
            return v1.Equals(v2);
        }
        /// <summary>
        /// Operator &gt;s the specified v1.
        /// </summary>
        /// <param name="v1">V1.</param>
        /// <param name="v2">V2.</param>
        /// <returns></returns>
        public static bool operator >(Version v1, Version v2)
        {
            return (v2 < v1);
        }
        /// <summary>
        /// Operator &gt;=s the specified v1.
        /// </summary>
        /// <param name="v1">V1.</param>
        /// <param name="v2">V2.</param>
        /// <returns></returns>
        public static bool operator >=(Version v1, Version v2)
        {
            return (v2 <= v1);
        }
        /// <summary>
        /// Operator !=s the specified v1.
        /// </summary>
        /// <param name="v1">V1.</param>
        /// <param name="v2">V2.</param>
        /// <returns></returns>
        public static bool operator !=(Version v1, Version v2)
        {
            return (v1 != v2);
        }
        /// <summary>
        /// Operator &lt;s the specified v1.
        /// </summary>
        /// <param name="v1">V1.</param>
        /// <param name="v2">V2.</param>
        /// <returns></returns>
        public static bool operator <(Version v1, Version v2)
        {
            if (v1 == null)
            {
                throw new ArgumentNullException("v1");
            }
            return (v1.CompareTo(v2) < 0);
        }
        /// <summary>
        /// Operator &lt;=s the specified v1.
        /// </summary>
        /// <param name="v1">V1.</param>
        /// <param name="v2">V2.</param>
        /// <returns></returns>
        public static bool operator <=(Version v1, Version v2)
        {
            if (v1 == null)
            {
                throw new ArgumentNullException("v1");
            }
            return (v1.CompareTo(v2) <= 0);
        }
        public static implicit operator Version(System.Version v)
        {
            return new Version(v.Major, v.Minor, v.Build, v.Revision);
        }
        public static implicit operator System.Version(Version v)
        {
            return new System.Version(v.Major, v.Minor, v.Build, v.Revision);
        }
        public static implicit operator Version(string v)
        {
            return new Version(v);
        }
        public static implicit operator string(Version v)
        {
            return v.ToString();
        }
        /// <summary>
        /// Toes the string.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            if (this.build == -1)
            {
                return this.ToString(2);
            }
            if (this.revision == -1)
            {
                return this.ToString(3);
            }
            return this.ToString(4);
        }
        /// <summary>
        /// Toes the string.
        /// </summary>
        /// <param name="fieldCount">Field count.</param>
        /// <returns></returns>
        public string ToString(int fieldCount)
        {
            object[] objArray1;
            switch (fieldCount)
            {
                case 0:
                    {
                        return string.Empty;
                    }
                case 1:
                    {
                        return (this.major.ToString());
                    }
                case 2:
                    {
                        return (this.major.ToString() + "." + this.minor.ToString());
                    }
            }
            if (this.build == -1)
            {
                throw new ArgumentException(string.Format("ArgumentOutOfRange_Bounds_Lower_Upper {0},{1}", "0", "2"), "fieldCount");
            }
            if (fieldCount == 3)
            {
                objArray1 = new object[5] { this.major, ".", this.minor, ".", this.build };
                return string.Concat(objArray1);
            }
            if (this.revision == -1)
            {
                throw new ArgumentException(string.Format("ArgumentOutOfRange_Bounds_Lower_Upper {0},{1}", "0", "3"), "fieldCount");
            }
            if (fieldCount == 4)
            {
                objArray1 = new object[7] { this.major, ".", this.minor, ".", this.build, ".", this.revision };
                return string.Concat(objArray1);
            }
            throw new ArgumentException(string.Format("ArgumentOutOfRange_Bounds_Lower_Upper {0},{1}", "0", "4"), "fieldCount");
        }

        public void FromString(string s)
        {
            Version v = s;
            Major = v.Major;
            Minor = v.Minor;
            Build = v.Build;
            Revision = v.Revision;
        }

        public void ToXml(XmlNode x)
        {
            x.InnerText = this.ToString();
        }

        public void FromXml(XmlNode x)
        {
            throw new NotImplementedException();
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            throw new NotImplementedException();
        }

        public XmlSchema GetSchema()
        {
            throw new NotImplementedException();
        }

        public void ReadXml(XmlReader reader)
        {
            throw new NotImplementedException();
        }

        public void WriteXml(XmlWriter writer)
        {
            throw new NotImplementedException();
        }
    }
}
