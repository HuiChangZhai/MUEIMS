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
    
    public partial class EnterpriseDynamic
    {
        public int EnterpriseDynamicID { get; set; }
        public int EnterpriseID { get; set; }
        public string EnterpriseDynamicTitle { get; set; }
        public string EnterpriseDynamicContent { get; set; }
    
        public virtual Enterprise Enterprise { get; set; }
    }
}
