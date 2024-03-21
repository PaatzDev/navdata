using Pidgin;

namespace navdata.models.arinc
{
    public abstract class ArincRecordBase {
        //Record Type is either S for standard or T for tailored
        protected static readonly Parser<char, char> RECORD_TYPE_PARSER = Pidgin.Parser.Char('S').Or(Pidgin.Parser.Char('T'));
        //Blank spacing parser
        protected static readonly Parser<char, Unit> BLANK_SPACING_PARSER = Pidgin.Parser.SkipWhitespaces;
    }
}