using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Template1.Entity.DemoDotNetFramework
{
    [Table("QuartzJob", Schema = SchemaNames.DemoDotNetFrameworkDbSchemaNameV2)]
    public class QuartzJobEntity : IEntity
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
    }
}
