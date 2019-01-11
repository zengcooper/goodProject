using System;
using System.ComponentModel.DataAnnotations;

namespace Template1.Contract.Dtos.Microservice
{
    /// <summary>
    /// MicroserviceDto
    /// </summary>
    [Serializable]
    public class MicroserviceDto
    {
        /// <summary>
        /// Microservice primary key
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Microservice Name
        /// </summary>
        [Required]
        [MaxLength(200)]
        public string Name { get; set; }

        /// <summary>
        /// Microservice description
        /// </summary>
        [Required]
        [MaxLength(200)]
        public string Description { get; set; }

        /// <summary>
        /// Microservice Code
        /// </summary>
        [Required]
        [MaxLength(6), MinLength(6)]
        public string ServiceCode { get; set; }

        /// <summary>
        /// SortNo
        /// </summary>
        [Required]
        public int SortNo { get; set; }

        /// <summary>
        /// Service AliasName
        /// </summary>
        [Required]
        [MaxLength(200)]
        public string ServiceAliasName { get; set; }

        /// <summary>
        /// Service Chinese Name
        /// </summary>
        [Required]
        [MaxLength(400)]
        public string ServiceChineseName { get; set; }

        /// <summary>
        /// Service Category
        /// </summary>
        [Required]
        [MaxLength(200)]
        public string ServiceCategory { get; set; }

        /// <summary>
        /// Service Dependencies
        /// </summary>
        [MaxLength(800)]
        public string Dependencies { get; set; }

        /// <summary>
        /// Coding Language
        /// </summary>
        [MaxLength(200)]
        public string CodingLanguage { get; set; }

        /// <summary>
        /// Responsible Team
        /// </summary>
        [Required]
        [MaxLength(200)]
        public string ResponsibleTeam { get; set; }

        /// <summary>
        /// Product Owner
        /// </summary>
        [Required]
        [MaxLength(200)]
        public string ProductOwner { get; set; }

        /// <summary>
        /// Technique Owner
        /// </summary>
        [MaxLength(200)]
        public string TechniqueOwner { get; set; }

        /// <summary>
        /// ScrumMaster
        /// </summary>
        [Required]
        [MaxLength(200)]
        public string ScrumMaster { get; set; }

        /// <summary>
        /// Developers
        /// </summary>
        [Required]
        [MaxLength(200)]
        public string Developers { get; set; }

        /// <summary>
        /// Service Confluence Url
        /// </summary>
        [Required]
        [MaxLength(200)]
        public string ServiceConfluenceUrl { get; set; }

        /// <summary>
        /// Repository Name
        /// </summary>
        [Required]
        [MaxLength(200)]
        public string RepositoryName { get; set; }

        /// <summary>
        /// AzureResource Type
        /// </summary>
        [MaxLength(200)]
        public string AzureResourceType { get; set; }

    }
}
