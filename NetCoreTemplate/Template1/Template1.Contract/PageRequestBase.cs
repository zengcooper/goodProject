namespace Template1.Contract
{
    /// <summary>
    /// PageRequestBase
    /// </summary>
    public class PageRequestBase : RequestBase
    {
        /// <summary>
        /// PageIndex
        /// </summary>
        public int PageIndex { get; set; }

        /// <summary>
        /// PageSize
        /// </summary>
        public int PageSize { get; set; }

    }
}
