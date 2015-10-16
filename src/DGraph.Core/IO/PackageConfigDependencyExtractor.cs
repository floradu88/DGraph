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
                    string packageName = element.Attributes["id"].Value;
                    string packageVersion = element.Attributes["version"].Value;
                    string packageTarget = element.Attributes["targetFramework"].Value;

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
    }
}
