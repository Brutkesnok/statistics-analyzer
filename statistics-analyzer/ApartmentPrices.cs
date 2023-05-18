﻿using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace statistics_analyzer
{
    public class ApartmentPrices: IStatisticsData
    {
        private List<string[]> data;

        public ApartmentPrices()
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
                for (int j = 0; j < data[i].Length ; ++j)
                {
                    entries[i - 1][j] = data[i][j];
                }
            }
            return entries;
        }

        public string GetSummary()
        {
            int maxPriceIncrease = Convert.ToInt32(data[data.Count - 1][1]) - Convert.ToInt32(data[1][1]);
            for (int j = 2; j < data[0].Length; ++j)
            {
                int increase = Convert.ToInt32(data[data.Count - 1][j]) - Convert.ToInt32(data[1][j]);
                if (increase > maxPriceIncrease)
                {
                    maxPriceIncrease = increase;
                }
            }
            string summary = "The maximum increase in price (the price increased by " +
                $"{maxPriceIncrease}) apartments:\n";
            for (int j = 1; j < data[0].Length; ++j)
            {
                int increase = Convert.ToInt32(data[data.Count - 1][j]) - Convert.ToInt32(data[1][j]);
                if (increase == maxPriceIncrease)
                {
                    summary += $"\t{data[0][j]}\n";
                }
            }

            return summary;
        }
    }
}
