using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using DGraph.Core.Domain;

namespace DGraph.Core.IO
{
    public class PackageConfigDependencyExtractor : IDependencyExtractor
    {
        private readonly string _filename;

        public PackageConfigDependencyExtractor(string filename)
        {
            if (string.IsNullOrEmpty(filename))
                throw new ArgumentNullException(filename);
            if (!File.Exists(filename))
                throw new InvalidOperationException(filename);

            this._filename = filename;
        }

        public IList<Dependency> Dependencies()
        {
            IList<Dependency> result = new List<Dependency>();

            XmlDocument doc = new XmlDocument();
            doc.Load(_filename);

            XmlNodeList elemList = doc.GetElementsByTagName("package");
            for (int i = 0; i < elemList.Count; i++)
            {
                var element = elemList[i];
                if (element != null && element.Attributes != null)
                {
                    string packageName = getElementAtribute(element, "id");
                    string packageVersion = getElementAtribute(element, "version");
                    string packageTarget = getElementAtribute(element, "targetFramework");

                    result.Add(new Dependency()
                    {
                        ApplicationName = packageName,
                        Version = packageVersion,
                        DateTime = DateTime.UtcNow,
                        Type = DependencyEnum.Nuget,
                        Id = Guid.NewGuid(),
                        SourcePath = _filename,
                        TargetFramework = packageTarget
                    });
                }
            }

            return result;
        }

        private string getElementAtribute(XmlNode element, string attribute)
        {
            if (element == null)
                return null;

            if (string.IsNullOrEmpty(attribute))
                return null;

            if (element.Attributes == null)
                return null;

            if (element.Attributes[attribute] == null)
                return null;

            return element.Attributes[attribute].Value;
        }
    }
}
