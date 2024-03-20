using Pidgin;

namespace navdata.parsers
{
    public class Arinc424Parser : IParser {
 
        private readonly ILogger<Arinc424Parser> _logger;
 
        private static readonly Parser<char, string> HEADER_IDENT_PARSER = Pidgin.Parser.String("HDR");
        private static readonly Parser<char, char> RCORD_TYPE_PARSER = Pidgin.Parser.Char('S').Or(Pidgin.Parser.Char('T'));
        private static readonly Parser<char, string> CUSTOMER_AREA_CODE_PARSER = 


        public Arinc424Parser(ILogger<Arinc424Parser> logger) {
            _logger = logger;
        }
 
        public async Task Parse(Stream dataStream, CancellationToken cancellationToken) {
            _logger.LogInformation("Start parsing arinc file.");

            using (StreamReader reader = new StreamReader(dataStream)) {
                await ReadLineByLine(reader, cancellationToken);
            }

            _logger.LogInformation("Done parsing arinc file.");
        } 

        protected async Task ReadLineByLine(StreamReader reader, CancellationToken cancellationToken) {
            while(!reader.EndOfStream && !cancellationToken.IsCancellationRequested) {
                string? line = await reader.ReadLineAsync();

                _logger.LogDebug(line);
            }
        }        
    }
}