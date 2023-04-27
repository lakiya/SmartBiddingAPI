namespace SmartBiddingAPIV1.Models
{
    public class GenericModel<T>
    {
        public T Data { get; set; }
        public string[] Errors { get; set; }
    }
}
