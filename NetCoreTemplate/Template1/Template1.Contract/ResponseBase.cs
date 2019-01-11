namespace Template1.Contract
{
    /// <summary>
    /// BaseResponse
    /// </summary>
    public class ResponseBase
    {
        /// <summary>
        /// IsSuccess
        /// success:true, fail:false
        /// </summary>
        public bool IsSuccess { get; set; }

        /// <summary>
        /// Code
        /// sucess:20000
        /// fail:others
        /// InvalidParameter:-1
        /// ServiceInternalError:40000
        /// </summary>
        public int Code { get; set; }

        /// <summary>
        /// message
        /// </summary>
        public string Msg { get; set; }

        /// <summary>
        /// data
        /// </summary>
        public virtual object Result { get; set; }

    }
}
