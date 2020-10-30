using System;
using System.Collections.Generic;
using System.Text;
using CensusAnalyserLive.POCO;
using CensusAnalyserLive;
using CensusAnalyserLive.DTO;

namespace CensusAnalyserLive
{
     public class CSVAdapterFactory
    {
        public Dictionary<string, CensusDTO> LoadCsvData(CensusAnalyser.Country country, string csvFilePath, string dataHeaders)
        {
            switch (country)
            {
                case (CensusAnalyser.Country.INDIA):
                    return new IndianCensusAdapter().LoadCensusData(csvFilePath, dataHeaders);
                default:
                    throw new CensusAnalyserException("No Such Country", CensusAnalyserException.ExceptionType.NO_SUCH_COUNTRY);
            }

        }
    }
}
