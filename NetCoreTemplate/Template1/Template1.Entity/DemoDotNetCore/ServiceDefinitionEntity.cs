using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Template1.Entity.DemoDotNetCore
{
    [Table("ServiceDefinition", Schema = SchemaNames.Dbo)]
    public class ServiceDefinitionEntity : IEntity
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
    }
}
