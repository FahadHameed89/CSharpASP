using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ASPTestProject.Models
{
    // In-class practice: Fill out the manufacturer class to function as a basic model. Foreign key stuff not needed.

    // Challenge: Implement the foreign key.
    [Table("manufacturer")]
    class Manufacturer
    {
        public Manufacturer()
        {
            Vehicles = new HashSet<Vehicle>();
        }

        [Key]
        [Column(TypeName = "int(10)")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Column(TypeName = "varchar(30)")]
        public string Name { get; set; }

        [InverseProperty(nameof(Models.Vehicle.Manufacturer))]
        public virtual ICollection<Vehicle> Vehicles { get; set; }
    }
}