//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LibraryETDBFIrst
{
    using System;
    using System.Collections.Generic;
    
    public partial class AuthorBook
    {
        public int AuthorBook1 { get; set; }
        public int BookID { get; set; }
        public int AuthorID { get; set; }
    
        public virtual Author Author { get; set; }
        public virtual Book Book { get; set; }
    }
}