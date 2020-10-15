using System.Xml.Serialization;

namespace UploadDaemon.SymbolAnalysis
{
    [XmlRoot("coverage", Namespace = "http://www.cpandl.com", IsNullable = false)]
    public class SonarQubeGenericReport
    {
        [XmlAttribute("version")]
        public uint Version { get; set; }

        [XmlElement("file")]
        public SonarQubeFileCoverage[] Files { get; set; }
    }


    public class SonarQubeFileCoverage
    {
        [XmlAttribute("path")]
        public string Path { get; set; }

        [XmlElement("lineToCover")]
        public LineToCover[] LineToCovers { get; set; }
    }

    public class LineToCover
    {
        [XmlAttribute("lineNumber")]
        public uint LineNumber { get; set; }
        [XmlAttribute("covered")]
        public bool Covered { get; set; }
    }
}
