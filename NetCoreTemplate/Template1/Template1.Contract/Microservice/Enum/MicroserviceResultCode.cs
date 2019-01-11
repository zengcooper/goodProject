using System.ComponentModel;

namespace Template1.Contract.Microservice.Enum
{
    /// <summary>
    /// MicroserviceResultCode
    /// </summary>
    public enum MicroserviceResultCode
    {
        /// <summary>
        /// Service Name have existed
        /// </summary>
        [Description("Service Name have existed")]
        NameExisted = 30001,
        /// <summary>
        /// Service Code have existed
        /// </summary>
        [Description("Service Code have existed")]
        ServiceCodeExisted = 30002,
        /// <summary>
        /// Add Fail
        /// </summary>
        [Description("Add Fail")]
        AddFail = 30003,
        /// <summary>
        /// Update Fail
        /// </summary>
        [Description("Update Fail")]
        UpdateFail = 30004,
        /// <summary>
        /// Delete fail
        /// </summary>
        [Description("Delete fail")]
        DeleteFail = 30005

    }
}
