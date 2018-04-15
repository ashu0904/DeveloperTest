using NUnit.Framework;
using ThirdPartyTools.Interface;
using System.Collections;
using ThirdPartyTools;
using System;


namespace FileData.Test
{
    [TestFixture]
    public class ApplicationTest
    {

       [SetUp]
        public void Initialise()
        {
           string test = string.Empty;
        }

        [Test, TestCaseSource(nameof(GetTestVersionData))]
        public void GetVersionOrSize_VersionAndSizeMessage_GetsVersionOrSize(string type, string path)
        {
            string actualVersionMessage = string.Empty;
            string[] args = new[] { type, path };
            Application app = new Application(new FileDetails());
            actualVersionMessage = app.GetVersionOrSize(args);
            Assert.IsNotEmpty(actualVersionMessage);
        }

        [Test]
        public void GetVersionOrSize_ExceptionForEmptyFirstArgument_GetsArgumentException()
        {
            string actualVersionMessage = string.Empty;
            string[] args = new[] { "", "c:/test.txt" };
            Application app = new Application(new FileDetails());
            Assert.That(() => app.GetVersionOrSize(args), Throws.TypeOf<ArgumentException>().With.Message.Contains("First Argument is empty"));
        }

        [Test]
        public void GetVersionOrSize_ExceptionForInvalidFirstArgument_GetsArgumentException()
        {
            string actualVersionMessage = string.Empty;
            string[] args = new[] { "/y", "c:/test.txt" };
            Application app = new Application(new FileDetails());
            Assert.That(() => app.GetVersionOrSize(args), Throws.TypeOf<ArgumentException>().With.Message.EqualTo("First Argument is Invalid"));
        }

        public static IEnumerable GetTestVersionData
        {
            get
            {
                yield return new TestCaseData(new string [] { "-v", "c:/test.txt" });
                yield return new TestCaseData(new string [] { "--v", "c:/test.txt" });
                yield return new TestCaseData(new string [] { "/v", "c:/test.txt" });
                yield return new TestCaseData(new string[] { "-s", "c:/test.txt" });
                yield return new TestCaseData(new string[] { "--s", "c:/test.txt" });
                yield return new TestCaseData(new string[] { "/s", "c:/test.txt" });

            }
        }

      
    }
}
