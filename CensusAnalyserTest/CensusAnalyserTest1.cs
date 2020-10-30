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
        static  string indianStateCodeHeaders = "SrNo,State Name,TIN,StateCode";
        static  string indianStateCodeFilePath = @"C:\Users\Shreya\source\repos\CensusAnalyserTest\CSVFiles\IndiaStateCode.csv";
        static  string indianStateWrongFilePath = @"WrongIndiaStateCodeData.csv";
        static  string indianStateWrongTypeFilePath = @"C:\Users\Shreya\source\repos\CensusAnalyserTest\CSVFiles\IndiaStateCode.txt";
        static  string indianStateIncorrectDelimiterFilePath = @"C:\Users\Shreya\source\repos\CensusAnalyserTest\CSVFiles\DelimiterIndiaStateCode.csv";
        static  string indianStateIncorrectHeaderFilePath = @"C:\Users\Shreya\source\repos\CensusAnalyserTest\CSVFiles\WrongIndiaStateCode.csv";
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
            stateRecord = censusAnalyser.LoadCensusData(Country.INDIA, indianStateCodeFilePath, indianStateCodeHeaders);
            Assert.AreEqual(37, stateRecord.Count);
        }
        [Test]
        public void GivenIndianCensusDataFile_IfIncorret_ShouldThrowCustomException()
        {
            try
            {
                stateRecord = censusAnalyser.LoadCensusData(Country.INDIA, indianStateWrongFilePath, indianStateCodeHeaders);
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
                stateRecord = censusAnalyser.LoadCensusData(Country.INDIA, indianStateWrongTypeFilePath, indianStateCodeHeaders);
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
                stateRecord = censusAnalyser.LoadCensusData(Country.INDIA, indianStateIncorrectDelimiterFilePath, indianStateCodeHeaders);
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
                stateRecord = censusAnalyser.LoadCensusData(Country.INDIA, indianStateIncorrectHeaderFilePath, indianStateCodeHeaders);
            }
            catch (CensusAnalyserException e)
            {
                Assert.AreEqual("Incorrect header in Data", e.Message);
            }
        }
    }
}