using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Template1.Entity.DemoDotNetCore
{
    [Table("Microservice", Schema = SchemaNames.Dbo)]
    public class MicroserviceEntity : IEntity
    {
        [Column("Id")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [Column("Name", TypeName = "nvarchar(200)")]
        public string Name { get; set; }

        [Required]
        [Column("Description", TypeName = "nvarchar(200)")]
        public string Description { get; set; }

        [Required]
        [Column("ServiceCode", TypeName = "nvarchar(6)")]
        public string ServiceCode { get; set; }

        [Required]
        [Column("SortNo")]
        public int SortNo { get; set; }

        [Column("ServiceAliasName", TypeName = "nvarchar(200)")]
        public string ServiceAliasName { get; set; }

        [Column("ServiceChineseName", TypeName = "nvarchar(400)")]
        public string ServiceChineseName { get; set; }

        [Column("ServiceCategory", TypeName = "nvarchar(200)")]
        public string ServiceCategory { get; set; }

        [Column("Dependencies", TypeName = "nvarchar(800)")]
        public string Dependencies { get; set; }

        [Column("CodingLanguage", TypeName = "nvarchar(200)")]
        public string CodingLanguage { get; set; }

        [Column("ResponsibleTeam", TypeName = "nvarchar(200)")]
        public string ResponsibleTeam { get; set; }

        [Column("ProductOwner", TypeName = "nvarchar(200)")]
        public string ProductOwner { get; set; }

        [Column("TechniqueOwner", TypeName = "nvarchar(200)")]
        public string TechniqueOwner { get; set; }

        [Column("ScrumMaster", TypeName = "nvarchar(200)")]
        public string ScrumMaster { get; set; }

        [Column("Developers", TypeName = "nvarchar(200)")]
        public string Developers { get; set; }

        [Column("ServiceConfluenceUrl", TypeName = "nvarchar(200)")]
        public string ServiceConfluenceUrl { get; set; }

        [Column("RepositoryName", TypeName = "nvarchar(200)")]
        public string RepositoryName { get; set; }

        [Column("AzureResourceType", TypeName = "nvarchar(200)")]
        public string AzureResourceType { get; set; }

    }
}
