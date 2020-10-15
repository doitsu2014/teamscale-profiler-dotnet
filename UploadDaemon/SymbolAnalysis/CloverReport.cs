///////////////////////////////////////////////////////////////////////////
//           Liquid XML Objects GENERATED CODE - DO NOT MODIFY           //
//            https://www.liquid-technologies.com/xml-objects            //
//=======================================================================//
// Dependencies                                                          //
//     Nuget : LiquidTechnologies.XmlObjects.Runtime                     //
//           : MUST BE VERSION 18.0.2                                    //
//=======================================================================//
// Online Help                                                           //
//     https://www.liquid-technologies.com/xml-objects-quick-start-guide //
//=======================================================================//
// Licensing Information                                                 //
//     https://www.liquid-technologies.com/eula                          //
///////////////////////////////////////////////////////////////////////////
using System.Collections.Generic;
using System.Xml.Linq;
using LiquidTechnologies.XmlObjects;
using LiquidTechnologies.XmlObjects.Attribution;

// ------------------------------------------------------
// |                      Settings                      |
// ------------------------------------------------------
// GenerateCommonBaseClass                  = False
// GenerateUnprocessedNodeHandlers          = False
// RaiseChangeEvents                        = False
// CollectionNaming                         = Pluralize
// Language                                 = CS
// OutputNamespace                          = LiquidTechnologies.GeneratedLx
// WriteDefaultValuesForOptionalAttributes  = False
// WriteDefaultValuesForOptionalElements    = False
// GenerationModel                          = Simple
//                                            *WARNING* this simplified model that is very easy to work with
//                                            but may cause the XML to be produced without regard for element
//                                            cardinality or order. Where very high compliance with the XML Schema
//                                            standard is required use GenerationModelType.Conformant
// XSD Schema Files
//    file://sandbox/schema.xsd


namespace LiquidTechnologies.GeneratedLx
{
    #region Global Settings
    /// <summary>Contains library level properties, and ensures the version of the runtime used matches the version used to generate it.</summary>
    [LxRuntimeRequirements("18.0.2.9850", "Liquid Technologies Ltd", "8F2XHY3Q1G75DLPF", LiquidTechnologies.XmlObjects.LicenseTermsType.FullLicense)]
    public partial class LxRuntimeRequirementsWritten
    {
    }

    #endregion

}

namespace LiquidTechnologies.GeneratedLx.Ns
{
    #region Enumerations
    /// <summary>An enumeration representing XSD simple type construct</summary>
    /// <XsdPath>schema:schema.xsd/simpleType:construct</XsdPath>
    /// <XsdFile>file://sandbox/schema.xsd</XsdFile>
    /// <XsdLocation>220:5-226:21</XsdLocation>
    public enum ConstructEnum
    {
        /// <summary>Represents the value 'method' in the XML</summary>
        [LxEnumValue("method")]
        Method,
        /// <summary>Represents the value 'stmt' in the XML</summary>
        [LxEnumValue("stmt")]
        Stmt,
        /// <summary>Represents the value 'cond' in the XML</summary>
        [LxEnumValue("cond")]
        Cond,
    }
    /// <summary>An enumeration representing XSD simple type visibility</summary>
    /// <XsdPath>schema:schema.xsd/simpleType:visibility</XsdPath>
    /// <XsdFile>file://sandbox/schema.xsd</XsdFile>
    /// <XsdLocation>228:5-235:21</XsdLocation>
    public enum VisibilityEnum
    {
        /// <summary>Represents the value 'private' in the XML</summary>
        [LxEnumValue("private")]
        Private_,
        /// <summary>Represents the value 'protected' in the XML</summary>
        [LxEnumValue("protected")]
        Protected_,
        /// <summary>Represents the value 'package' in the XML</summary>
        [LxEnumValue("package")]
        Package,
        /// <summary>Represents the value 'public' in the XML</summary>
        [LxEnumValue("public")]
        Public_,
    }
    #endregion

