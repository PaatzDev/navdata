using Microsoft.AspNetCore.StaticFiles.Infrastructure;
using Pidgin;

namespace navdata.models.arinc {
    public class HeaderOneRecord {
        public int Number { get; set; }
        public string FileName { get; set; }
        public int VersionNumber { get; set; }
        public bool IsProduction { get; set; }
        public int RecordLength { get; set; }
        public uint RecordCount { get; set; }
        public string CycleDate { get; set; }
        public string CreationDate { get; set; }
        public string CreationTime { get; set; }
        public string? DataSupplierIdent { get; set; }
        public string? TargetCustomerIdent { get; set; }
        public string DatabasePartNumber { get; set; }
        public string FileCRC { get; set; }
    
    
        public static readonly Parser<string, HeaderOneRecord> PARSER = Pidgin.Parser.Map(
            record => new HeaderOneRecord {

            },
            HEADER_IDENT_PARSER,
            HEADER_NUMBER_PARSER,
            FILE_NAME_PARSER,
            VERSION_NUMBER_PARSER,
            PRODUCTION_FLAG_PARSER,
            RECORD_LENGH_PARSER,
            RECORD_COUNT_PARSER,
            CYCLE_DATE_PARSER,
            CREATION_DATE_PARSER,
            CREATION_TIME_PARSER,
            DATA_SUPPLIER_IDENT,
            TARGET_CUSTOMER_IDENT,
            DATABASE_PART_NUMBER,
            FILE_CRC_PARSER            
        ); 

        private static readonly Parser<char, string> HEADER_IDENT_PARSER = Pidgin.Parser.String("HDR");
        private static readonly Parser<char, int> HEADER_NUMBER_PARSER = Pidgin.Parser.DecimalNum;
        private static readonly Parser<char, string?> FILE_NAME_PARSER = Pidgin.Parser.Map(
            x => x.ToString(),
            Pidgin.Parser.LetterOrDigit.AtLeastOnceUntil(
                Pidgin.Parser.Whitespace)
        );
        private static readonly Parser<char, string> VERSION_NUMBER_PARSER;
        private static readonly Parser<char, bool> PRODUCTION_FLAG_PARSER = Pidgin.Parser.Map(
            x => x == 'T' ? false : true,
            Pidgin.Parser.Char('T').Or(Pidgin.Parser.Char('P'))
        );
        private static readonly Parser<char, int> RECORD_LENGH_PARSER = Pidgin.Parser.DecimalNum;
        private static readonly Parser<char, int> RECORD_COUNT_PARSER = Pidgin.Parser.DecimalNum;
        private static readonly Parser<char, string?> CYCLE_DATE_PARSER = Pidgin.Parser.Map(
            value => value.ToString(),
            Pidgin.Parser.AnyCharExcept(new char[] {}).Repeat(4)
        );
        private static readonly Parser<char, DateOnly> CREATION_DATE_PARSER; //TODO: Create parser
        private static readonly Parser<char, TimeOnly> CREATION_TIME_PARSER; //TODO: Create parser
        private static readonly Parser<char, char> DATA_SUPPLIER_IDENT;
        private static readonly Parser<char, char> TARGET_CUSTOMER_IDENT;
        private static readonly Parser<char, char> DATABASE_PART_NUMBER;
        private static readonly Parser<char, int> FILE_CRC_PARSER = Parser.HexNum;
    }
}