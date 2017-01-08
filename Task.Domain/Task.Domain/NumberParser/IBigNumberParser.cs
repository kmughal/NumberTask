namespace Task.Domain {
    public interface IBigNumberParser
    {
        dynamic Parse(string number);
    }
}