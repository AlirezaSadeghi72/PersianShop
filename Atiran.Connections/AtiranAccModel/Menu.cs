//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Atiran.Connections.AtiranAccModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class Menu
    {
        public int MenuID { get; set; }
        public Nullable<int> SubSystemID { get; set; }
        public string Titel { get; set; }
        public Nullable<int> ParentMenuID { get; set; }
        public Nullable<int> FormID { get; set; }
        public Nullable<int> order { get; set; }
        public string Shortcut { get; set; }
    
        public virtual Form Form { get; set; }
    }
}
