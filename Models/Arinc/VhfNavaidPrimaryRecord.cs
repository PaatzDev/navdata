namespace navdata.models.arinc {
    public class VhfNavaidPrimaryRecord {
        public char RecordType { get; set; }
        public char CustomerAreaCode { get; set; }
        public char SectionCode { get; set; }
        public char SubsectionCode { get; set; }
        public string AirportIcaoIdentifier { get; set; }
        public string IcaoCode { get; set; }
        public string VorIdentifier { get; set; }
        public string IcaoCode2 { get; set; }
        public string VorFrequency { get; set; }
        public string NavaidClass {get;set;}
        public string VorLatitude {get;set;}
        public string VorLongitude {get;set;}
        public string DmeIdent {get;set;}
        public string DmeLatitude {get;set;}
        public string DmeLongitude {get;set;}
        public string StationDeclination {get;set;}
        public string DmeElevation {get;set;}
        public char NavaidUseableRange {get;set;}
        public string IlsDmeBias {get;set;}
        public string FrequencyProtection {get;set;}
        public string DatumCode {get;set;}
        public string VorName {get;set;}
        public char VfrCheckpointFlag {get;set;}
        public char VorRangePower {get;set;}
        public char ExpandedDmeServiceVolume {get;set;}
        public char RouteInappropiateDme {get;set;}
        public char DmeOperationalServiceVolume {get;set;}
        public string FileRecordNumber {get;set;}
        public string CycleDate {get;set;}
    }
}