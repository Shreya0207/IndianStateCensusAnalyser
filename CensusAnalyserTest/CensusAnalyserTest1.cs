using System;
using System.Collections.Generic;
using System.Text;
using CensusAnalyserLive;
using CensusAnalyserLive.POCO;
using CensusAnalyserLive.DTO;
using NUnit.Framework;
using static CensusAnalyserLive.DTO.CensusAnalyser;

namespace CensusAnalyserTest
{
    public class CensusAnalyserTest1
    {
        static string indianStateCensusHeaders = "State,Population,AreaInSqKm,DensityPerSqKm";
        static string indianStateCensusFilePath = @"C:\Users\Shreya\source\repos\CensusAnalyserTest\CSVFiles\IndiaStateCensusData.csv";
        static string indianStateWrongFilePath = @"WrongIndiaStateCensusData.csv";
        static string indianStateWrongTypeFilePath = @"C:\Users\Shreya\source\repos\CensusAnalyserTest\CSVFiles\IndiaStateCensusData.txt";
        static string indianStateIncorrectDelimiterFilePath = @"C:\Users\Shreya\source\repos\CensusAnalyserTest\CSVFiles\DelimiterIndiaStateCensusData.csv";
        static string indianStateIncorrectHeaderFilePath = @"C:\Users\Shreya\source\repos\CensusAnalyserTest\CSVFiles\WrongIndiaStateCensusData.csv";
        CensusAnalyserLive.DTO.CensusAnalyser censusAnalyser;
        Dictionary<string, CensusDTO> totalRecord;
        Dictionary<string, CensusDTO> stateRecord;

        [SetUp]
        public void Setup()
        {
            censusAnalyser = new CensusAnalyserLive.DTO.CensusAnalyser();
            totalRecord = new Dictionary<string, CensusDTO>();
            stateRecord = new Dictionary<string, CensusDTO>();
        }

        [Test]
        public void GivenIndianCensusDataFile_WhenReaded_ShouldReturnCensusDataCount()
        {
            totalRecord = censusAnalyser.LoadCensusData(Country.INDIA, indianStateCensusFilePath, indianStateCensusHeaders);
            Assert.AreEqual(29, totalRecord.Count);
        }
        [Test]
        public void GivenIndianCensusDataFile_IfIncorret_ShouldThrowCustomException()
        {
            try
            {
                totalRecord = censusAnalyser.LoadCensusData(Country.INDIA, indianStateWrongFilePath, indianStateCensusHeaders);
            }
            catch (CensusAnalyserException e)
            {
                Assert.AreEqual("File Not Found", e.Message);
            }
        }
        [Test]
        public void GivenIndianCensusDataFile_TypeIncorret_ShouldThrowCustomException()
        {
            try
            {
                totalRecord = censusAnalyser.LoadCensusData(Country.INDIA, indianStateWrongTypeFilePath, indianStateCensusHeaders);
            }
            catch (CensusAnalyserException e)
            {
                Assert.AreEqual("Invalid File Type", e.Message);
            }
        }
        [Test]
        public void GivenIndianCensusDataFile_IncorrectDelimiter_ShouldThrowCustomException()
        {
            try
            {
                totalRecord = censusAnalyser.LoadCensusData(Country.INDIA, indianStateIncorrectDelimiterFilePath, indianStateCensusHeaders);
            }
            catch (CensusAnalyserException e)
            {
                Assert.AreEqual("File Contains Wrong Delimiter", e.Message);
            }
        }
        [Test]
        public void GivenIndianCensusDataFile_WrongHeader_ShouldThrowCustomException()
        {
            try
            {
                totalRecord = censusAnalyser.LoadCensusData(Country.INDIA, indianStateIncorrectHeaderFilePath, indianStateCensusHeaders);
            }
            catch (CensusAnalyserException e)
            {
                Assert.AreEqual("Incorrect header in Data", e.Message);
            }
        }

    }
}