    #region Complex Types
    /// <summary>A class representing the root XSD complexType classMetrics</summary>
    /// <remarks>
    ///   <br/>
    ///       Metrics information for projects/packages/files/classes.<br/>
    ///       @complexity - the cyclomatic complexity<br/>
    ///       @conditionals - the number of contained conditionals (2 * number of branches)<br/>
    ///       @coveredconditionals - the number of contained conditionals (2 * number of branches) with coverage<br/>
    ///       @elements - the number of contained statements, conditionals and methods<br/>
    ///       @coveredelements - the number of contained statements, conditionals and methods with coverage<br/>
    ///       @statements - the number of contained statements<br/>
    ///       @coveredstatements - the number of contained statements with coverage<br/>
    ///       @methods - the number of contained methods<br/>
    ///       @coveredmethods - the number of contained methods with coverage<br/>
    ///       @testduration - the total duration of all contained test methods<br/>
    ///       @testfailures - the total number of test method failures<br/>
    ///       @testpasses - the total number of test method passes<br/>
    ///       @testruns - the total number of test methods run<br/>
    ///   
    /// </remarks>
    /// <XsdPath>schema:schema.xsd/complexType:classMetrics</XsdPath>
    /// <XsdFile>file://sandbox/schema.xsd</XsdFile>
    /// <XsdLocation>140:5-175:22</XsdLocation>
    [LxSimpleComplexTypeDefinition("classMetrics", "")]
    public partial class ClassMetricsCt
    {
        /// <summary>The value for the attribute complexity</summary>
        /// <XsdPath>schema:schema.xsd/complexType:classMetrics/attribute:complexity</XsdPath>
        /// <XsdFile>file://sandbox/schema.xsd</XsdFile>
        /// <XsdLocation>159:9-159:75</XsdLocation>
        [LxAttribute("complexity", "", LxValueType.Value, XsdType.XsdInteger, Required = true)]
        public System.Numerics.BigInteger Complexity { get; set; }

        /// <summary>The value for the attribute elements</summary>
        /// <XsdPath>schema:schema.xsd/complexType:classMetrics/attribute:elements</XsdPath>
        /// <XsdFile>file://sandbox/schema.xsd</XsdFile>
        /// <XsdLocation>160:9-160:73</XsdLocation>
        [LxAttribute("elements", "", LxValueType.Value, XsdType.XsdInteger, Required = true)]
        public System.Numerics.BigInteger Elements { get; set; }

        /// <summary>The value for the attribute coveredelements</summary>
        /// <XsdPath>schema:schema.xsd/complexType:classMetrics/attribute:coveredelements</XsdPath>
        /// <XsdFile>file://sandbox/schema.xsd</XsdFile>
        /// <XsdLocation>161:9-161:80</XsdLocation>
        [LxAttribute("coveredelements", "", LxValueType.Value, XsdType.XsdInteger, Required = true)]
        public System.Numerics.BigInteger Coveredelements { get; set; }

        /// <summary>The value for the attribute conditionals</summary>
        /// <XsdPath>schema:schema.xsd/complexType:classMetrics/attribute:conditionals</XsdPath>
        /// <XsdFile>file://sandbox/schema.xsd</XsdFile>
        /// <XsdLocation>162:9-162:77</XsdLocation>
        [LxAttribute("conditionals", "", LxValueType.Value, XsdType.XsdInteger, Required = true)]
        public System.Numerics.BigInteger Conditionals { get; set; }

        /// <summary>The value for the attribute coveredconditionals</summary>
        /// <XsdPath>schema:schema.xsd/complexType:classMetrics/attribute:coveredconditionals</XsdPath>
        /// <XsdFile>file://sandbox/schema.xsd</XsdFile>
        /// <XsdLocation>163:9-164:42</XsdLocation>
        [LxAttribute("coveredconditionals", "", LxValueType.Value, XsdType.XsdInteger, Required = true)]
        public System.Numerics.BigInteger Coveredconditionals { get; set; }

        /// <summary>The value for the attribute statements</summary>
        /// <XsdPath>schema:schema.xsd/complexType:classMetrics/attribute:statements</XsdPath>
        /// <XsdFile>file://sandbox/schema.xsd</XsdFile>
        /// <XsdLocation>165:9-165:75</XsdLocation>
        [LxAttribute("statements", "", LxValueType.Value, XsdType.XsdInteger, Required = true)]
        public System.Numerics.BigInteger Statements { get; set; }

        /// <summary>The value for the attribute coveredstatements</summary>
        /// <XsdPath>schema:schema.xsd/complexType:classMetrics/attribute:coveredstatements</XsdPath>
        /// <XsdFile>file://sandbox/schema.xsd</XsdFile>
        /// <XsdLocation>166:9-167:42</XsdLocation>
        [LxAttribute("coveredstatements", "", LxValueType.Value, XsdType.XsdInteger, Required = true)]
        public System.Numerics.BigInteger Coveredstatements { get; set; }

        /// <summary>The value for the attribute coveredmethods</summary>
        /// <XsdPath>schema:schema.xsd/complexType:classMetrics/attribute:coveredmethods</XsdPath>
        /// <XsdFile>file://sandbox/schema.xsd</XsdFile>
        /// <XsdLocation>168:9-168:79</XsdLocation>
        [LxAttribute("coveredmethods", "", LxValueType.Value, XsdType.XsdInteger, Required = true)]
        public System.Numerics.BigInteger Coveredmethods { get; set; }

