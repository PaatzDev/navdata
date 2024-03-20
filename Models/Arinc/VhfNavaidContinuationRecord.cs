namespace navdata.models.arinc 
{
    public class VhfNavaidContinuationRecord {
        public char RecordType { get; set; }
        public char CustomerAreaCode { get; set; }
        public char SectionCode { get; set; }
        public char SubsectionCode { get; set; }
        public string AirportIcaoIdentifier { get; set; }
        public string IcaoCode { get; set; }
        public string VorIdentifier { get; set; }
        public string IcaoCode2 { get; set; }
        public char ContinuationRecordNumber {get;set;}
        public char ApplicationType {get;set;}
        public string Notes {get;set;}
        public string FileRecordNumber {get;set;}
        public string CycleDate {get;set;}
    }

    
}