using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtFusionStudio.Models.ProductFeatures.PhoneAccessories
{
    public class Case : Product
    {
        public int ProtectionLevelId { get; set; }

        [ForeignKey("ProtectionLevelId")]
        public ProtectionLevel? ProtectionLevel { get; set; }

        public int CaseMaterialId { get; set; }

        [ForeignKey("CaseMaterialId")]
        public CaseMaterial? CaseMaterial { get; set; }

        public int CaseTypeId { get; set; }

        [ForeignKey("CaseTypeId")]
        public CaseType? CaseType { get; set; }
    }
}
