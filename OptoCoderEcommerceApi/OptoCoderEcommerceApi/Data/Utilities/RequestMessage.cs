namespace OptoCoderEcommerceApi.Data.Utilities
{
    public class RequestMessage
    {
        public object RequestObj { get; set; }
        //Pagination
        public int CurrentPage { get; set; } = 1;
        public int ItemPerPage { get; set; } = 15;
    }
}