        /// <summary>The value for the attribute methods</summary>
        /// <XsdPath>schema:schema.xsd/complexType:classMetrics/attribute:methods</XsdPath>
        /// <XsdFile>file://sandbox/schema.xsd</XsdFile>
        /// <XsdLocation>169:9-169:72</XsdLocation>
        [LxAttribute("methods", "", LxValueType.Value, XsdType.XsdInteger, Required = true)]
        public System.Numerics.BigInteger Methods { get; set; }

        /// <summary>The value for the optional attribute testduration</summary>
        /// <XsdPath>schema:schema.xsd/complexType:classMetrics/attribute:testduration</XsdPath>
        /// <XsdFile>file://sandbox/schema.xsd</XsdFile>
        /// <XsdLocation>171:9-171:62</XsdLocation>
        [LxAttribute("testduration", "", LxValueType.Value, XsdType.XsdDecimal)]
        public LiquidTechnologies.XmlObjects.BigDecimal? Testduration { get; set; }

        /// <summary>The value for the optional attribute testfailures</summary>
        /// <XsdPath>schema:schema.xsd/complexType:classMetrics/attribute:testfailures</XsdPath>
        /// <XsdFile>file://sandbox/schema.xsd</XsdFile>
        /// <XsdLocation>172:9-172:62</XsdLocation>
        [LxAttribute("testfailures", "", LxValueType.Value, XsdType.XsdInteger)]
        public System.Numerics.BigInteger? Testfailures { get; set; }

        /// <summary>The value for the optional attribute testpasses</summary>
        /// <XsdPath>schema:schema.xsd/complexType:classMetrics/attribute:testpasses</XsdPath>
        /// <XsdFile>file://sandbox/schema.xsd</XsdFile>
        /// <XsdLocation>173:9-173:60</XsdLocation>
        [LxAttribute("testpasses", "", LxValueType.Value, XsdType.XsdInteger)]
        public System.Numerics.BigInteger? Testpasses { get; set; }

        /// <summary>The value for the optional attribute testruns</summary>
        /// <XsdPath>schema:schema.xsd/complexType:classMetrics/attribute:testruns</XsdPath>
        /// <XsdFile>file://sandbox/schema.xsd</XsdFile>
        /// <XsdLocation>174:9-174:58</XsdLocation>
        [LxAttribute("testruns", "", LxValueType.Value, XsdType.XsdInteger)]
        public System.Numerics.BigInteger? Testruns { get; set; }

    }

    /// <summary>A class representing the root XSD complexType fileMetrics</summary>
    /// <remarks>
    ///   <br/>
    ///       Metrics information for projects/packages/files.<br/>
    ///       @classes - the total number of contained classes<br/>
    ///       @loc - the total number of lines of code<br/>
    ///       @ncloc - the total number of non-comment lines of code<br/>
    ///   
    /// </remarks>
    /// <XsdPath>schema:schema.xsd/complexType:fileMetrics</XsdPath>
    /// <XsdFile>file://sandbox/schema.xsd</XsdFile>
    /// <XsdLocation>176:5-192:22</XsdLocation>
    [LxSimpleComplexTypeDefinition("fileMetrics", "")]
    public partial class FileMetricsCt : LiquidTechnologies.GeneratedLx.Ns.ClassMetricsCt
    {
        /// <summary>The value for the optional attribute classes</summary>
        /// <XsdPath>schema:schema.xsd/complexType:fileMetrics/attribute:classes</XsdPath>
        /// <XsdFile>file://sandbox/schema.xsd</XsdFile>
        /// <XsdLocation>187:17-187:65</XsdLocation>
        [LxAttribute("classes", "", LxValueType.Value, XsdType.XsdInteger)]
        public System.Numerics.BigInteger? Classes { get; set; }

        /// <summary>The value for the optional attribute loc</summary>
        /// <XsdPath>schema:schema.xsd/complexType:fileMetrics/attribute:loc</XsdPath>
        /// <XsdFile>file://sandbox/schema.xsd</XsdFile>
        /// <XsdLocation>188:17-188:61</XsdLocation>
        [LxAttribute("loc", "", LxValueType.Value, XsdType.XsdInteger)]
        public System.Numerics.BigInteger? Loc { get; set; }

        /// <summary>The value for the optional attribute ncloc</summary>
        /// <XsdPath>schema:schema.xsd/complexType:fileMetrics/attribute:ncloc</XsdPath>
        /// <XsdFile>file://sandbox/schema.xsd</XsdFile>
        /// <XsdLocation>189:17-189:63</XsdLocation>
        [LxAttribute("ncloc", "", LxValueType.Value, XsdType.XsdInteger)]
        public System.Numerics.BigInteger? Ncloc { get; set; }

    }

