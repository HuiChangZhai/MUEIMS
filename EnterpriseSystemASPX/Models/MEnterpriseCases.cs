//------------------------------------------------------------------------------
// <auto-generated>
//    此代码是根据模板生成的。
//
//    手动更改此文件可能会导致应用程序中发生异常行为。
//    如果重新生成代码，则将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace EnterpriseSystemASPX.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class MEnterpriseCases
    {
        public int MEnterpriseCasesID { get; set; }
        public int MEnterpriseID { get; set; }
        public string MEnterpriseCasesTitle { get; set; }
        public string MEnterpriseCasesContent { get; set; }
    
        public virtual MEnterprise MEnterprise { get; set; }
    }
}
