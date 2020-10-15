using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace UploadDaemon.SymbolAnalysis
{
    [XmlRoot("report", IsNullable = false)]
    public class JacocoReport
    {
        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlElement("sessioninfo")]
        public JacocoSessionInfo[] SessionInfos { get; set; }
        [XmlElement("package")]
        public JacocoPackage[] Packages { get; set; }
        [XmlElement("counter")]
        public JacocoCounter[] Counters { get; set; }
    }

    [XmlRoot("sessioninfo")]
    public class JacocoSessionInfo
    {
        [XmlAttribute("id")]
        public string Id { get; set; }

        [XmlAttribute("start")]
        public string Start { get; set; }

        [XmlAttribute("dump")]
        public string Dump { get; set; }
    }


    public class JacocoGroup
    {
    }


    public class JacocoPackage
    {
        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlElement("sourcefile")]
        public List<JacocoSourceFile> SourceFiles { get; set; }
        [XmlElement("counter")]
        public List<JacocoCounter> Counters { get; set; }
    }

    public class JacocoClass
    {
    }

    public class JacocoMethod
    {
    }

    public class JacocoSourceFile
    {
        [XmlAttribute("name")]
        public string Name { get; set; }
        [XmlElement("line")]
        public List<JacocoLine> Lines { get; set; }
        [XmlElement("counter")]
        public List<JacocoCounter> Counters { get; set; }
    }

    public class JacocoLine
    {
        [XmlAttribute("nr")]
        public int Nr { get; set; } = 0;
        [XmlAttribute("mi")]
        public int Mi { get; set; } = 0;
        [XmlAttribute("ci")]
        public int Ci { get; set; } = 0;
        [XmlAttribute("mb")]
        public int Mb { get; set; } = 0;
        [XmlAttribute("cb")]
        public int Cb { get; set; } = 0;
    }

    public class Jacoco
    {
    }

    public class JacocoCounter
    {
        [XmlAttribute("type")]
        public JacocoCounterTypeEnum Type { get; set; }

        [XmlAttribute("missed")]
        public string Missed { get; set; }

        [XmlAttribute("covered")]
        public string Covered { get; set; }
    }


    public enum JacocoCounterTypeEnum
    {
        INSTRUCTION,
        BRANCH,
        LINE,
        COMPLEXITY,
        METHOD,
        CLASS
    }
}