    /// <summary>A class representing the root XSD complexType packageMetrics</summary>
    /// <remarks>
    ///   <br/>
    ///       Metrics information for projects/packages.<br/>
    ///       @files - the total number of contained files<br/>
    ///   
    /// </remarks>
    /// <XsdPath>schema:schema.xsd/complexType:packageMetrics</XsdPath>
    /// <XsdFile>file://sandbox/schema.xsd</XsdFile>
    /// <XsdLocation>193:5-205:22</XsdLocation>
    [LxSimpleComplexTypeDefinition("packageMetrics", "")]
    public partial class PackageMetricsCt : LiquidTechnologies.GeneratedLx.Ns.FileMetricsCt
    {
        /// <summary>The value for the optional attribute files</summary>
        /// <XsdPath>schema:schema.xsd/complexType:packageMetrics/attribute:files</XsdPath>
        /// <XsdFile>file://sandbox/schema.xsd</XsdFile>
        /// <XsdLocation>202:17-202:63</XsdLocation>
        [LxAttribute("files", "", LxValueType.Value, XsdType.XsdInteger)]
        public System.Numerics.BigInteger? Files { get; set; }

    }

    /// <summary>A class representing the root XSD complexType projectMetrics</summary>
    /// <remarks>
    ///   <br/>
    ///       Metrics information for projects.<br/>
    ///       @files - the total number of packages<br/>
    ///   
    /// </remarks>
    /// <XsdPath>schema:schema.xsd/complexType:projectMetrics</XsdPath>
    /// <XsdFile>file://sandbox/schema.xsd</XsdFile>
    /// <XsdLocation>206:5-218:22</XsdLocation>
    [LxSimpleComplexTypeDefinition("projectMetrics", "")]
    public partial class ProjectMetricsCt : LiquidTechnologies.GeneratedLx.Ns.PackageMetricsCt
    {
        /// <summary>The value for the optional attribute packages</summary>
        /// <XsdPath>schema:schema.xsd/complexType:projectMetrics/attribute:packages</XsdPath>
        /// <XsdFile>file://sandbox/schema.xsd</XsdFile>
        /// <XsdLocation>215:17-215:66</XsdLocation>
        [LxAttribute("packages", "", LxValueType.Value, XsdType.XsdInteger)]
        public System.Numerics.BigInteger? Packages { get; set; }

    }

    #endregion

    #region Elements
    /// <summary>A class representing the root XSD element class</summary>
    /// <remarks>
    ///   <br/>
    ///       Class metrics.<br/>
    ///       @name - the unqualified class name<br/>
    ///   
    /// </remarks>
    /// <XsdPath>schema:schema.xsd/element:class</XsdPath>
    /// <XsdFile>file://sandbox/schema.xsd</XsdFile>
    /// <XsdLocation>88:5-109:18</XsdLocation>
    [LxSimpleElementDefinition("class", "", ElementScopeType.GlobalElement)]
    public partial class Class_Elm
    {
        /// <summary>The value for the attribute name</summary>
        /// <XsdPath>schema:schema.xsd/element:class/attribute:name</XsdPath>
        /// <XsdFile>file://sandbox/schema.xsd</XsdFile>
        /// <XsdLocation>99:13-107:28</XsdLocation>
        [LxAttribute("name", "", LxValueType.Value, XsdType.XsdString, Required = true, Pattern = "[\\p{L}$_][\\p{L}\\p{Nd}$_.]+")]
        public System.String Name { get; set; } = "";

        /// <summary>
        ///   A class derived from <see cref="LiquidTechnologies.GeneratedLx.Ns.ClassMetricsCt" />.<br/><br/>
        ///   Allowable types are <br/>
        ///       <see cref="LiquidTechnologies.GeneratedLx.Ns.ClassMetricsCt" /><br/>
        ///       <see cref="LiquidTechnologies.GeneratedLx.Ns.ProjectMetricsCt" /><br/>
        ///       <see cref="LiquidTechnologies.GeneratedLx.Ns.PackageMetricsCt" /><br/>
        ///       <see cref="LiquidTechnologies.GeneratedLx.Ns.FileMetricsCt" />
        /// </summary>
        [LxElementCt("metrics", "", MinOccurs = 1, MaxOccurs = 1)]
        public LiquidTechnologies.GeneratedLx.Ns.ClassMetricsCt Metrics { get; set; } = new LiquidTechnologies.GeneratedLx.Ns.ClassMetricsCt();

    }

    /// <summary>A class representing the root XSD element coverage</summary>
    /// <XsdPath>schema:schema.xsd/element:coverage</XsdPath>
    /// <XsdFile>file://sandbox/schema.xsd</XsdFile>
    /// <XsdLocation>4:5-19:18</XsdLocation>
    [LxSimpleElementDefinition("coverage", "", ElementScopeType.GlobalElement)]
    public partial class CoverageElm
    {
        /// <summary>The value for the attribute clover</summary>
        /// <XsdPath>schema:schema.xsd/element:coverage/attribute:clover</XsdPath>
        /// <XsdFile>file://sandbox/schema.xsd</XsdFile>
        /// <XsdLocation>16:13-16:75</XsdLocation>
        [LxAttribute("clover", "", LxValueType.Value, XsdType.XsdNMTOKEN, Required = true)]
        public System.String Clover { get; set; } = "";

