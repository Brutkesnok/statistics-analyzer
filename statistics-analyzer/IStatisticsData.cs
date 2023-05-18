using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace statistics_analyzer
{
    public interface IStatisticsData
    {
        bool LoadData(string filePath);

        string[] GetFields();

        List<string[]> GetEntries();

        string GetSummary();
    }
}
