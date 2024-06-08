using ArtFusionStudio.Models.ProductFeatures.PhoneFeatures;
using ArtFusionStudio.Models.ProductFeatures.PhoneFeatures.Physical;
using ArtFusionStudio.Utility;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ArtFusionStudio.Models
{
    public class Phone : Product
    {

        public int USBTypeId { get; set; }
        [ForeignKey("USBTypeId")]
        public USB? USBType { get; set; }
        public int StorageCapacityId { get; set; }
        [ForeignKey("StorageCapacityId")]
        public StorageCapacity? StorageCapacity { get; set; }
        public int RAMMemoryId { get; set; }
        [ForeignKey("RAMMemoryId")]
        public Memory? Memory { get; set; }

        public int DisplayTechnologyId { get; set; }
        [ForeignKey("DisplayTechnologyId")]
        public DisplayTechnology? DisplayTechnology { get; set; }

        public int CamerasId { get; set; }
        [ForeignKey("CamerasId")]
        public Camera? Camera { get; set; }


        public int OSNameAndVersionId { get; set; }

        [ForeignKey("OSNameAndVersionId")]
        public OSNameAndVersion? OSNameAndVersion { get; set; }
    }
}