        /// <summary>The value for the attribute generated</summary>
        /// <XsdPath>schema:schema.xsd/element:coverage/attribute:generated</XsdPath>
        /// <XsdFile>file://sandbox/schema.xsd</XsdFile>
        /// <XsdLocation>17:13-17:78</XsdLocation>
        [LxAttribute("generated", "", LxValueType.Value, XsdType.XsdInteger, Required = true)]
        public System.Numerics.BigInteger Generated { get; set; }

        /// <summary>A <see cref="LiquidTechnologies.GeneratedLx.Ns.ProjectElm" />, Required : should not be set to null</summary>
        [LxElementRef(MinOccurs = 1, MaxOccurs = 1)]
        public LiquidTechnologies.GeneratedLx.Ns.ProjectElm Project { get; set; } = new LiquidTechnologies.GeneratedLx.Ns.ProjectElm();

        /// <summary>A <see cref="LiquidTechnologies.GeneratedLx.Ns.TestprojectElm" />, Required : should not be set to null</summary>
        [LxElementRef(MinOccurs = 1, MaxOccurs = 1)]
        public LiquidTechnologies.GeneratedLx.Ns.TestprojectElm Testproject { get; set; } = new LiquidTechnologies.GeneratedLx.Ns.TestprojectElm();

    }

    /// <summary>A class representing the root XSD element file</summary>
    /// <remarks>
    ///   <br/>
    ///       File metrics.<br/>
    ///       @name - the file name e.g. Foo.java or Bar.groovy<br/>
    ///       @path - the filesystem-specific original path to the file e.g. c:\path\to\Bar.groovy<br/>
    ///   
    /// </remarks>
    /// <XsdPath>schema:schema.xsd/element:file</XsdPath>
    /// <XsdFile>file://sandbox/schema.xsd</XsdFile>
    /// <XsdLocation>69:5-87:18</XsdLocation>
    [LxSimpleElementDefinition("file", "", ElementScopeType.GlobalElement)]
    public partial class FileElm
    {
        /// <summary>The value for the attribute name</summary>
        /// <XsdPath>schema:schema.xsd/element:file/attribute:name</XsdPath>
        /// <XsdFile>file://sandbox/schema.xsd</XsdFile>
        /// <XsdLocation>84:13-84:72</XsdLocation>
        [LxAttribute("name", "", LxValueType.Value, XsdType.XsdNCName, Required = true)]
        public System.String Name { get; set; } = "";

        /// <summary>The value for the attribute path</summary>
        /// <XsdPath>schema:schema.xsd/element:file/attribute:path</XsdPath>
        /// <XsdFile>file://sandbox/schema.xsd</XsdFile>
        /// <XsdLocation>85:13-85:55</XsdLocation>
        [LxAttribute("path", "", LxValueType.Value, XsdType.XsdString, Required = true)]
        public System.String Path { get; set; } = "";

        /// <summary>
        ///   A class derived from <see cref="LiquidTechnologies.GeneratedLx.Ns.FileMetricsCt" />.<br/><br/>
        ///   Allowable types are <br/>
        ///       <see cref="LiquidTechnologies.GeneratedLx.Ns.FileMetricsCt" /><br/>
        ///       <see cref="LiquidTechnologies.GeneratedLx.Ns.ProjectMetricsCt" /><br/>
        ///       <see cref="LiquidTechnologies.GeneratedLx.Ns.PackageMetricsCt" />
        /// </summary>
        [LxElementCt("metrics", "", MinOccurs = 1, MaxOccurs = 1)]
        public LiquidTechnologies.GeneratedLx.Ns.FileMetricsCt Metrics { get; set; } = new LiquidTechnologies.GeneratedLx.Ns.FileMetricsCt();

        /// <summary>A collection of <see cref="LiquidTechnologies.GeneratedLx.Ns.Class_Elm" /></summary>
        [LxElementRef(MinOccurs = 0, MaxOccurs = LxConstants.Unbounded)]
        public List<LiquidTechnologies.GeneratedLx.Ns.Class_Elm> Classes { get; } = new List<LiquidTechnologies.GeneratedLx.Ns.Class_Elm>();

        /// <summary>A collection of <see cref="LiquidTechnologies.GeneratedLx.Ns.LineElm" /></summary>
        [LxElementRef(MinOccurs = 0, MaxOccurs = LxConstants.Unbounded)]
        public List<LiquidTechnologies.GeneratedLx.Ns.LineElm> Lines { get; } = new List<LiquidTechnologies.GeneratedLx.Ns.LineElm>();

    }

