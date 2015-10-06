using System;
using System.Reflection;
using CommandLine;
using CommandLine.Text;

namespace DGraph.Core.Import
{
    internal class Options
    {

        [Option('p', "path", Required = false, HelpText = "Start import from root folder. Will consider the first level under root as an application")]
        public string RootPath { get; set; }

        [Option('w', "wipedata", Required = false, HelpText = "Wipes all data from the MongoDB database before importing. Use this for performing a fresh import.")]
        public bool WipeData { get; set; }

        [Option('u', "smartupdate", Required = false, HelpText = "Only imports log entries in each application that are newer than any existing ones. If this is not set and you do not specify --wipedata, you will get duplicate log file entries.")]
        public bool SmartUpdate { get; set; }

        [HelpOption]
        public string GetUsage()
        {
            var help = new HelpText
            {
                Heading = new HeadingInfo("DGraph import tool", Assembly.GetExecutingAssembly().GetName().Version.ToString()),
                Copyright = new CopyrightInfo("R.Florescu", DateTime.Now.Year),
                AdditionalNewLineAfterOption = true,
                AddDashesToOption = true
            };

            help.AddOptions(this);
            return help;
        }
    }
}
