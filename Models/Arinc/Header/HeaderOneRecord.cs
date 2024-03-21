using System.Security.Cryptography;
using Microsoft.AspNetCore.StaticFiles.Infrastructure;
using Pidgin;

namespace navdata.models.arinc {
    public class HeaderOneRecord {

        private static readonly Parser<char, string> HEADER_IDENT_PARSER = Pidgin.Parser.String("HDR");

        private static readonly Parser<char, int> RECORD_NUMBER_PARSER = Pidgin.Parser.Map(
            (rawNumber) => int.Parse(rawNumber.ToArray()),
                Pidgin.Parser.Char('0').Repeat(1)
            .Or(
                Pidgin.Parser.Digit.Repeat(2)
            )
        );

        private static readonly Parser<char, string> FILE_NAME_PARSER = Pidgin.Parser.Map(
            (rawFileName) => rawFileName.ToString() ?? string.Empty,
            Pidgin.Parser.AnyCharExcept(new char[] {}).Repeat(15)
        );

        private static readonly Parser<char, int> VERSION_NUMBER_PARSER = Pidgin.Parser.Map(
            (rawDigits) => int.Parse(rawDigits.ToArray()),
            Pidgin.Parser.Digit.Repeat(3)
        );

        private static readonly Parser<char, bool> PRODUCTION_FLAG_PARSER = Pidgin.Parser.Map(
            (value) => char.ToUpper(value) == 'T' ? false : true,
            Pidgin.Parser.Char('T').Or(Pidgin.Parser.Char('P'))
        );

        private static readonly Parser<char, int> RECORD_LENGTH_PARSER = Pidgin.Parser.Map(
            (rawNumber) => int.Parse(rawNumber.ToArray()),
            Pidgin.Parser.Digit.Repeat(4)
        );

        private static readonly Parser<char, long> RECORD_COUNT_PARSER = Pidgin.Parser.Map(
            (rawNumber) => long.Parse(rawNumber.ToArray()),
            Pidgin.Parser.Digit.Repeat(7)
        );

        private static readonly Parser<char, int> CYCLE_DATE_PARSER = Pidgin.Parser.Map(
            (rawNumber) => int.Parse(rawNumber.ToArray()),
            Pidgin.Parser.Digit.Repeat(4)
        );

        private static readonly Parser<char, DateOnly> CREATION_DATE_PARSER = Pidgin.Parser.Map(
            (rawDate) => DateOnly.Parse(rawDate.ToArray()),
            Pidgin.Parser.LetterOrDigit.Or(Pidgin.Parser.Char('-')).Repeat(11)
        );

        private static readonly Parser<char, TimeOnly> CREATION_TIME_PARSER = Pidgin.Parser.Map(
            (rawTime) => TimeOnly.Parse(rawTime.ToArray()),
            Pidgin.Parser.Digit.Or(Pidgin.Parser.Char(':')).Repeat(8)
        );

        private static readonly Parser<char, string> DATA_SUPPLIER_IDENT = Pidgin.Parser.Map(
            (rawString) => rawString.ToString() ?? string.Empty,
            Pidgin.Parser.AnyCharExcept(new char[] {}).Repeat(16)
        );

        private static readonly Parser<char, string> TARGET_CUSTOMER_IDENT = Pidgin.Parser.Map(
            (rawString) => rawString.ToString() ?? string.Empty,
            Pidgin.Parser.AnyCharExcept(new char[] {}).Repeat(16)
        );

        private static readonly Parser<char, string> DATABASE_PART_NUMBER = Pidgin.Parser.Map(
            (rawString) => rawString.ToString() ?? string.Empty,
            Pidgin.Parser.AnyCharExcept(new char[] {}).Repeat(20)
        );

        private static readonly Parser<char, int> FILE_CRC_PARSER = Pidgin.Parser.Map(
            (rawNumber) => int.Parse(rawNumber.ToArray(), System.Globalization.NumberStyles.HexNumber),
            Pidgin.Parser.AnyCharExcept(new char[] {}).Until(Parser.EndOfLine)
        ); 

        public static HeaderOneRecord? Parse(char[] sourceData) {
            HeaderOneRecord record = new HeaderOneRecord();



            return null;
        } 

        public int Number { get; }
        public string FileName { get; }
        public int VersionNumber { get; }
        public bool IsProduction { get; }
        public int RecordLength { get; }
        public uint RecordCount { get; }
        public string CycleDate { get; }
        public string CreationDate { get; }
        public string CreationTime { get; }
        public string? DataSupplierIdent { get; }
        public string? TargetCustomerIdent { get; }
        public string DatabasePartNumber { get; }
        public string FileCRC { get; }
    

    }
}