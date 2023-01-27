using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiCoreCRUD.Model
{
    public class tblEmployee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [StringLength(50)]
        public string FirstName { get; set; }
        [StringLength(50)]
        public string LastName { get; set; }
        [StringLength(50)]
        public string Email { get; set; }
        public int Age { get; set; }
        public DateTime DOJ { get; set; }
        [StringLength(20)]
        public string Gender { get; set; }
        public int IsMarried { get; set; }
        public int IsActive { get; set; }
        [NotMapped]
        public string Designation { get; set; }
        [ForeignKey("Designation")]
        public int DesignationID { get; set; }

        public virtual tblDesignation Designations { get; set; }

    }
}
