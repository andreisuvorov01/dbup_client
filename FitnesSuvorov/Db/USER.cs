//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FitnesSuvorov.Db
{
    using System;
    using System.Collections.Generic;
    
    public partial class USER
    {
        public int Id { get; set; }
        public string login { get; set; }
        public string PASSWORD { get; set; }
        public string EMAIL { get; set; }
        public int UserInfoId { get; set; }
    
        public virtual USERINFO USERINFO { get; set; }
    }
}