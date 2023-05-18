using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace statistics_analyzer
{
    public class MedianSalaries : IStatisticsData
    {
        private List<string[]> data;

        public MedianSalaries()
        {
            data = new List<string[]>();
        }

        public bool LoadData(string filePath)
        {
            List<string[]> newData = new List<string[]>();
            StreamReader streamReader = new StreamReader(filePath);
            string line;
            line = streamReader.ReadLine().Trim();
            while (line != null)
            {
                newData.Add(line.Split(','));
                line = streamReader.ReadLine();
            }
            streamReader.Close();
            if (ValidateData(newData))
            {
                data = newData;
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool ValidateData(List<string[]> content)
        {
            for (int i = 0; i < content.Count; ++i)
            {
                if (content[i].Length != content[0].Length)
                    return false;
                if (i != 0)
                {
                    for (int j = 0; j < content[i].Length; ++j)
                    {
                        try
                        {
                            Convert.ToInt32(content[i][j]);
                        }
                        catch (FormatException)
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
        }

        public string[] GetFields()
        {
            return data[0];
        }

        public List<string[]> GetEntries()
        {
            List<string[]> entries = new List<string[]>();
            for (int i = 1; i < data.Count; ++i)
            {
                entries.Add(new string[data.Count]);
                for (int j = 0; j < data[i].Length; ++j)
                {
                    entries[i - 1][j] = data[i][j];
                }
            }
            return entries;
        }

        public string GetSummary()
        {
            int manSalaryInc = (int)(Convert.ToDouble(data[data.Count - 1][1]) /
                Convert.ToDouble(data[1][1]) * 100) - 100;
            int womenSalaryInc = (int)(Convert.ToDouble(data[data.Count - 1][2]) /
                Convert.ToDouble(data[1][2]) * 100) - 100;
            string summary = "Salaries have increased on average\n" +
                $"\tIn men: {manSalaryInc}%\n" +
                $"\tIn women: {womenSalaryInc}%\n";

            return summary;
        }
    }
}
