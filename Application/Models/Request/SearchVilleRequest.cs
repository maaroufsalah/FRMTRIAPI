using Application.Constants;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Models.Request
{
    public class SearchVilleRequest
    {
        public SearchVilleRequest() => (PageSize, IsDeleted) = (SettingsConstant.PAGE_SIZE, false);


        public bool? IsDeleted { get; set; }
        public string VilleLibelle { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
    }
}
