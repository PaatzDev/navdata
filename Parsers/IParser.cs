namespace navdata.parsers 
{
    public interface IParser {
        public Task Parse(Stream dataStream, CancellationToken cancellationToken);
    }
}