    /// <summary>A class representing the root XSD element line</summary>
    /// <remarks>
    ///   <br/>
    ///       Line-specific information.<br/>
    ///       @line - the line number<br/>
    ///       @type - the type of syntactic construct - one of method|stmt|cond<br/>
    ///       @complexity - only applicable if @type == 'method'; the cyclomatic complexity of the construct<br/>
    ///       @count - only applicable if @type == 'stmt' or 'method'; the number of times the construct was executed<br/>
    ///       @truecount - only applicable if @type == 'cond'; the number of times the true branch was executed<br/>
    ///       @falsecount - only applicable if @type == 'cond'; the number of times the false branch was executed<br/>
    ///       @signature - only applicable if @type == 'method'; the signature of the method<br/>
    ///       @testduration - only applicable if @type == 'method' and the method was identified as a test method; the duration of the test<br/>
    ///       @testsuccess - only applicable if @type == 'method' and the method was identified as a test method; true if the test passed, false otherwise<br/>
    ///       @visibility - only applicable if @type == 'method'<br/>
    ///   
    /// </remarks>
    /// <XsdPath>schema:schema.xsd/element:line</XsdPath>
    /// <XsdFile>file://sandbox/schema.xsd</XsdFile>
    /// <XsdLocation>110:5-138:18</XsdLocation>
    [LxSimpleElementDefinition("line", "", ElementScopeType.GlobalElement)]
    public partial class LineElm
    {
        /// <summary>The value for the attribute num</summary>
        /// <XsdPath>schema:schema.xsd/element:line/attribute:num</XsdPath>
        /// <XsdFile>file://sandbox/schema.xsd</XsdFile>
        /// <XsdLocation>127:13-127:72</XsdLocation>
        [LxAttribute("num", "", LxValueType.Value, XsdType.XsdInteger, Required = true)]
        public System.Numerics.BigInteger Num { get; set; }

        /// <summary>The value for the attribute type</summary>
        /// <XsdPath>schema:schema.xsd/element:line/attribute:type</XsdPath>
        /// <XsdFile>file://sandbox/schema.xsd</XsdFile>
        /// <XsdLocation>128:13-128:72</XsdLocation>
        [LxAttribute("type", "", LxValueType.Enum, XsdType.Enum, Required = true)]
        public LiquidTechnologies.GeneratedLx.Ns.ConstructEnum Type { get; set; }

        /// <summary>The value for the optional attribute complexity</summary>
        /// <XsdPath>schema:schema.xsd/element:line/attribute:complexity</XsdPath>
        /// <XsdFile>file://sandbox/schema.xsd</XsdFile>
        /// <XsdLocation>129:13-129:64</XsdLocation>
        [LxAttribute("complexity", "", LxValueType.Value, XsdType.XsdInteger)]
        public System.Numerics.BigInteger? Complexity { get; set; }

        /// <summary>The value for the optional attribute count</summary>
        /// <XsdPath>schema:schema.xsd/element:line/attribute:count</XsdPath>
        /// <XsdFile>file://sandbox/schema.xsd</XsdFile>
        /// <XsdLocation>130:13-130:59</XsdLocation>
        [LxAttribute("count", "", LxValueType.Value, XsdType.XsdInteger)]
        public System.Numerics.BigInteger? Count { get; set; }

        /// <summary>The value for the optional attribute falsecount</summary>
        /// <XsdPath>schema:schema.xsd/element:line/attribute:falsecount</XsdPath>
        /// <XsdFile>file://sandbox/schema.xsd</XsdFile>
        /// <XsdLocation>131:13-131:64</XsdLocation>
        [LxAttribute("falsecount", "", LxValueType.Value, XsdType.XsdInteger)]
        public System.Numerics.BigInteger? Falsecount { get; set; }

        /// <summary>The value for the optional attribute truecount</summary>
        /// <XsdPath>schema:schema.xsd/element:line/attribute:truecount</XsdPath>
        /// <XsdFile>file://sandbox/schema.xsd</XsdFile>
        /// <XsdLocation>132:13-132:63</XsdLocation>
        [LxAttribute("truecount", "", LxValueType.Value, XsdType.XsdInteger)]
        public System.Numerics.BigInteger? Truecount { get; set; }

        /// <summary>The value for the optional attribute signature</summary>
        /// <XsdPath>schema:schema.xsd/element:line/attribute:signature</XsdPath>
        /// <XsdFile>file://sandbox/schema.xsd</XsdFile>
        /// <XsdLocation>133:13-133:62</XsdLocation>
        [LxAttribute("signature", "", LxValueType.Value, XsdType.XsdString)]
        public System.String Signature { get; set; }

