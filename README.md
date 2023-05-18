# Laboratory work 3. Statistics analyzer

The program can open files in CSV format, read data, build a table and graph on
their basis, as well as make calculations (according to the variants tasks),
the results of which in the form of text will be displayed in the "Summary
information" field. Accordingly, for each of the tasks developed a separate
class that has methods for loading and processing data, as well as a field for
storing these data. In order to ensure compatibility of these classes with the
general part of the program, the "IStatisticsData" interface has been
developed, which defines a set of necessary methods:

```csharp
    public interface IStatisticsData
    {
        bool LoadData(string filePath);

        string[] GetFields();

        List<string[]> GetEntries();

        string GetSummary();
    }
```

## Variant 8. Median salaries

Task text:

> The user opens a file with data on the median wage in Russia over the last 15
> years. Display this information on the screen in a convenient format. Also
> use this data to make graphs. Calculate the percentage of wage growth for men
> and women.

Contents of the file used to test the program on variant 8 (randomly
generated):

```
Year,Man,Woman
2009,72934,77637
2010,75362,85400
2011,79277,78568
2012,82898,79353
2013,86171,84114
2014,87042,90843
2015,77310,72359
2016,81948,74529
2017,66578,74597
2018,67937,81084
2019,68624,82739
2020,74592,67821
2021,75486,67888
2022,76899,74603
2023,83586,89934
```

The result of the program for variant 8:

![Median Salaries](/data/median_salaries_result.png)


## Variant 9. Apartment prices

Task text:

> The user opens a file with data on prices in the primary housing market in
> Russia over the past 15 years. Display this information on the screen in a
> convenient format. Also use this data to make graphs. Calculate which
> n-bedroom apartments have increased in price the most.

Contents of the file used to test the program on variant 9 (randomly
generated):

```
Year,1-room,2-room,3-room,4-room,5-room
2009,72934,77637,77189,99154,118984
2010,75362,85400,74101,107086,118310
2011,77310,78568,77806,112440,120676
2012,79277,79353,85586,121435,127216
2013,82898,84114,86441,131149,128502
2014,86171,90843,90763,118034,121882
2015,87042,74597,89855,116853,134070
2016,81948,81084,72978,116853,123145
2017,74592,82739,73707,115684,125607
2018,76899,67821,78471,112213,131280
2019,66578,67888,78471,123434,136751
2020,67937,72359,80932,107855,136828
2021,68624,74529,81741,113532,137844
2022,75486,74603,88057,119508,145562
2023,83586,89934,88937,127137,151628
```

The result of the program for variant 9:

![Apartment Prices](/data/apartment_prices_result.png)
