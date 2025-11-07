using System;
using System.Collections.Generic;

namespace ConsoleApp
{
    public class Root
    {
        public CwaOpenData cwaopendata { get; set; }
    }

    public class CwaOpenData
    {
        public string identifier { get; set; }
        public string sender { get; set; }
        public string schemaVer { get; set; }
        public string language { get; set; }
        public string event_ { get; set; }  // event 是保留字，改成 event_
        public string senderName { get; set; }
        public string sent { get; set; }
        public string status { get; set; }
        public string msgType { get; set; }
        public string infoStatus { get; set; }
        public Earthquake Earthquake { get; set; }
    }

    public class Earthquake
    {
        public string Description { get; set; }
        public string OriginTime { get; set; }
        public string EpicenterLongitude { get; set; }
        public string EpicenterLatitude { get; set; }
        public string FocalDepth { get; set; }
        public Magnitude Magnitude { get; set; }
        public Intensity Intensity { get; set; }
    }

    public class Magnitude
    {
        public string MagnitudeType { get; set; }
        public string MagnitudeValue { get; set; }
    }

    public class Intensity
    {
        public List<County> County { get; set; }
    }

    public class County
    {
        public string CountyName { get; set; }
        public string CountyCode { get; set; }
        public string CountyMaxIntensity { get; set; }
        public string TownNumber { get; set; }
        public List<Town> Town { get; set; }
    }

    public class Town
    {
        public string TownName { get; set; }
        public string TownCode { get; set; }
        public string StationLongitude { get; set; }
        public string StationLatitude { get; set; }
        public string StationIntensity { get; set; }
    }
}