        /// <summary>The value for the optional attribute testduration</summary>
        /// <XsdPath>schema:schema.xsd/element:line/attribute:testduration</XsdPath>
        /// <XsdFile>file://sandbox/schema.xsd</XsdFile>
        /// <XsdLocation>134:13-134:66</XsdLocation>
        [LxAttribute("testduration", "", LxValueType.Value, XsdType.XsdDecimal)]
        public LiquidTechnologies.XmlObjects.BigDecimal? Testduration { get; set; }

        /// <summary>The value for the optional attribute testsuccess</summary>
        /// <XsdPath>schema:schema.xsd/element:line/attribute:testsuccess</XsdPath>
        /// <XsdFile>file://sandbox/schema.xsd</XsdFile>
        /// <XsdLocation>135:13-135:65</XsdLocation>
        [LxAttribute("testsuccess", "", LxValueType.Value, XsdType.XsdBoolean)]
        public System.Boolean? Testsuccess { get; set; }

        /// <summary>The value for the optional attribute visibility</summary>
        /// <XsdPath>schema:schema.xsd/element:line/attribute:visibility</XsdPath>
        /// <XsdFile>file://sandbox/schema.xsd</XsdFile>
        /// <XsdLocation>136:13-136:64</XsdLocation>
        [LxAttribute("visibility", "", LxValueType.Enum, XsdType.Enum)]
        public LiquidTechnologies.GeneratedLx.Ns.VisibilityEnum? Visibility { get; set; }

    }

    /// <summary>A class representing the root XSD element package</summary>
    /// <remarks>
    ///   <br/>
    ///       Package metrics.<br/>
    ///       @name - the.package.name<br/>
    ///   
    /// </remarks>
    /// <XsdPath>schema:schema.xsd/element:package</XsdPath>
    /// <XsdFile>file://sandbox/schema.xsd</XsdFile>
    /// <XsdLocation>54:5-68:18</XsdLocation>
    [LxSimpleElementDefinition("package", "", ElementScopeType.GlobalElement)]
    public partial class PackageElm
    {
        /// <summary>The value for the attribute name</summary>
        /// <XsdPath>schema:schema.xsd/element:package/attribute:name</XsdPath>
        /// <XsdFile>file://sandbox/schema.xsd</XsdFile>
        /// <XsdLocation>66:13-66:72</XsdLocation>
        [LxAttribute("name", "", LxValueType.Value, XsdType.XsdNCName, Required = true)]
        public System.String Name { get; set; } = "";

        /// <summary>
        ///   A class derived from <see cref="LiquidTechnologies.GeneratedLx.Ns.PackageMetricsCt" />.<br/><br/>
        ///   Allowable types are <br/>
        ///       <see cref="LiquidTechnologies.GeneratedLx.Ns.PackageMetricsCt" /><br/>
        ///       <see cref="LiquidTechnologies.GeneratedLx.Ns.ProjectMetricsCt" />
        /// </summary>
        [LxElementCt("metrics", "", MinOccurs = 1, MaxOccurs = 1)]
        public LiquidTechnologies.GeneratedLx.Ns.PackageMetricsCt Metrics { get; set; } = new LiquidTechnologies.GeneratedLx.Ns.PackageMetricsCt();

        /// <summary>A collection of <see cref="LiquidTechnologies.GeneratedLx.Ns.FileElm" /></summary>
        [LxElementRef(MinOccurs = 0, MaxOccurs = LxConstants.Unbounded)]
        public List<LiquidTechnologies.GeneratedLx.Ns.FileElm> Files { get; } = new List<LiquidTechnologies.GeneratedLx.Ns.FileElm>();

    }

    /// <summary>A class representing the root XSD element project</summary>
    /// <remarks>
    ///   <br/>
    ///       Project metrics relating to non-test source.<br/>
    ///       @name - project name (optional)<br/>
    ///       @timestamp - seconds since UTC<br/>
    ///   
    /// </remarks>
    /// <XsdPath>schema:schema.xsd/element:project</XsdPath>
    /// <XsdFile>file://sandbox/schema.xsd</XsdFile>
    /// <XsdLocation>20:5-36:18</XsdLocation>
    [LxSimpleElementDefinition("project", "", ElementScopeType.GlobalElement)]
    public partial class ProjectElm
    {
        /// <summary>The value for the optional attribute name</summary>
        /// <XsdPath>schema:schema.xsd/element:project/attribute:name</XsdPath>
        /// <XsdFile>file://sandbox/schema.xsd</XsdFile>
        /// <XsdLocation>33:13-33:40</XsdLocation>
        [LxAttribute("name", "", LxValueType.Value, XsdType.XsdString)]
        public System.String Name { get; set; }

        /// <summary>The value for the attribute timestamp</summary>
        /// <XsdPath>schema:schema.xsd/element:project/attribute:timestamp</XsdPath>
        /// <XsdFile>file://sandbox/schema.xsd</XsdFile>
        /// <XsdLocation>34:13-34:78</XsdLocation>
        [LxAttribute("timestamp", "", LxValueType.Value, XsdType.XsdInteger, Required = true)]
        public System.Numerics.BigInteger Timestamp { get; set; }

