using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BICTextFormatter
{
    class bicConv
    {
        public string fiu { get; set; } //FIU(3)
        public string bicNo { get; set; } //BIC#(14)
        public string bicINo { get; set; } //BICI#(1)
        public string bicName { get; set; } //BIC_NAME(105)
        public string bicDept { get; set; } //BIC_DEPT(70)
        public string bicCity { get; set; } //BIC_CITY(30)
        public string bicType { get; set; } //BIC_TYPE(4)
        public string bicAdd1 { get; set; } //BIC_ADD1(35)
        public string bicAdd2 { get; set; } //BIC_ADD2(35)
        public string bicAdd3 { get; set; } //BIC_ADD3(35)
        public string bicAdd4 { get; set; } //BIC_ADD4(35)
    }
}
