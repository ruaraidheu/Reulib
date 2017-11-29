using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ruaraidheulib.Interface.reulib64.Win64.Console
{
    public class CommandParsing
    {
        public static CommandArgs ParseCommandLine(string[] commandline, string subcommandindicator)
        {
            CommandArgs ca = new CommandArgs();
            int lastcom = 0;
            for (int i = 0; i < commandline.Length; i++)
            {
                if (i == 0)
                {
                    ca.command = commandline[i];
                    ca.subcommand.Add(ca.command);
                    ca.args.Add(new List<string>());
                    ca.scbinds.Add(new List<string>());
                    lastcom = 0;
                }
                else
                {
                    if (commandline[i].StartsWith(subcommandindicator))
                    {
                        ca.subcommand.Add(commandline[i].Remove(0, subcommandindicator.Length));
                        ca.args.Add(new List<string>());
                        ca.scbinds.Add(new List<string>());
                        lastcom++;
                    }
                    else
                    {
                        ca.args[lastcom].Add(commandline[i]);
                    }
                }
            }

            return ca;
        }
        public static CommandArgs ParseCommandLine(string[] commandline)
        {
            return ParseCommandLine(commandline, "-");
        }
        public static CommandArgs ParseCommandLine(string commandline)
        {
            return ParseCommandLine(commandline.Split(StringSplitOptions.RemoveEmptyEntries, " "));
        }
        public static CommandArgs AParseCommandLine(string[] commandline, string subcommandindicator)
        {
            CommandArgs ca = new CommandArgs();
            int lastcom = 0;
            ca.command = "";
            ca.subcommand.Add(ca.command);
            ca.args.Add(new List<string>());
            for (int i = 0; i < commandline.Length; i++)
            {
                if (commandline[i].StartsWith(subcommandindicator))
                {
                    ca.subcommand.Add(commandline[i].Remove(0, subcommandindicator.Length));
                    ca.args.Add(new List<string>());
                    lastcom = i+1;
                }
                else
                {
                    ca.args[lastcom+1].Add(commandline[i]);
                }
            }

            return ca;
        }
        public static CommandArgs AParseCommandLine(string[] commandline)
        {
            return ParseCommandLine(commandline, "-");
        }
        public static CommandArgs AParseCommandLine(string commandline)
        {
            return ParseCommandLine(commandline.Split(StringSplitOptions.RemoveEmptyEntries, " "));
        }
    }
    public class CommandArgs
    {
        public string command;
        public List<string> subcommand;
        public List<List<string>> scbinds;
        public List<List<string>> args;
        public bool notrecognised = false;
        public CommandArgs()
        {
            subcommand = new List<string>();
            scbinds = new List<List<string>>();
            args = new List<List<string>>();
        }
        public CommandArgs(string initialcommand, params string[] subcommands)
        {
            command = initialcommand;
            subcommand = subcommands.To1DList();
            subcommand.Insert(0, command);
            args = new List<List<string>>();
            scbinds = new List<List<string>>();
            Loop.For(() =>
            {
                args.Add(new List<string>());
                scbinds.Add(new List<string>());
            }
            , subcommand.Count);
            Loop.For((i)=> { scbinds[i].Add(subcommand[i]); },subcommand.Count);
        }
        public CommandArgs(string initialcommand)
        {
            command = initialcommand;
            subcommand = new List<string>();
            subcommand.Insert(0, command);
            args = new List<List<string>>();
            scbinds = new List<List<string>>();
            Loop.For(() =>
            {
                args.Add(new List<string>());
                scbinds.Add(new List<string>());
            }
            , subcommand.Count);
            Loop.For((i) => { scbinds[i].Add(subcommand[i]); }, subcommand.Count);
        }
        public CommandArgs(string initialcommand, params Subcommand[] subcommands)
        {
            command = initialcommand;
            List<Subcommand> tmp = subcommands.To1DList();
            subcommand = new List<string>();
            Loop.For((i)=>
            {
                subcommand.Add(tmp[i].subcom);
            }
            ,tmp.Count);
            subcommand.Insert(0, command);
            args = new List<List<string>>();
            scbinds = new List<List<string>>();
            Loop.For(() =>
            {
                args.Add(new List<string>());
                scbinds.Add(new List<string>());
            }
            , subcommand.Count);
            Loop.For((i) => { scbinds[i].Add(subcommand[i]); }, subcommand.Count);
            Loop.For((i) =>
            {
                Loop.For(() =>
                {
                    args[i].Add("");
                }
                , tmp[i].arg);
            }
            , args.Count);
        }
        public bool IsSubcommand(string sc, out int loc)
        {
            loc = 0;
            for (int i = 0; i < subcommand.Count; i++)
            {
                if (IsAlias(sc, i))
                {
                    loc = i;
                    return true;
                }
            }
            return false;
        }
        public bool IsSubcommand(string sc)
        {
            for (int i = 0; i < subcommand.Count; i++)
            {
                if (IsAlias(sc, i))
                {
                    return true;
                }
            }
            return false;
        }
        public string GetArg(string subcom, string defaultnoarg, int arg = 0)
        {
            for (int i = 0; i < subcommand.Count; i++)
            {
                if (IsAlias(subcom, i))
                {
                    if (args[i].Count > arg)
                    {
                        return args[i][arg];
                    }
                }
            }
            return defaultnoarg;
        }
        public bool GetArgBool(string subcom, string defaultnoarg, out string retarg, int arg = 0)
        {
            retarg = defaultnoarg;
            for (int i = 0; i < subcommand.Count; i++)
            {
                if (IsAlias(subcom, i))
                {
                    if (args[i].Count > arg)
                    {
                        retarg = args[i][arg];
                        return true;
                    }
                }
            }
            return false;
        }
        public bool IsSub(string subcom)
        {
            for (int i = 0; i < subcommand.Count; i++)
            {
                if (IsAlias(subcom, i))
                {
                    return true;
                }
            }
            return false;
        }
        public void AliasSubcommand(string sc, string alias)
        {
            for (int i = 0; i < subcommand.Count; i++)
            {
                if (sc == subcommand[i])
                {
                    scbinds[i].Add(alias);
                }
            }
        }
        public bool IsAlias(string sc, string listi)
        {
            if (sc == listi)
            {
                return true;
            }
            else
            {
                for(int i = 0; i < subcommand.Count; i++)
                {
                    for (int j = 0; j < scbinds[i].Count; j++)
                    {
                        if (sc == scbinds[i][j])
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }
        public bool IsAlias(string sc, int listi)
        {
            if (sc == subcommand[listi])
            {
                return true;
            }
            else
            {
                for (int j = 0; j < scbinds[listi].Count; j++)
                {
                    if (sc == scbinds[listi][j])
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public struct Subcommand
        {
            public string subcom;
            public int arg;
            public Subcommand(string subcommand, int argcount)
            {
                subcom = subcommand;
                arg = argcount;
            }
        }
    }
    public class CommandLine
    {
        List<CommandArgs> possibles;
        List<List<string>> alias;
        List<Func<CommandArgs, string>> actions;
        bool displine = true;
        bool delagate = true;
        Action<string> wl;
        Action<string> w;
        Func<string> rl;
        public CommandLine(bool usedelagate = true)
        {
            possibles = new List<CommandArgs>();
            alias = new List<List<string>>();
            actions = new List<Func<CommandArgs, string>>();
            delagate = usedelagate;
            wl = (s) => { System.Console.WriteLine(s); };
            w = (s) => { System.Console.Write(s); };
            rl = () => { return System.Console.ReadLine(); };
        }
        public CommandLine(Action<string> WriteLine, Action<string> Write, Func<string> Readline, bool usedelagate = true)
        {
            possibles = new List<CommandArgs>();
            alias = new List<List<string>>();
            actions = new List<Func<CommandArgs, string>>();
            delagate = usedelagate;
            wl = WriteLine;
            w = Write;
            rl = Readline;
        }
        public void Add(CommandArgs ca, Func<CommandArgs, string> del)
        {
            if (delagate)
            {
                possibles.Add(ca);
                alias.Add(new List<string>());
                actions.Add(del);
            }
            else
            {
                possibles.Add(ca);
                alias.Add(new List<string>());
            }
        }
        public void Add(CommandArgs ca)
        {
            if (delagate)
            {
                throw new Exception("Delegate required.");
            }
            else
            {
                possibles.Add(ca);
                alias.Add(new List<string>());
            }
        }
        public CommandArgs Read(string s, out string ret)
        {
            ret = "";
            CommandArgs ca = CommandParsing.ParseCommandLine(s);
            for (int i = 0; i < possibles.Count; i ++)
            {
                if (IsAlias(ca.command, i))
                {
                    for (int j = 0; j<ca.subcommand.Count; j++)
                    {
                        for(int k = 0; k<possibles[i].scbinds.Count;k++)
                        {
                            if (possibles[i].IsAlias(ca.subcommand[j],k))
                            {
                                ca.scbinds[j] = possibles[i].scbinds[k];
                            }
                        }
                    }
                }
            }
            if (delagate)
            {
                for (int i = 0; i < possibles.Count; i ++)
                {
                    if (IsAlias(ca.command, i))
                    {
                        List<int> screm = new List<int>();
                        Loop.For((j)=> 
                        {
                            bool match = false;
                            Loop.For((k)=> 
                            {
                                if (possibles[i].IsAlias(ca.subcommand[j], k)||IsAlias(ca.command, i))
                                {
                                    match = true;
                                }
                            },possibles[i].subcommand.Count);
                            if (match == false)
                            {
                                screm.Add(j);
                            }
                        }, ca.subcommand.Count);
                        Loop.For((j)=> { ca.subcommand.RemoveAt(screm[j]);ca.args.RemoveAt(screm[j]);ca.scbinds.RemoveAt(screm[j]); },screm.Count);
                        ret = actions[i](ca);
                        return ca;
                    }
                }
            }
            else
            {
                return ca;
            }
            ca.notrecognised = true;
            return ca;
        }
        public void Host(bool disableexit = false, bool casesensitive = false, bool displayline = true)
        {
            Host(new List<string>(), disableexit, casesensitive, displayline);
        }
        public void Host(List<string> autoexec, bool disableexit = false, bool casesensitive = false, bool displayline = true)
        {
            if (displine)
            {
                bool hosting = true;
                Add(new CommandArgs("alias"), (t)=> 
                {
                    if (t.args[0].Count >= 2)
                    {
                        AddAlias(t.args[0][0], t.args[0][1]);
                        return "Aliased "+t.args[0][1]+" to "+t.args[0][0]+".";
                    }
                    else
                    {
                        return "Could not alias.";
                    }
                });
                AddAlias("alias", "bind");
                while (hosting)
                {
                    string print;
                    wl("");
                    w(">");
                    CommandArgs c;
                    if (autoexec.Count > 0)
                    {
                        c = Read(autoexec[0], out print);
                        wl(print);
                        autoexec.RemoveAt(0);
                    }
                    else if (casesensitive)
                    {
                        c = Read(rl(), out print);
                        wl(print);
                    }
                    else
                    {
                        c = Read(rl().ToLower(), out print);
                        wl(print);
                    }
                    if (c.notrecognised == true)
                    {
                        if (c.command.ToLower() == "help")
                        {
                            wl("Help:");
                            wl("help");
                            wl("exit");
                            Loop.Foreach<CommandArgs>(possibles, (cm, j) =>
                            {
                                string str = "";
                                Loop.Foreach<string>(cm.subcommand, (sc, i) =>
                                 {
                                     if (i == 0)
                                     {
                                         str += "[BaseCommand-Args: " + cm.args[i].Count + "] ";
                                     }
                                     else
                                     {
                                         str += "[" + sc + /*"-Args: " + cm.args[i].Count +*/ "] ";
                                     }
                                 });
                                wl(cm.command + " " + str);
                            });
                        }
                        else if (c.command.ToLower() == "exit")
                        {
                            if (!disableexit)
                            {
                                wl("Exiting console.");
                                hosting = false;
                            }
                        }
                        else
                        {
                            wl("The command you entered '" + c.command + "' was not recognised.");
                            wl("Try 'help' to find a valid command.");
                        }
                    }
                }
            }
        }
        public void AddAlias(string command, string bind)
        {
            for (int i = 0; i < possibles.Count; i++)
            {
                if (command == possibles[i].command)
                {
                    alias[i].Add(bind);
                }
            }
        }
        public bool IsAlias(string command, string listi)
        {
            if (command == listi)
            {
                return true;
            }
            else
            {
                for (int i = 0; i < possibles.Count; i++)
                {
                    for (int j = 0; j < alias[i].Count; j++)
                    {
                        if (command == alias[i][j])
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }
        public bool IsAlias(string command, int listi)
        {
            if (command == possibles[listi].command)
            {
                return true;
            }
            else
            {
                for (int j = 0; j < alias[listi].Count; j++)
                {
                    if (command == alias[listi][j])
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
    public class StringManager
    {
        string s = "";
        public void WriteLine(string text)
        {
            s += Environment.NewLine + text;
        }
        public void Write(string text)
        {
            s += text;
        }
        public override string ToString()
        {
            return s;
        }
    }
}