        /// <summary>
        ///   A class derived from <see cref="LiquidTechnologies.GeneratedLx.Ns.ProjectMetricsCt" />.<br/><br/>
        ///   Allowable types are <br/>
        ///       <see cref="LiquidTechnologies.GeneratedLx.Ns.ProjectMetricsCt" />
        /// </summary>
        [LxElementCt("metrics", "", MinOccurs = 1, MaxOccurs = 1)]
        public LiquidTechnologies.GeneratedLx.Ns.ProjectMetricsCt Metrics { get; set; } = new LiquidTechnologies.GeneratedLx.Ns.ProjectMetricsCt();

        /// <summary>A collection of <see cref="LiquidTechnologies.GeneratedLx.Ns.PackageElm" /></summary>
        [LxElementRef(MinOccurs = 0, MaxOccurs = LxConstants.Unbounded)]
        public List<LiquidTechnologies.GeneratedLx.Ns.PackageElm> Packages { get; } = new List<LiquidTechnologies.GeneratedLx.Ns.PackageElm>();

    }

    /// <summary>A class representing the root XSD element testproject</summary>
    /// <remarks>
    ///   <br/>
    ///       Project metrics relating to test source.<br/>
    ///       @name - project name (optional)<br/>
    ///       @timestamp - seconds since UTC<br/>
    ///   
    /// </remarks>
    /// <XsdPath>schema:schema.xsd/element:testproject</XsdPath>
    /// <XsdFile>file://sandbox/schema.xsd</XsdFile>
    /// <XsdLocation>37:5-53:18</XsdLocation>
    [LxSimpleElementDefinition("testproject", "", ElementScopeType.GlobalElement)]
    public partial class TestprojectElm
    {
        /// <summary>The value for the optional attribute name</summary>
        /// <XsdPath>schema:schema.xsd/element:testproject/attribute:name</XsdPath>
        /// <XsdFile>file://sandbox/schema.xsd</XsdFile>
        /// <XsdLocation>50:13-50:40</XsdLocation>
        [LxAttribute("name", "", LxValueType.Value, XsdType.XsdString)]
        public System.String Name { get; set; }

        /// <summary>The value for the attribute timestamp</summary>
        /// <XsdPath>schema:schema.xsd/element:testproject/attribute:timestamp</XsdPath>
        /// <XsdFile>file://sandbox/schema.xsd</XsdFile>
        /// <XsdLocation>51:13-51:78</XsdLocation>
        [LxAttribute("timestamp", "", LxValueType.Value, XsdType.XsdInteger, Required = true)]
        public System.Numerics.BigInteger Timestamp { get; set; }

        /// <summary>
        ///   A class derived from <see cref="LiquidTechnologies.GeneratedLx.Ns.ProjectMetricsCt" />.<br/><br/>
        ///   Allowable types are <br/>
        ///       <see cref="LiquidTechnologies.GeneratedLx.Ns.ProjectMetricsCt" />
        /// </summary>
        [LxElementCt("metrics", "", MinOccurs = 1, MaxOccurs = 1)]
        public LiquidTechnologies.GeneratedLx.Ns.ProjectMetricsCt Metrics { get; set; } = new LiquidTechnologies.GeneratedLx.Ns.ProjectMetricsCt();

        /// <summary>A collection of <see cref="LiquidTechnologies.GeneratedLx.Ns.PackageElm" /></summary>
        [LxElementRef(MinOccurs = 0, MaxOccurs = LxConstants.Unbounded)]
        public List<LiquidTechnologies.GeneratedLx.Ns.PackageElm> Packages { get; } = new List<LiquidTechnologies.GeneratedLx.Ns.PackageElm>();

    }

    #endregion

}

namespace LiquidTechnologies.GeneratedLx.Xs
{
    #region Complex Types
    /// <summary>
    /// A class representing the root XSD complexType anyType@http://www.w3.org/2001/XMLSchema
    /// </summary>
    /// <XsdPath>schema:.../www.w3.org/2001/XMLSchema/complexType:anyType</XsdPath>
    /// <XsdFile>http://www.w3.org/2001/XMLSchema</XsdFile>
    /// <XsdLocation>Empty</XsdLocation>
    [LxSimpleComplexTypeDefinition("anyType", "http://www.w3.org/2001/XMLSchema")]
    public partial class AnyTypeCt : XElement
    {
        /// <summary>Constructor : create a <see cref="AnyTypeCt" /> element &lt;anyType xmlns='http://www.w3.org/2001/XMLSchema'&gt;</summary>
        public AnyTypeCt() : base(XName.Get("anyType", "http://www.w3.org/2001/XMLSchema")) { }

    }

    #endregion

}
